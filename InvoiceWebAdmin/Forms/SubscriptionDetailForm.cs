using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public partial class SubscriptionDetailForm : Form
{
    private readonly AdminDbContext _db;
    private readonly int _periodId;
    private SubscriptionPeriod _period = null!;
    public bool Changed { get; private set; } = false;

    public SubscriptionDetailForm(AdminDbContext db, int periodId)
    {
        _db = db;
        _periodId = periodId;
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        _period = _db.SubscriptionPeriods
            .Include(p => p.User)
            .ThenInclude(u => u.CompanySettings)
            .First(p => p.Id == _periodId);

        var firma = _period.User.CompanySettings?.CompanyName ?? _period.User.Email;
        _lblFirmaVal.Text = firma;
        _lblEmailVal.Text = _period.User.Email;

        _dtFrom.Value = _period.From.ToDateTime(TimeOnly.MinValue);
        _dtTo.Value = _period.To.ToDateTime(TimeOnly.MinValue);
        _txtVarSym.Text = _period.VariabilniSymbol ?? "";
        _txtNote.Text = _period.Note ?? "";

        if (_period.DatumObjednavky.HasValue)
        {
            _dtObjednavky.Checked = true;
            _dtObjednavky.Value = _period.DatumObjednavky.Value.ToLocalTime();
        }
        else
        {
            _dtObjednavky.Checked = false;
        }

        _lblZaplacenoVal.Text = _period.Zaplaceno ? "Ano" : "Ne";
        _lblZaplacenoVal.ForeColor = _period.Zaplaceno ? Color.FromArgb(0, 128, 0) : Color.FromArgb(180, 100, 0);

        var today = DateOnly.FromDateTime(DateTime.Today);
        var stav = _period.Zaplaceno && _period.From <= today && _period.To >= today
            ? "Aktivní"
            : _period.To < today ? "Expirováno" : "Budoucí";
        _lblStavVal.Text = stav;
        _lblStavVal.ForeColor = stav == "Aktivní" ? Color.FromArgb(0, 128, 0) : Color.FromArgb(150, 80, 0);

        _btnMarkPaid.Enabled = !_period.Zaplaceno;
        _btnUnmarkPaid.Enabled = _period.Zaplaceno;

        Text = $"Předplatné – {firma} ({_period.From:d.M.yyyy} – {_period.To:d.M.yyyy})";
    }

    private void SavePeriod(object? sender, EventArgs e)
    {
        var from = DateOnly.FromDateTime(_dtFrom.Value);
        var to = DateOnly.FromDateTime(_dtTo.Value);
        if (from > to)
        {
            MessageBox.Show("Datum 'Od' musí být před datem 'Do'.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _period.From = from;
        _period.To = to;
        _period.VariabilniSymbol = string.IsNullOrWhiteSpace(_txtVarSym.Text) ? null : _txtVarSym.Text.Trim();
        _period.DatumObjednavky = _dtObjednavky.Checked ? (DateTime?)_dtObjednavky.Value.ToUniversalTime() : null;
        _period.Note = string.IsNullOrWhiteSpace(_txtNote.Text) ? null : _txtNote.Text.Trim();
        _db.SaveChanges();
        Changed = true;
        LoadData();
    }

    private void MarkPaid(object? sender, EventArgs e)
    {
        _period.Zaplaceno = true;
        _period.User.IsActive = true;
        _period.User.UpdatedAt = DateTime.UtcNow;
        _db.SaveChanges();
        Changed = true;
        LoadData();
    }

    private void UnmarkPaid(object? sender, EventArgs e)
    {
        _period.Zaplaceno = false;
        _db.SaveChanges();
        Changed = true;
        LoadData();
    }

    private void OpenUser(object? sender, EventArgs e)
    {
        using var form = new UserDetailForm(_db, _period.UserId);
        form.ShowDialog(this);
        LoadData();
        Changed = true;
    }

    private void BtnSave_Click(object sender, EventArgs e) => SavePeriod(sender, e);
    private void BtnMarkPaid_Click(object sender, EventArgs e) => MarkPaid(sender, e);
    private void BtnUnmarkPaid_Click(object sender, EventArgs e) => UnmarkPaid(sender, e);
    private void BtnOpenUser_Click(object sender, EventArgs e) => OpenUser(sender, e);
    private void BtnClose_Click(object sender, EventArgs e) => Close();
}

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
        _lblOdVal.Text = _period.From.ToString("d.M.yyyy");
        _lblDoVal.Text = _period.To.ToString("d.M.yyyy");
        _lblVarSymVal.Text = _period.VariabilniSymbol ?? "–";
        _lblDatumObjVal.Text = _period.DatumObjednavky?.ToLocalTime().ToString("d.M.yyyy HH:mm") ?? "–";
        _lblZaplacenoVal.Text = _period.Zaplaceno ? "Ano" : "Ne";
        _lblZaplacenoVal.ForeColor = _period.Zaplaceno ? Color.FromArgb(0, 128, 0) : Color.FromArgb(180, 100, 0);

        var today = DateOnly.FromDateTime(DateTime.Today);
        var stav = _period.Zaplaceno && _period.From <= today && _period.To >= today
            ? "Aktivní"
            : _period.To < today ? "Expirováno" : "Budoucí";
        _lblStavVal.Text = stav;
        _lblStavVal.ForeColor = stav == "Aktivní" ? Color.FromArgb(0, 128, 0) : Color.FromArgb(150, 80, 0);

        _btnMarkPaid.Enabled = !_period.Zaplaceno;

        Text = $"Předplatné – {firma} ({_period.From:d.M.yyyy} – {_period.To:d.M.yyyy})";
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

    private void OpenUser(object? sender, EventArgs e)
    {
        using var form = new UserDetailForm(_db, _period.UserId);
        form.ShowDialog(this);
        LoadData();
        Changed = true;
    }

    private void EditPeriod(object? sender, EventArgs e)
    {
        using var form = new PeriodEditForm(_period, _period.From);
        if (form.ShowDialog(this) != DialogResult.OK) return;

        _period.From = form.PeriodFrom;
        _period.To = form.PeriodTo;
        _period.Note = form.PeriodNote;
        _period.VariabilniSymbol = form.PeriodVariabilniSymbol;
        _period.DatumObjednavky = form.PeriodDatumObjednavky;
        _db.SaveChanges();
        Changed = true;
        LoadData();
    }

    private void BtnMarkPaid_Click(object sender, EventArgs e) => MarkPaid(sender, e);
    private void BtnEdit_Click(object sender, EventArgs e) => EditPeriod(sender, e);
    private void BtnOpenUser_Click(object sender, EventArgs e) => OpenUser(sender, e);
    private void BtnClose_Click(object sender, EventArgs e) => Close();
}

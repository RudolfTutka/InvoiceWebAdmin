using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public partial class UserDetailForm : Form
{
    private readonly AdminDbContext _db;
    private readonly int _userId;
    private User _user = null!;
    private List<SubscriptionPeriod> _periods = new();

    public UserDetailForm(AdminDbContext db, int userId)
    {
        _db = db;
        _userId = userId;
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        _user = _db.Users
            .Include(u => u.CompanySettings)
            .First(u => u.Id == _userId);

        var settings = _db.AdminSettings.FirstOrDefault() ?? new AdminSettings();

        _txtEmail.Text = _user.Email;
        _txtCompanyName.Text = _user.CompanySettings?.CompanyName ?? "";
        _txtIco.Text = _user.CompanySettings?.Ico ?? "";
        _txtDic.Text = _user.CompanySettings?.Dic ?? "";
        _chkActive.Checked = _user.IsActive;

        _lblRegistrace.Text = _user.CreatedAt.ToLocalTime().ToString("d.M.yyyy HH:mm");
        var trialEnd = _user.CreatedAt.ToLocalTime().AddDays(settings.TrialDays);
        _lblTrialDo.Text = trialEnd.ToString("d.M.yyyy");

        Text = $"Detail uživatele – {_user.CompanySettings?.CompanyName ?? _user.Email}";
        LoadPeriods();
    }

    private void LoadPeriods()
    {
        // AsNoTracking zajistí vždy čerstvá data z DB bez vlivu identity mapu
        _periods = _db.SubscriptionPeriods
            .AsNoTracking()
            .Where(p => p.UserId == _userId)
            .OrderByDescending(p => p.From)
            .ToList();

        _gridSubs.Rows.Clear();
        var today = DateOnly.FromDateTime(DateTime.Today);
        foreach (var p in _periods)
        {
            var stav = p.Zaplaceno && p.From <= today && p.To >= today
                ? "Aktivní"
                : p.To < today ? "Expirováno" : "Budoucí";

            var i = _gridSubs.Rows.Add(
                p.From.ToString("d.M.yyyy"),
                p.To.ToString("d.M.yyyy"),
                p.VariabilniSymbol ?? "",
                p.DatumObjednavky?.ToLocalTime().ToString("d.M.yyyy") ?? "",
                p.Zaplaceno ? "Ano" : "Ne",
                stav);
            _gridSubs.Rows[i].Tag = p.Id;

            if (p.Zaplaceno && p.From <= today && p.To >= today)
                _gridSubs.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
            else if (p.To < today)
                _gridSubs.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            else if (!p.Zaplaceno)
                _gridSubs.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
        }
    }

    private void SaveBasicInfo(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_txtEmail.Text))
        {
            MessageBox.Show("E-mail nesmí být prázdný.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!string.IsNullOrEmpty(_txtNewPassword.Text))
        {
            if (_txtNewPassword.Text != _txtConfirmPassword.Text)
            {
                MessageBox.Show("Hesla se neshodují.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_txtNewPassword.Text.Length < 6)
            {
                MessageBox.Show("Heslo musí mít alespoň 6 znaků.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(_txtNewPassword.Text);
        }

        _user.Email = _txtEmail.Text.Trim();
        _user.IsActive = _chkActive.Checked;
        _user.UpdatedAt = DateTime.UtcNow;

        if (_user.CompanySettings != null)
        {
            _user.CompanySettings.CompanyName = _txtCompanyName.Text.Trim();
            _user.CompanySettings.Ico = _txtIco.Text.Trim();
            _user.CompanySettings.Dic = _txtDic.Text.Trim();
            _user.CompanySettings.UpdatedAt = DateTime.UtcNow;
        }

        _db.SaveChanges();
        _txtNewPassword.Text = "";
        _txtConfirmPassword.Text = "";
        MessageBox.Show("Změny uloženy.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private int? SelectedPeriodId() =>
        _gridSubs.SelectedRows.Count > 0 ? (int?)_gridSubs.SelectedRows[0].Tag : null;

    // Vrátí tracked entitu z DB (pro operace, které mění data)
    private SubscriptionPeriod? GetTrackedPeriod(int id) =>
        _db.SubscriptionPeriods.FirstOrDefault(p => p.Id == id);

    private void AddPeriod()
    {
        var lastTo = _periods
            .OrderByDescending(p => p.To).FirstOrDefault()?.To;
        var defaultFrom = lastTo.HasValue
            ? lastTo.Value.AddDays(1)
            : DateOnly.FromDateTime(DateTime.Today);

        using var form = new PeriodEditForm(null, defaultFrom);
        if (form.ShowDialog(this) != DialogResult.OK) return;

        var period = new SubscriptionPeriod
        {
            UserId = _userId,
            From = form.PeriodFrom,
            To = form.PeriodTo,
            Note = form.PeriodNote,
            VariabilniSymbol = form.PeriodVariabilniSymbol,
            DatumObjednavky = form.PeriodDatumObjednavky,
            CreatedAt = DateTime.UtcNow
        };
        _db.SubscriptionPeriods.Add(period);
        _db.SaveChanges();
        LoadPeriods();
    }

    private void EditPeriod()
    {
        var id = SelectedPeriodId();
        if (id == null) return;

        using var form = new SubscriptionDetailForm(_db, id.Value, showOpenUser: false);
        form.ShowDialog(this);
        if (form.Changed) LoadPeriods();
    }

    private void DeletePeriod()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        var periodDisplay = _periods.First(p => p.Id == id);

        var confirm = MessageBox.Show(
            $"Smazat období {periodDisplay.From:d.M.yyyy} – {periodDisplay.To:d.M.yyyy}?",
            "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        var period = GetTrackedPeriod(id.Value);
        if (period == null) return;

        _db.SubscriptionPeriods.Remove(period);
        _db.SaveChanges();
        LoadPeriods();
    }

    private void MarkPaid()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        var periodDisplay = _periods.FirstOrDefault(p => p.Id == id);
        if (periodDisplay == null || periodDisplay.Zaplaceno) return;

        var period = GetTrackedPeriod(id.Value);
        if (period == null) return;

        period.Zaplaceno = true;
        _user.IsActive = true;
        _user.UpdatedAt = DateTime.UtcNow;
        _db.SaveChanges();
        _chkActive.Checked = true;
        LoadPeriods();
    }

    private void BtnAddPeriod_Click(object sender, EventArgs e) => AddPeriod();
    private void BtnEditPeriod_Click(object sender, EventArgs e) => EditPeriod();
    private void BtnDeletePeriod_Click(object sender, EventArgs e) => DeletePeriod();
    private void BtnMarkPaid_Click(object sender, EventArgs e) => MarkPaid();
    private void GridSubs_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => EditPeriod();
    private void GridSubs_SelectionChanged(object sender, EventArgs e)
    {
        var hasSelection = _gridSubs.SelectedRows.Count > 0;
        _btnEditPeriod.Enabled = hasSelection;
        _btnDeletePeriod.Enabled = hasSelection;

        if (hasSelection)
        {
            var id = (int)(_gridSubs.SelectedRows[0].Tag ?? 0);
            var period = _periods.FirstOrDefault(p => p.Id == id);
            _btnMarkPaid.Enabled = period != null && !period.Zaplaceno;
        }
        else
        {
            _btnMarkPaid.Enabled = false;
        }
    }
}

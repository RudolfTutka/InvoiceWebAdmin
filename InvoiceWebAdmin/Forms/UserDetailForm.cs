using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public partial class UserDetailForm : Form
{
    private readonly AdminDbContext _db;
    private readonly int _userId;
    private User _user = null!;

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
            .Include(u => u.SubscriptionPeriods)
            .First(u => u.Id == _userId);

        var settings = _db.AdminSettings.FirstOrDefault() ?? new AdminSettings();

        _txtEmail.Text = _user.Email;
        _txtCompanyName.Text = _user.CompanySettings?.CompanyName ?? "";
        _txtIco.Text = _user.CompanySettings?.Ico ?? _user.Ico;
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
        _gridSubs.Rows.Clear();
        var today = DateOnly.FromDateTime(DateTime.Today);
        foreach (var p in _user.SubscriptionPeriods.OrderByDescending(p => p.From))
        {
            var i = _gridSubs.Rows.Add(
                p.From.ToString("d.M.yyyy"),
                p.To.ToString("d.M.yyyy"),
                p.Note ?? "",
                p.CreatedAt.ToLocalTime().ToString("d.M.yyyy"));
            _gridSubs.Rows[i].Tag = p.Id;
            if (p.From <= today && p.To >= today)
                _gridSubs.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
            else if (p.To < today)
                _gridSubs.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
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

    private void AddPeriod()
    {
        var lastTo = _user.SubscriptionPeriods
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
            CreatedAt = DateTime.UtcNow
        };
        _db.SubscriptionPeriods.Add(period);
        _db.SaveChanges();
        _user.SubscriptionPeriods.Add(period);
        LoadPeriods();
    }

    private void EditPeriod()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        var period = _user.SubscriptionPeriods.First(p => p.Id == id);

        using var form = new PeriodEditForm(period, period.From);
        if (form.ShowDialog(this) != DialogResult.OK) return;

        period.From = form.PeriodFrom;
        period.To = form.PeriodTo;
        period.Note = form.PeriodNote;
        _db.SaveChanges();
        LoadPeriods();
    }

    private void DeletePeriod()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        var period = _user.SubscriptionPeriods.First(p => p.Id == id);

        var confirm = MessageBox.Show(
            $"Smazat období {period.From:d.M.yyyy} – {period.To:d.M.yyyy}?",
            "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _db.SubscriptionPeriods.Remove(period);
        _db.SaveChanges();
        _user.SubscriptionPeriods.Remove(period);
        LoadPeriods();
    }
}

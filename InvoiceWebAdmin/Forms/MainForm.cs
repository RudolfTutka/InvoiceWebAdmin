using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public partial class MainForm : Form
{
    private readonly AdminDbContext _db;
    private List<UserRow> _allRows = new();

    public MainForm(AdminDbContext db)
    {
        _db = db;
        InitializeComponent();
        LoadUsers();
    }

    private void LoadUsers()
    {
        var settings = _db.AdminSettings.FirstOrDefault() ?? new AdminSettings();

        _allRows = _db.Users
            .Include(u => u.CompanySettings)
            .Include(u => u.SubscriptionPeriods)
            .OrderByDescending(u => u.CreatedAt)
            .ToList()
            .Select(u => new UserRow(u, settings.TrialDays))
            .ToList();

        FilterUsers();
    }

    private void FilterUsers()
    {
        var q = _searchBox.Text.Trim().ToLower();
        var rows = string.IsNullOrEmpty(q)
            ? _allRows
            : _allRows.Where(r =>
                r.Email.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                (r.CompanyName ?? "").Contains(q, StringComparison.OrdinalIgnoreCase) ||
                (r.Ico ?? "").Contains(q)).ToList();

        _grid.Rows.Clear();
        foreach (var r in rows)
        {
            var i = _grid.Rows.Add(r.Id, r.CompanyName, r.Ico, r.Email, r.StavLabel, r.PlatnyDo, r.Registrace);
            _grid.Rows[i].Tag = r.Id;
            _grid.Rows[i].DefaultCellStyle.BackColor = r.RowColor;
        }
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        var selected = _grid.SelectedRows.Count > 0;
        _btnDetail.Enabled = selected;
        _btnDelete.Enabled = selected;
    }

    private int? SelectedUserId() =>
        _grid.SelectedRows.Count > 0 ? (int?)_grid.SelectedRows[0].Tag : null;

    private void OpenDetail()
    {
        var id = SelectedUserId();
        if (id == null) return;
        using var form = new UserDetailForm(_db, id.Value);
        form.ShowDialog(this);
        LoadUsers();
    }

    private void DeleteUser()
    {
        var id = SelectedUserId();
        if (id == null) return;
        var user = _db.Users.Include(u => u.CompanySettings).FirstOrDefault(u => u.Id == id);
        if (user == null) return;

        var confirm = MessageBox.Show(
            $"Opravdu smazat uživatele '{user.CompanySettings?.CompanyName ?? user.Email}'?\n\nBudou smazána veškerá jeho data.",
            "Potvrzení smazání", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes) return;

        _db.Users.Remove(user);
        _db.SaveChanges();
        LoadUsers();
    }

    private void OpenSettings()
    {
        using var form = new SettingsForm(_db);
        form.ShowDialog(this);
        LoadUsers();
    }

    private void SearchBox_TextChanged(object sender, EventArgs e) => FilterUsers();
    private void BtnDetail_Click(object sender, EventArgs e) => OpenDetail();
    private void BtnDelete_Click(object sender, EventArgs e) => DeleteUser();
    private void BtnSettings_Click(object sender, EventArgs e) => OpenSettings();
    private void Grid_SelectionChanged(object sender, EventArgs e) => UpdateButtons();
    private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => OpenDetail();
}

/// <summary>Pomocná třída pro zobrazení řádku uživatele v gridu.</summary>
internal class UserRow
{
    public int Id { get; }
    public string Email { get; }
    public string? CompanyName { get; }
    public string? Ico { get; }
    public string StavLabel { get; }
    public string PlatnyDo { get; }
    public string Registrace { get; }
    public Color RowColor { get; }

    public UserRow(User user, int trialDays)
    {
        Id = user.Id;
        Email = user.Email;
        CompanyName = user.CompanySettings?.CompanyName;
        Ico = user.CompanySettings?.Ico;
        Registrace = user.CreatedAt.ToLocalTime().ToString("d.M.yyyy");

        var today = DateOnly.FromDateTime(DateTime.Today);
        var trialEnd = DateOnly.FromDateTime(user.CreatedAt.ToLocalTime().AddDays(trialDays));
        var activePeriod = user.SubscriptionPeriods
            .Where(p => p.From <= today && p.To >= today)
            .FirstOrDefault();
        var latestPeriod = user.SubscriptionPeriods
            .OrderByDescending(p => p.To)
            .FirstOrDefault();

        if (!user.IsActive)
        {
            StavLabel = "Deaktivován";
            PlatnyDo = "–";
            RowColor = Color.FromArgb(255, 220, 220);
        }
        else if (activePeriod != null)
        {
            StavLabel = "Aktivní";
            PlatnyDo = activePeriod.To.ToString("d.M.yyyy");
            RowColor = Color.FromArgb(220, 255, 220);
        }
        else if (today <= trialEnd && !user.SubscriptionPeriods.Any())
        {
            StavLabel = $"Trial (do {trialEnd:d.M.yyyy})";
            PlatnyDo = trialEnd.ToString("d.M.yyyy");
            RowColor = Color.FromArgb(255, 255, 210);
        }
        else if (latestPeriod != null)
        {
            StavLabel = $"Expirováno {latestPeriod.To:d.M.yyyy}";
            PlatnyDo = latestPeriod.To.ToString("d.M.yyyy");
            RowColor = Color.FromArgb(255, 220, 220);
        }
        else
        {
            StavLabel = "Expirováno (trial)";
            PlatnyDo = trialEnd.ToString("d.M.yyyy");
            RowColor = Color.FromArgb(255, 220, 220);
        }
    }
}

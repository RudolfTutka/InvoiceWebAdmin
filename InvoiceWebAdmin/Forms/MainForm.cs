using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public class MainForm : Form
{
    private readonly AdminDbContext _db;
    private DataGridView _grid = null!;
    private TextBox _searchBox = null!;
    private Button _btnDetail = null!;
    private Button _btnDelete = null!;
    private Button _btnSettings = null!;
    private List<UserRow> _allRows = new();

    public MainForm(AdminDbContext db)
    {
        _db = db;
        Text = "InvoiceWeb Admin";
        Size = new Size(1000, 600);
        StartPosition = FormStartPosition.CenterScreen;
        BuildUi();
        LoadUsers();
    }

    private void BuildUi()
    {
        var toolbar = new Panel { Dock = DockStyle.Top, Height = 44, Padding = new Padding(8, 6, 8, 6) };

        var lblSearch = new Label { Text = "Hledat:", AutoSize = true, Left = 0, Top = 12 };
        _searchBox = new TextBox { Left = 55, Top = 8, Width = 220 };
        _searchBox.TextChanged += (_, _) => FilterUsers();

        _btnDetail = new Button { Text = "Detail / Upravit", Left = 290, Top = 6, Width = 130, Enabled = false };
        _btnDetail.Click += (_, _) => OpenDetail();

        _btnDelete = new Button { Text = "Smazat", Left = 430, Top = 6, Width = 90, Enabled = false };
        _btnDelete.Click += (_, _) => DeleteUser();

        _btnSettings = new Button { Text = "Nastavení", Left = 540, Top = 6, Width = 100 };
        _btnSettings.Click += (_, _) => OpenSettings();

        toolbar.Controls.AddRange([lblSearch, _searchBox, _btnDetail, _btnDelete, _btnSettings]);
        Controls.Add(toolbar);

        _grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            AllowUserToAddRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            RowHeadersVisible = false,
            BackgroundColor = SystemColors.Window
        };
        _grid.SelectionChanged += (_, _) => UpdateButtons();
        _grid.CellDoubleClick += (_, _) => OpenDetail();
        Controls.Add(_grid);

        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", FillWeight = 30 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFirma", HeaderText = "Firma" });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIco", HeaderText = "IČO", FillWeight = 60 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "E-mail" });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStav", HeaderText = "Stav", FillWeight = 70 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPlatnyDo", HeaderText = "Platné do", FillWeight = 70 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRegistrace", HeaderText = "Registrace", FillWeight = 70 });
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
        LoadUsers(); // reload kvůli trial dnům
    }
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
        Ico = user.CompanySettings?.Ico ?? user.Ico;
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

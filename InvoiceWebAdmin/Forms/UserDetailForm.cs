using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public class UserDetailForm : Form
{
    private readonly AdminDbContext _db;
    private readonly int _userId;
    private User _user = null!;

    // Záložky
    private TabControl _tabs = null!;

    // Záložka Základní údaje
    private TextBox _txtEmail = null!, _txtCompanyName = null!, _txtIco = null!, _txtDic = null!;
    private CheckBox _chkActive = null!;
    private TextBox _txtNewPassword = null!, _txtConfirmPassword = null!;
    private Label _lblRegistrace = null!, _lblTrialDo = null!;

    // Záložka Předplatné
    private DataGridView _gridSubs = null!;
    private Button _btnAddPeriod = null!, _btnEditPeriod = null!, _btnDeletePeriod = null!;

    public UserDetailForm(AdminDbContext db, int userId)
    {
        _db = db;
        _userId = userId;
        Text = "Detail uživatele";
        Size = new Size(700, 560);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        BuildUi();
        LoadData();
    }

    private void BuildUi()
    {
        _tabs = new TabControl { Dock = DockStyle.Fill };
        Controls.Add(_tabs);

        // === Záložka: Základní údaje ===
        var tabInfo = new TabPage("Základní údaje");
        _tabs.TabPages.Add(tabInfo);

        int y = 16, lw = 140, fw = 300;
        Label L(string text) => new Label { Text = text, Left = 12, Top = y, Width = lw, AutoSize = false, TextAlign = ContentAlignment.MiddleRight };
        TextBox T(bool readOnly = false) { var t = new TextBox { Left = lw + 20, Top = y, Width = fw, ReadOnly = readOnly }; y += 32; return t; }

        tabInfo.Controls.Add(L("E-mail:")); _txtEmail = T(); tabInfo.Controls.Add(_txtEmail);
        tabInfo.Controls.Add(L("Název firmy:")); _txtCompanyName = T(); tabInfo.Controls.Add(_txtCompanyName);
        tabInfo.Controls.Add(L("IČO:")); _txtIco = T(); tabInfo.Controls.Add(_txtIco);
        tabInfo.Controls.Add(L("DIČ:")); _txtDic = T(); tabInfo.Controls.Add(_txtDic);

        _chkActive = new CheckBox { Text = "Uživatel je aktivní", Left = lw + 20, Top = y, AutoSize = true };
        tabInfo.Controls.Add(_chkActive); y += 32;

        y += 8;
        tabInfo.Controls.Add(new Label { Text = "──── Změna hesla ────", Left = 12, Top = y, Width = 400, Font = new Font(Font, FontStyle.Italic) }); y += 28;
        tabInfo.Controls.Add(L("Nové heslo:")); _txtNewPassword = new TextBox { Left = lw + 20, Top = y, Width = fw, UseSystemPasswordChar = true }; tabInfo.Controls.Add(_txtNewPassword); y += 32;
        tabInfo.Controls.Add(L("Potvrdit heslo:")); _txtConfirmPassword = new TextBox { Left = lw + 20, Top = y, Width = fw, UseSystemPasswordChar = true }; tabInfo.Controls.Add(_txtConfirmPassword); y += 32;

        y += 8;
        tabInfo.Controls.Add(new Label { Text = "──── Informace ────", Left = 12, Top = y, Width = 400, Font = new Font(Font, FontStyle.Italic) }); y += 28;
        tabInfo.Controls.Add(L("Registrace:"));
        _lblRegistrace = new Label { Left = lw + 20, Top = y, Width = fw, AutoSize = false }; tabInfo.Controls.Add(_lblRegistrace); y += 28;
        tabInfo.Controls.Add(L("Trial vyprší:"));
        _lblTrialDo = new Label { Left = lw + 20, Top = y, Width = fw, AutoSize = false }; tabInfo.Controls.Add(_lblTrialDo); y += 32;

        var btnSaveInfo = new Button { Text = "Uložit změny", Left = lw + 20, Top = y, Width = 120 };
        btnSaveInfo.Click += SaveBasicInfo;
        tabInfo.Controls.Add(btnSaveInfo);

        // === Záložka: Předplatné ===
        var tabSubs = new TabPage("Předplatné");
        _tabs.TabPages.Add(tabSubs);

        var subsToolbar = new Panel { Dock = DockStyle.Top, Height = 40, Padding = new Padding(4, 6, 4, 4) };
        _btnAddPeriod = new Button { Text = "Přidat období", Left = 4, Top = 6, Width = 120 };
        _btnAddPeriod.Click += (_, _) => AddPeriod();
        _btnEditPeriod = new Button { Text = "Upravit", Left = 132, Top = 6, Width = 90, Enabled = false };
        _btnEditPeriod.Click += (_, _) => EditPeriod();
        _btnDeletePeriod = new Button { Text = "Smazat", Left = 230, Top = 6, Width = 90, Enabled = false };
        _btnDeletePeriod.Click += (_, _) => DeletePeriod();
        subsToolbar.Controls.AddRange([_btnAddPeriod, _btnEditPeriod, _btnDeletePeriod]);
        tabSubs.Controls.Add(subsToolbar);

        _gridSubs = new DataGridView
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
        _gridSubs.SelectionChanged += (_, _) =>
        {
            _btnEditPeriod.Enabled = _gridSubs.SelectedRows.Count > 0;
            _btnDeletePeriod.Enabled = _gridSubs.SelectedRows.Count > 0;
        };
        _gridSubs.CellDoubleClick += (_, _) => EditPeriod();
        _gridSubs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFrom", HeaderText = "Od", FillWeight = 80 });
        _gridSubs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTo", HeaderText = "Do", FillWeight = 80 });
        _gridSubs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNote", HeaderText = "Poznámka" });
        _gridSubs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreated", HeaderText = "Vytvořeno", FillWeight = 80 });
        tabSubs.Controls.Add(_gridSubs);
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

        // Změna hesla
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

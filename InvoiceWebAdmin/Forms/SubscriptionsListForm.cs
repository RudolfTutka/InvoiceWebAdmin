using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public partial class SubscriptionsListForm : Form
{
    private readonly AdminDbContext _db;
    private List<SubscriptionPeriod> _allPeriods = new();
    private List<SubscriptionPeriod> _filteredPeriods = new();

    public SubscriptionsListForm(AdminDbContext db)
    {
        _db = db;
        InitializeComponent();
        LoadSubscriptions();
    }

    private void LoadSubscriptions()
    {
        _allPeriods = _db.SubscriptionPeriods
            .Include(p => p.User)
            .ThenInclude(u => u.CompanySettings)
            .OrderByDescending(p => p.From)
            .ToList();

        ApplyFilter();
    }

    private void ApplyFilter()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        IEnumerable<SubscriptionPeriod> periods = _allPeriods;

        periods = _cmbFilter.SelectedIndex switch
        {
            1 => periods.Where(p => p.Zaplaceno && p.From <= today && p.To >= today),
            2 => periods.Where(p => !p.Zaplaceno),
            3 => periods.Where(p => p.To < today),
            _ => periods
        };

        _filteredPeriods = periods.ToList();
        _grid.Rows.Clear();

        foreach (var p in _filteredPeriods)
        {
            var firma = p.User.CompanySettings?.CompanyName ?? p.User.Email;
            var stav = p.Zaplaceno && p.From <= today && p.To >= today
                ? "Aktivní"
                : p.To < today ? "Expirováno" : "Budoucí";

            var i = _grid.Rows.Add(
                firma,
                p.From.ToString("d.M.yyyy"),
                p.To.ToString("d.M.yyyy"),
                p.VariabilniSymbol ?? "",
                p.DatumObjednavky?.ToLocalTime().ToString("d.M.yyyy") ?? "",
                p.Zaplaceno ? "Ano" : "Ne",
                stav);
            _grid.Rows[i].Tag = p.Id;

            if (stav == "Aktivní")
                _grid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
            else if (p.To < today)
                _grid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            else if (!p.Zaplaceno)
                _grid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
        }

        UpdateButtons();
    }

    private void UpdateButtons()
    {
        var hasSelection = _grid.SelectedRows.Count > 0;
        _btnDetail.Enabled = hasSelection;
        _btnOpenUser.Enabled = hasSelection;
        _btnDelete.Enabled = hasSelection;

        if (hasSelection)
        {
            var id = (int)(_grid.SelectedRows[0].Tag ?? 0);
            var period = _filteredPeriods.FirstOrDefault(p => p.Id == id);
            _btnMarkPaid.Enabled = period != null && !period.Zaplaceno;
        }
        else
        {
            _btnMarkPaid.Enabled = false;
        }
    }

    private int? SelectedPeriodId() =>
        _grid.SelectedRows.Count > 0 ? (int?)_grid.SelectedRows[0].Tag : null;

    private void OpenDetail()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        using var form = new SubscriptionDetailForm(_db, id.Value);
        form.ShowDialog(this);
        if (form.Changed) LoadSubscriptions();
    }

    private void OpenUser()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        var period = _filteredPeriods.First(p => p.Id == id);
        using var form = new UserDetailForm(_db, period.UserId);
        form.ShowDialog(this);
        LoadSubscriptions();
    }

    private void MarkPaidDirect()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        var period = _filteredPeriods.FirstOrDefault(p => p.Id == id);
        if (period == null || period.Zaplaceno) return;

        period.Zaplaceno = true;
        period.User.IsActive = true;
        period.User.UpdatedAt = DateTime.UtcNow;
        _db.SaveChanges();
        LoadSubscriptions();
    }

    private void DeletePeriod()
    {
        var id = SelectedPeriodId();
        if (id == null) return;
        var period = _filteredPeriods.FirstOrDefault(p => p.Id == id);
        if (period == null) return;

        var firma = period.User.CompanySettings?.CompanyName ?? period.User.Email;
        var confirm = MessageBox.Show(
            $"Smazat předplatné {period.From:d.M.yyyy} – {period.To:d.M.yyyy} ({firma})?",
            "Potvrzení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        _db.SubscriptionPeriods.Remove(period);
        _db.SaveChanges();
        LoadSubscriptions();
    }

    private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
    private void BtnDetail_Click(object sender, EventArgs e) => OpenDetail();
    private void BtnOpenUser_Click(object sender, EventArgs e) => OpenUser();
    private void BtnMarkPaid_Click(object sender, EventArgs e) => MarkPaidDirect();
    private void BtnDelete_Click(object sender, EventArgs e) => DeletePeriod();
    private void Grid_SelectionChanged(object sender, EventArgs e) => UpdateButtons();
    private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => OpenDetail();
}

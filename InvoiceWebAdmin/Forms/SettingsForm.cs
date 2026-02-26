using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public partial class SettingsForm : Form
{
    private readonly AdminDbContext _db;

    public SettingsForm(AdminDbContext db)
    {
        _db = db;
        InitializeComponent();
        LoadSettings();
    }

    private void LoadSettings()
    {
        var s = _db.AdminSettings.FirstOrDefault() ?? new AdminSettings();
        _nudTrialDays.Value = s.TrialDays;
        _txtMonthlyPrice.Text = s.MonthlyPriceExclVat.ToString("0.00");
    }

    private void Save(object? sender, EventArgs e)
    {
        if (!decimal.TryParse(_txtMonthlyPrice.Text.Replace(',', '.'),
            System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture,
            out var price))
        {
            MessageBox.Show("Neplatná cena.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var s = _db.AdminSettings.FirstOrDefault();
        if (s == null)
        {
            s = new AdminSettings { Id = 1 };
            _db.AdminSettings.Add(s);
        }

        s.TrialDays = (int)_nudTrialDays.Value;
        s.MonthlyPriceExclVat = price;
        _db.SaveChanges();
        MessageBox.Show("Nastavení uloženo.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

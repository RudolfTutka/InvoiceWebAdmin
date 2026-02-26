using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Forms;

public class SettingsForm : Form
{
    private readonly AdminDbContext _db;
    private NumericUpDown _nudTrialDays = null!;
    private TextBox _txtMonthlyPrice = null!;

    public SettingsForm(AdminDbContext db)
    {
        _db = db;
        Text = "Globální nastavení";
        Size = new Size(360, 200);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        BuildUi();
        LoadSettings();
    }

    private void BuildUi()
    {
        int y = 16, lw = 180, fw = 120;
        Label L(string text) => new Label { Text = text, Left = 12, Top = y, Width = lw, TextAlign = ContentAlignment.MiddleRight, AutoSize = false };

        Controls.Add(L("Trial dní pro nového uživatele:"));
        _nudTrialDays = new NumericUpDown { Left = lw + 20, Top = y, Width = fw, Minimum = 0, Maximum = 365 };
        Controls.Add(_nudTrialDays); y += 36;

        Controls.Add(L("Měsíční cena bez DPH (Kč):"));
        _txtMonthlyPrice = new TextBox { Left = lw + 20, Top = y, Width = fw };
        Controls.Add(_txtMonthlyPrice); y += 40;

        var btnSave = new Button { Text = "Uložit", Left = lw + 20, Top = y, Width = 90 };
        btnSave.Click += Save;
        Controls.Add(btnSave);
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

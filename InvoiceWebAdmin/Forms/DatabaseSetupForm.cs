using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using System.Text.Json;

namespace InvoiceWebAdmin.Forms;

public class DatabaseSetupForm : Form
{
    private TextBox _txtPath = null!;
    private Button _btnBrowse = null!;
    private Button _btnTest = null!;
    private Button _btnOk = null!;
    private Label _lblStatus = null!;

    public string SelectedPath { get; private set; } = "";

    public DatabaseSetupForm(string currentPath)
    {
        Text = "Nastavení cesty k databázi";
        Size = new Size(540, 220);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        BuildUi(currentPath);
    }

    private void BuildUi(string currentPath)
    {
        var lblInfo = new Label
        {
            Text = "Databáze nebyla nalezena. Zadejte cestu k souboru invoice.db:",
            Left = 12, Top = 14, Width = 500, AutoSize = false, Height = 20
        };

        _txtPath = new TextBox
        {
            Left = 12, Top = 40, Width = 390,
            Text = currentPath
        };

        _btnBrowse = new Button { Text = "Procházet…", Left = 410, Top = 38, Width = 100 };
        _btnBrowse.Click += Browse;

        _lblStatus = new Label
        {
            Left = 12, Top = 72, Width = 500, Height = 20,
            ForeColor = Color.Gray, Text = ""
        };

        _btnTest = new Button { Text = "Otestovat připojení", Left = 12, Top = 100, Width = 150 };
        _btnTest.Click += TestConnection;

        _btnOk = new Button
        {
            Text = "Uložit a spustit", Left = 310, Top = 140, Width = 100,
            DialogResult = DialogResult.OK, Enabled = false
        };

        var btnCancel = new Button
        {
            Text = "Zrušit", Left = 420, Top = 140, Width = 90,
            DialogResult = DialogResult.Cancel
        };

        AcceptButton = _btnOk;
        CancelButton = btnCancel;

        Controls.AddRange([lblInfo, _txtPath, _btnBrowse, _lblStatus, _btnTest, _btnOk, btnCancel]);
    }

    private void Browse(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title = "Vyberte soubor databáze",
            Filter = "SQLite databáze (*.db)|*.db|Všechny soubory (*.*)|*.*",
            CheckFileExists = true
        };

        if (!string.IsNullOrWhiteSpace(_txtPath.Text) && File.Exists(Path.GetDirectoryName(_txtPath.Text) ?? ""))
            dlg.InitialDirectory = Path.GetDirectoryName(_txtPath.Text);

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            _txtPath.Text = dlg.FileName;
            SetStatus("", Color.Gray);
            _btnOk.Enabled = false;
        }
    }

    private void TestConnection(object? sender, EventArgs e)
    {
        var path = _txtPath.Text.Trim();
        if (string.IsNullOrEmpty(path))
        {
            SetStatus("Zadejte cestu k databázi.", Color.OrangeRed);
            return;
        }

        if (!File.Exists(path))
        {
            SetStatus("Soubor nebyl nalezen.", Color.OrangeRed);
            _btnOk.Enabled = false;
            return;
        }

        try
        {
            var options = new DbContextOptionsBuilder<AdminDbContext>()
                .UseSqlite($"Data Source={path}")
                .Options;
            using var db = new AdminDbContext(options);
            // Zkusí otevřít připojení – vyhodí výjimku pokud soubor není platná SQLite DB
            db.Database.OpenConnection();
            db.Database.CloseConnection();

            SetStatus("Připojení úspěšné.", Color.Green);
            SelectedPath = path;
            _btnOk.Enabled = true;
        }
        catch (Exception ex)
        {
            SetStatus($"Chyba připojení: {ex.Message}", Color.OrangeRed);
            _btnOk.Enabled = false;
        }
    }

    private void SetStatus(string text, Color color)
    {
        _lblStatus.Text = text;
        _lblStatus.ForeColor = color;
    }

    /// <summary>
    /// Uloží novou cestu do appsettings.json vedle spustitelného souboru.
    /// </summary>
    public static void SavePath(string newPath)
    {
        var settingsFile = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        var json = JsonSerializer.Serialize(
            new { DatabasePath = newPath },
            new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(settingsFile, json);
    }
}

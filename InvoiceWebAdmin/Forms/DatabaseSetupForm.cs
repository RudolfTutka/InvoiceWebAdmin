using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Database;
using System.Text.Json;

namespace InvoiceWebAdmin.Forms;

public partial class DatabaseSetupForm : Form
{
    public string SelectedPath { get; private set; } = "";

    public DatabaseSetupForm(string currentPath)
    {
        InitializeComponent();
        _txtPath.Text = currentPath;
        _txtPath.TextChanged += (_, _) => { SetStatus("", Color.Gray); _btnOk.Enabled = false; };
    }

    private void Browse(object? sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog
        {
            Title = "Vyberte soubor databáze",
            Filter = "SQLite databáze (*.db)|*.db|Všechny soubory (*.*)|*.*",
            CheckFileExists = true
        };

        var dir = Path.GetDirectoryName(_txtPath.Text);
        if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
            dlg.InitialDirectory = dir;

        if (dlg.ShowDialog() == DialogResult.OK)
            _txtPath.Text = dlg.FileName;
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

    public static void SavePath(string newPath)
    {
        var settingsFile = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        var json = JsonSerializer.Serialize(
            new { DatabasePath = newPath },
            new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(settingsFile, json);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Forms;

ApplicationConfiguration.Initialize();

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var dbPath = config["DatabasePath"]
    ?? throw new InvalidOperationException("DatabasePath není nastaven v appsettings.json");

if (!File.Exists(dbPath))
{
    MessageBox.Show(
        $"Databáze nebyla nalezena:\n{dbPath}\n\nZkontrolujte cestu v appsettings.json.",
        "Chyba – databáze nenalezena",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;
}

var options = new DbContextOptionsBuilder<AdminDbContext>()
    .UseSqlite($"Data Source={dbPath}")
    .Options;

using var db = new AdminDbContext(options);
DatabaseInitializer.Initialize(db);

Application.Run(new MainForm(db));

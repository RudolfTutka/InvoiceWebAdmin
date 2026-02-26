using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using InvoiceWebAdmin.Database;
using InvoiceWebAdmin.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var dbPath = config["DatabasePath"] ?? "";

        if (!File.Exists(dbPath))
        {
            using var setupForm = new DatabaseSetupForm(dbPath);
            if (setupForm.ShowDialog() != DialogResult.OK)
                return;

            dbPath = setupForm.SelectedPath;
            DatabaseSetupForm.SavePath(dbPath);
        }

        var options = new DbContextOptionsBuilder<AdminDbContext>()
            .UseSqlite($"Data Source={dbPath}")
            .Options;

        using var db = new AdminDbContext(options);
        DatabaseInitializer.Initialize(db);

        Application.Run(new MainForm(db));
    }
}

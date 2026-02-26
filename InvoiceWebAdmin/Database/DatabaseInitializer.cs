using Microsoft.EntityFrameworkCore;
using InvoiceWebAdmin.Models;

namespace InvoiceWebAdmin.Database;

public static class DatabaseInitializer
{
    public static void Initialize(AdminDbContext context)
    {
        // Vytvoří tabulky které ještě neexistují (neovlivní existující data)
        context.Database.EnsureCreated();

        // Přidat sloupce do existující DB InvoiceWebu (zpětná kompatibilita)
        try { context.Database.ExecuteSqlRaw("ALTER TABLE Users ADD COLUMN IsActive INTEGER NOT NULL DEFAULT 1"); } catch { }
        try { context.Database.ExecuteSqlRaw(@"
            CREATE TABLE IF NOT EXISTS SubscriptionPeriods (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                [From] TEXT NOT NULL,
                [To] TEXT NOT NULL,
                Note TEXT NULL,
                CreatedAt TEXT NOT NULL DEFAULT (datetime('now')),
                FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
            )"); } catch { }
        try { context.Database.ExecuteSqlRaw(@"
            CREATE TABLE IF NOT EXISTS AdminSettings (
                Id INTEGER PRIMARY KEY,
                TrialDays INTEGER NOT NULL DEFAULT 14,
                MonthlyPriceExclVat TEXT NOT NULL DEFAULT '0'
            )"); } catch { }

        // Zajistit výchozí záznam AdminSettings
        if (!context.AdminSettings.Any())
        {
            context.AdminSettings.Add(new AdminSettings { Id = 1, TrialDays = 14, MonthlyPriceExclVat = 0 });
            context.SaveChanges();
        }
    }
}

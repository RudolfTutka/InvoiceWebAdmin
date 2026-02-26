namespace InvoiceWebAdmin.Models;

/// <summary>
/// Globální nastavení – vždy jeden řádek (Id = 1).
/// </summary>
public class AdminSettings
{
    public int Id { get; set; } = 1;

    /// <summary>Počet dnů zdarma pro nového uživatele.</summary>
    public int TrialDays { get; set; } = 14;

    /// <summary>Měsíční cena bez DPH v Kč.</summary>
    public decimal MonthlyPriceExclVat { get; set; } = 0;
}

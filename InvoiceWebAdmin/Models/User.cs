using System.ComponentModel.DataAnnotations;

namespace InvoiceWebAdmin.Models;

public class User
{
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string Ico { get; set; } = "";

    [Required, MaxLength(200)]
    public string Email { get; set; } = "";

    [Required]
    public string PasswordHash { get; set; } = "";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public CompanySettings? CompanySettings { get; set; }
    public ICollection<SubscriptionPeriod> SubscriptionPeriods { get; set; } = new List<SubscriptionPeriod>();
}

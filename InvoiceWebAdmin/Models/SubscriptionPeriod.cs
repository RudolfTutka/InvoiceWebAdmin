using System.ComponentModel.DataAnnotations;

namespace InvoiceWebAdmin.Models;

public class SubscriptionPeriod
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public DateOnly From { get; set; }
    public DateOnly To { get; set; }

    [MaxLength(500)]
    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

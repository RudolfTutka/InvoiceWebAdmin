using System.ComponentModel.DataAnnotations;

namespace InvoiceWebAdmin.Models;

public class CompanySettings
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    [MaxLength(20)]
    public string? Ico { get; set; }

    [MaxLength(200)]
    public string? CompanyName { get; set; }

    [MaxLength(20)]
    public string? Dic { get; set; }

    [MaxLength(200)]
    public string? Street { get; set; }

    [MaxLength(20)]
    public string? BuildingNumber { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(10)]
    public string? ZipCode { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    public DateTime UpdatedAt { get; set; }
}

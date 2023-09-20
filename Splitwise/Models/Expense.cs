using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Splitwise.Models;

[PrimaryKey(nameof(Id))]
public class Expense
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public string[] PaidBy { get; set; }
    [Required]
    public string[] OwedBy { get; set; }
    [Required]
    public DateTime ProcessedOn { get; set; }
}
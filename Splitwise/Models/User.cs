using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Splitwise.Models;

[PrimaryKey("Id","Email")]
public class User
{
    [Required]
    public string Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }    
    [Required]
    public string Password { get; set; }    
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}
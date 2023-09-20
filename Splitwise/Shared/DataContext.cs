using Microsoft.EntityFrameworkCore;
using Splitwise.Models;

namespace Splitwise.Shared;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> contextOptions):base(contextOptions)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }
}
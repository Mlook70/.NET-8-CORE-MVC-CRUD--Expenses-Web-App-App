using Microsoft.EntityFrameworkCore;

//Abdulmalek Akel

namespace ExpensesWebMVC.Models
{
    public class ExpensesWebMVCDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public ExpensesWebMVCDbContext(DbContextOptions<ExpensesWebMVCDbContext> options)
            : base(options)
        {
            
        }
    }
}

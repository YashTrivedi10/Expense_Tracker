using Expence_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Expence_tracker
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Expence_tracker.Models.Limit> Limit { get; set; }

        public DbSet<Expence_tracker.Models.expense> expense { get; set; }
    }
}

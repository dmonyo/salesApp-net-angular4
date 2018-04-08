using System.Data.Entity;

namespace MVCSalesAPI.Models
{

    public class ApplicationBdContext : DbContext
    {
        public DbSet<Sales> Sales { get; set; }

        public ApplicationBdContext()
                : base("DefaultConnection")
        {
        }

        public static ApplicationBdContext Create()
        {
            return new ApplicationBdContext();
        }
    }
}
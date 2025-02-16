using System.Data.Entity; // Entity framework kütüphanesi

namespace NetFrameworkMVC.Models
{
	public class UyeContext : DbContext
	{
        public DbSet<Uye> Uyeler { get; set; }
    }
}
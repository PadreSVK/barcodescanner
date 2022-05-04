using Microsoft.EntityFrameworkCore;

namespace Barcode.DAL
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<Barcode> BarCodes { get; set; }
    }
}

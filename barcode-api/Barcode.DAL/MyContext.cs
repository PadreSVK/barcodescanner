using Microsoft.EntityFrameworkCore;

namespace Barcode.DAL
{
    public class MyContext : DbContext
    {
        public DbSet<BarCode> BarCodes { get; set; }
    }
}

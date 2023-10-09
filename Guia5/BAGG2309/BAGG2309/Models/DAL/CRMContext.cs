using Microsoft.EntityFrameworkCore;
using BAGG2309.Models.EN;

namespace BAGG2309.Models.DAL
{
    public class CRMContext : DbContext
    {

        public CRMContext(DbContextOptions<CRMContext> options) : base(options)
        {
        }

        public DbSet<TableBAGG> TableBAGG { get; set; }
    }
}

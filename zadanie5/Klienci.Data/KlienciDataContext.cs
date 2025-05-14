using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klienci.Data
{
    public class KlienciDataContext : DbContext
    {
        public KlienciDataContext(DbContextOptions<KlienciDataContext> options)  :  base(options)
        {
        }

        public KlienciDataContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
           
        }
        public DbSet<Klienci> Klijentella { get; set; }

       
    }
}

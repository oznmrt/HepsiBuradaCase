using HP.BACKEND.ENTITIES.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.REPOSITORY.Concrete.EntityFramework
{
    public partial class HPCaseDBContext : DbContext
    {
        public HPCaseDBContext()
        {
        }

        public HPCaseDBContext(DbContextOptions<HPCaseDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                   .AddJsonFile("appsettings.json")
                                                   .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("HPCaseDB"));
            }
        }
    }
}

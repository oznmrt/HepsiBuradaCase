using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP.BACKEND.REPOSITORY.Concrete.EntityFramework
{
    class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<HPCaseDBContext>
    {
        public HPCaseDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HPCaseDBContext>();
            var connectionString = "Server=DESKTOP-HE74LDM\\SQLEXPRESS;Database=HPCase;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
            return new HPCaseDBContext(builder.Options);
        }
    }
}

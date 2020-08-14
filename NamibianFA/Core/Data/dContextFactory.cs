using NamibianFA.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamibianFA.Core.Data
{
    public class dContextFactory : IDesignTimeDbContextFactory<dContext>
    {
        public dContext CreateDbContext(string[] options)
        {
            var builder = new DbContextOptionsBuilder<dContext>();
            builder.UseSqlServer(DatabaseSettings.LocalConnection, option => option.EnableRetryOnFailure());
            return new dContext(builder.Options);
        }
    }
}

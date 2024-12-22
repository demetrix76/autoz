using autotaz.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotaz
{
    internal static class ContextFactory
    {
        private static IDbContextFactory<ATContext> _factory = 
            new PooledDbContextFactory<ATContext>(
                    new DbContextOptionsBuilder<ATContext>()
                    .UseNpgsql("Database=autotaz;Host=localhost;Username=postgres;Password=123")
                    .Options
                );

        internal static ATContext make()
        {
            return _factory.CreateDbContext();
        }
        
    }
}

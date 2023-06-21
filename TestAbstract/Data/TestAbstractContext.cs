using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAbstract.Models;

namespace TestAbstract.Data
{
    public class TestAbstractContext : DbContext
    {
        public TestAbstractContext (DbContextOptions<TestAbstractContext> options)
            : base(options)
        {
        }

        public DbSet<TestAbstract.Models.TestD> TestD { get; set; } = default!;
    }
}

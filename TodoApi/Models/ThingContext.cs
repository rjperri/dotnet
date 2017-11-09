using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace TodoApi.Models
{
    public class ThingContext : DbContext
    {
        public ThingContext(DbContextOptions<ThingContext> options) : base(options)
        {
        }

        public DbSet<Thing> Things { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WeEatRamen.Core.Models;

namespace WeEatRamen.Data.Infrastructure.Context
{
    public class WeEatRamenDbContext : DbContext
    {
        public WeEatRamenDbContext(DbContextOptions<WeEatRamenDbContext> options)
            : base(options) { }    

        public DbSet<Shop> Shops { get; set; }
    }
}

using Begge.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Begge.Data
{
    class BeggeDBContext : DbContext
    {
        public BeggeDBContext()
        {

        }

        public BeggeDBContext(DbContextOptions<BeggeDBContext> options)
             : base(options)
        {

        }
        public virtual DbSet<Begger> Beggers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

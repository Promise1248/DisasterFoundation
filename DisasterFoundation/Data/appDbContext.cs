using DisasterFoundation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DisasterFoundation.Data
{
    public class appDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<users> user { get; set; }
        public DbSet<Donations> donations { get; set; }
        public DbSet<Disasters> Disasters { get; set; }
        public DbSet<BoughtGoods> BoughtGoods { get; set; }
    }
}

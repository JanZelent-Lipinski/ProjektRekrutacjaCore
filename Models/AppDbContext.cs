using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjektRekrutacjaCore.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Asortyment> Asortymenty { get; set; }
        public DbSet<StanMagazynowy> StanyMagazynowe { get; set; }
        public DbSet<JednostkaMiary> JednostkiMiar { get; set; }
        public DbSet<JednostkaMiaryAsortymentu> JednostkiMiarAsortymentow { get; set; }
        public DbSet<KodyKreskowe> KodyKreskowe { get; set; }
        public DbSet<Waluta> Waluty { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
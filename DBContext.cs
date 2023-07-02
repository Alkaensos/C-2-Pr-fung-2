using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C__2_Prüfung_2.Model;

namespace C__2_Prüfung_2
{
    public class MyDbContext : DbContext
    {
        public DbSet<Fussballspieler> Fussballspieler { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MeineDB;Trusted_Connection=True;");
        }
    }
}

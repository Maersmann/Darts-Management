using Darts.Data.Model;
using Darts.Data.Model.KonvertierungEntitys;
using Darts.Data.Model.SpielerEntitys;
using Darts.Data.Model.TrainingEntitys;
using Darts.Data.Model.UserEntitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Data.Infrastructure
{
    public class Context : DbContext
    {

        //public DbSet<Spieler> Spieler { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Konvertierung> Konvertierungen { get; set; }
        public DbSet<Spieler> Spieler { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingSpieler> TrainingSpielers { get; set; }
        public DbSet<Bestleistung> Bestleistungen { get; set; }

        public Context() : base() { Database.Migrate(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(VersionContextConnection.GetDatabaseConnectionstring());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using ForumData.Repositories.Configuration;
using ForumData.Repositories.Seeding;

namespace ForumData.Entities
{
    public class GemeenteForumDbContext : DbContext
    {
        //PROPERTIES
        // unitTesting? --> zie swimlane "Brainstorm"
        //private bool TestMode = false;

        //CONSTRUCTOR
        public GemeenteForumDbContext(DbContextOptions<GemeenteForumDbContext> options) : base(options) { }
        public GemeenteForumDbContext() { }

        //DBSets
        public DbSet<Adres> Adressen { get; set; }
        public DbSet<Afdeling> Afdelingen { get; set; }
        public DbSet<Bericht> Berichten { get; set; }
        public DbSet<HoofdBericht> HoofdBerichten { get; set; }
        public DbSet<Antwoord> Antwoorden { get; set; }
        public DbSet<BerichtThema> BerichtThemas { get; set; }
        public DbSet<Gemeente> Gemeenten { get; set; }
        public DbSet<Interesse> Interesses { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Profiel> Profielen { get; set; }
        public DbSet<Medewerker> Medewerkers { get; set; }
        public DbSet<ProfielInteresse> ProfielenInteresses { get; set; }
        public DbSet<Provincie> Provincies { get; set; }
        public DbSet<Straat> Straten { get; set; }
        public DbSet<Taal> Talen { get; set; }

        //CONFIGURING DTABASE CONECTION
        // testmode ? + Sql properties (maxBatchSize) --> zie swimlane "Brainstorm"
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //    }
        //    else
        //    {
        //        testMode = true;
        //    }
        //}



        //CONFIGRUATION CLASSES
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configuration
            modelBuilder.ApplyConfiguration(new AdresConfiguration());
            modelBuilder.ApplyConfiguration(new AfdelingConfiguration());

            //Bericht
            modelBuilder.ApplyConfiguration(new BerichtConfiguration());
            modelBuilder.ApplyConfiguration(new HoofdBerichtConfiguration());
            modelBuilder.ApplyConfiguration(new AntwoordConfiguration());

            modelBuilder.ApplyConfiguration(new BerichtThemaConfiguration());
            modelBuilder.ApplyConfiguration(new GemeenteConfiguration());
            modelBuilder.ApplyConfiguration(new InteresseConfiguration());

            //Persoon
            modelBuilder.ApplyConfiguration(new PersoonConfiguration());
            modelBuilder.ApplyConfiguration(new MedewerkerConfiguration());
            modelBuilder.ApplyConfiguration(new ProfielConfiguration());

            modelBuilder.ApplyConfiguration(new ProvincieConfiguration());
            modelBuilder.ApplyConfiguration(new ProfielInteresseConfiguration());
            modelBuilder.ApplyConfiguration(new ProvincieConfiguration());
            modelBuilder.ApplyConfiguration(new StraatConfiguration());
            modelBuilder.ApplyConfiguration(new TaalConfiguration());

            //seeding
            //if (!testMode)
            //{
                modelBuilder.ApplyConfiguration(new TaalSeeding());
                modelBuilder.ApplyConfiguration(new ProvincieSeeding());
                modelBuilder.ApplyConfiguration(new GemeenteSeeding());
                modelBuilder.ApplyConfiguration(new StraatSeeding());
                modelBuilder.ApplyConfiguration(new AdresSeeding());
                modelBuilder.ApplyConfiguration(new AfdelingSeeding());
                modelBuilder.ApplyConfiguration(new BerichtThemaSeeding());
                modelBuilder.ApplyConfiguration(new InteresseSeeding());
                modelBuilder.ApplyConfiguration(new MedewerkerSeeding());
            //}
        }
    }
}

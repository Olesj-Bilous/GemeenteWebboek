
using Microsoft.EntityFrameworkCore;

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
        public DbSet<BerichtType> BerichtTypes { get; set; }
        public DbSet<Gemeente> Gemeenten { get; set; }
        public DbSet<Interesse> Interesses { get; set; }
        public DbSet<Persoon> Personen { get; set; }
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
            //modelBuilder.ApplyConfiguration(new AdresConfiguration());
            //modelBuilder.ApplyConfiguration(new AfdelingConfiguration());
            //modelBuilder.ApplyConfiguration(new BerichtConfiguratie());
            //modelBuilder.ApplyConfiguration(new BerichtTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new GemeenteConfiguration());
            //modelBuilder.ApplyConfiguration(new InteresseSoortConfiguration());
            //modelBuilder.ApplyConfiguration(new PersoonConfiguratie());
            //modelBuilder.ApplyConfiguration(new ProfielInteresseConfiguration());
            //modelBuilder.ApplyConfiguration(new ProvincieConfiguration());
            //modelBuilder.ApplyConfiguration(new StraatConfiguration());
            //modelBuilder.ApplyConfiguration(new TaalConfiguration());

            ////seeding
            //if (!testMode)
            //{

            //    modelBuilder.ApplyConfiguration(new AdresSeeding());
            //    modelBuilder.ApplyConfiguration(new AfdelingSeeding());
            //    modelBuilder.ApplyConfiguration(new BerichtTypeSeeding());
            //    modelBuilder.ApplyConfiguration(new GemeenteSeeding());
            //    modelBuilder.ApplyConfiguration(new InteresseSoortSeeding());
            //    modelBuilder.ApplyConfiguration(new BeheerderSeeding());
            //    modelBuilder.ApplyConfiguration(new ProvincieSeeding());
            //    modelBuilder.ApplyConfiguration(new StraatSeeding());
            //    modelBuilder.ApplyConfiguration(new TaalSeeding());
            //    modelBuilder.ApplyConfiguration(new ProfielSeeding());

            //}
        }
    }
}

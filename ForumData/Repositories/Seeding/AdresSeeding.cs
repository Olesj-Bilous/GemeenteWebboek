using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ForumData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories.Seeding
{
    public class AdresSeeding : IEntityTypeConfiguration<Adres>
    {
        public void Configure(EntityTypeBuilder<Adres> builder)
        {
            builder.HasData(
                new 
                {
                    AdresId = 1,
                    StraatId = 1,
                    HuisNr = "7",
                    #nullable enable
                    BusNr = (string?)null,
                    #nullable disable
                },
                new 
                { 
                    AdresId = 2, 
                    StraatId = 1, 
                    HuisNr = "90", 
                    BusNr = "-" 
                },
                new
                { 
                    AdresId = 3,
                    StraatId = 2,
                    HuisNr = "50",
                    BusNr = "6"
                }
            );
        }
    }
}

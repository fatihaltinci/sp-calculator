using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPCalculator.Entity.Entities;

namespace SPCalculator.Data.Mappings
{
    public class FunctionMap : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.HasData(new Function
            {
                Id = Guid.Parse("C33F282A-664B-4042-B967-F544ECF86B79"),
                FunctionName = "Ekran Ekleme",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            },
            
            new Function
            {
                Id = Guid.Parse("174F50FE-10CC-4B07-943E-023B0A0A47C6"),
                FunctionName = "Ekran Güncelleme",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            }  
            
            );
        }
    }
}

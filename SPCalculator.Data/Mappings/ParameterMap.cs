using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPCalculator.Entity.Entities;

namespace SPCalculator.Data.Mappings
{
    public class ParameterMap : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.HasData(new Parameter
            {
                Id = Guid.Parse("3C22B6B0-45C7-455E-9BCA-DA2C051B5011"),
                ParameterName = "Ekran Ekleme",
                ParameterDesc = "Pop-up Ekran Ekleme",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                ParameterPoint = 4
            },

            new Parameter
            {
                Id = Guid.Parse("4461ADD9-168B-468F-8D8A-BC333690D8B3"),
                ParameterName = "Ekran Güncelleme",
                ParameterDesc = "Pop-up Ekran Güncelleme",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                ParameterPoint = 2
            }

            );
        }
    }
}

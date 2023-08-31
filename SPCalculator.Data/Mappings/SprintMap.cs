using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPCalculator.Entity.Entities;

namespace SPCalculator.Data.Mappings
{
    public class SprintMap : IEntityTypeConfiguration<Sprint>
    {
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder.HasData(new Sprint
            {
                Id = Guid.NewGuid(),
                SprintName = "Sprint 1",
                VersionInfo = "EES - 4.13-2023.R10 05/30",
                ItemNo = "EES-48940",
                DifficultyLevel = "Easy",
                BasePoint = 0.0,
                ParameterId = Guid.Parse("3C22B6B0-45C7-455E-9BCA-DA2C051B5011"),
                FunctionId = Guid.Parse("C33F282A-664B-4042-B967-F544ECF86B79"),
                CreatedDate = DateTime.Now,
            },

            new Sprint
            {
                Id = Guid.NewGuid(),
                SprintName = "Sprint 2",
                VersionInfo = "EES - 4.13-2023.R10 05/30",
                ItemNo = "EES-48940",
                DifficultyLevel = "Easy",
                BasePoint = 0.0,
                ParameterId = Guid.Parse("4461ADD9-168B-468F-8D8A-BC333690D8B3"),
                FunctionId = Guid.Parse("174F50FE-10CC-4B07-943E-023B0A0A47C6"),
                CreatedDate = DateTime.Now,
            }
            
            );
        }
    }
}

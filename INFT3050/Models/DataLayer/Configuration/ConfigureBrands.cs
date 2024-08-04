using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFT3050.Models
{
    internal class ConfigureBrands : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> entity)
        {

            
                entity.HasData(
                         new Brand { BrandId = 1, BrandName = "BrandA", ImagePath = "path/to/imageA" },
                       new Brand { BrandId = 2, BrandName = "BrandB", ImagePath = "path/to/imageB" }
                    );



        }
    }
}

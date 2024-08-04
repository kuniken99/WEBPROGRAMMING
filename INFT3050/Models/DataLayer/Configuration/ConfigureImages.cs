using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

//to make the context class manageable and readable
//makes it easier to seed or initialize the database

namespace INFT3050.Models
{
    internal class ConfigureImages : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> entity)
        {
            // remove cascading delete with Genre
            entity.HasOne(im => im.Item)
                .WithMany(i => i.Images)
                .OnDelete(DeleteBehavior.Restrict);

            //seed initial data
            entity.HasData(
                new Image
                {
                    ImageID = 1,
                    ItemID = 1,
                    ImagePath = "fish_oil.png"
                },
                new Image
                {
                    ImageID = 2,
                    ItemID = 2,
                    ImagePath = "eye_lutein.png"
                },
                new Image
                {
                    ImageID = 3,
                    ItemID = 3,
                    ImagePath = "vitamin_c.png"
                },
                new Image
                {
                    ImageID = 4,
                    ItemID = 4,
                    ImagePath = "product4.jpg"
                },
                new Image
                {
                    ImageID = 5,
                    ItemID = 5,
                    ImagePath = "product5.jpg"
                },
                new Image
                {
                    ImageID = 6,
                    ItemID = 6,
                    ImagePath = "product6.jpg"
                },
                new Image
                {
                    ImageID = 7,
                    ItemID = 7,
                    ImagePath = "product7.jpg"
                },
                new Image
                {
                    ImageID = 8,
                    ItemID = 8,
                    ImagePath = "product8.jpg"
                },
                new Image
                {
                    ImageID = 9,
                    ItemID = 9,
                    ImagePath = "product9.jpg"
                },
                new Image
                {
                    ImageID = 10,
                    ItemID = 10,
                    ImagePath = "product10.jpg"
                },
                new Image
                {
                    ImageID = 11,
                    ItemID = 11,
                    ImagePath = "product11.jpg"
                },
                new Image
                {
                    ImageID = 12,
                    ItemID = 12,
                    ImagePath = "product12.jpg"
                },
                new Image
                {
                    ImageID = 13,
                    ItemID = 13,
                    ImagePath = "product13.jpg"
                },
                new Image
                {
                    ImageID = 14,
                    ItemID = 14,
                    ImagePath = "product14.jpg"
                },
                new Image
                {
                    ImageID = 15,
                    ItemID = 15,
                    ImagePath = "product15.jpg"
                },
                new Image
                {
                    ImageID = 16,
                    ItemID = 16,
                    ImagePath = "product16.jpg"
                },
                new Image
                {
                    ImageID = 17,
                    ItemID = 17,
                    ImagePath = "product17.jpg"
                },
                new Image
                {
                    ImageID = 18,
                    ItemID = 18,
                    ImagePath = "product18.jpg"
                },
                new Image
                {
                    ImageID = 19,
                    ItemID = 19,
                    ImagePath = "product19.jpg"
                },
                new Image
                {
                    ImageID = 20,
                    ItemID = 20,
                    ImagePath = "product20.jpg"
                },
                new Image
                {
                    ImageID = 21,
                    ItemID = 21,
                    ImagePath = "product21.jpg"
                },
                new Image
                {
                    ImageID = 22,
                    ItemID = 22,
                    ImagePath = "product22.jpg"
                },
                new Image
                {
                    ImageID = 23,
                    ItemID = 23,
                    ImagePath = "product23.jpg"
                },
                new Image
                {
                    ImageID = 24,
                    ItemID = 24,
                    ImagePath = "product24.jpg"
                },
                new Image
                {
                    ImageID = 25,
                    ItemID = 25,
                    ImagePath = "product25.jpg"
                },
                new Image
                {
                    ImageID = 26,
                    ItemID = 26,
                    ImagePath = "product26.jpg"
                },
                new Image
                {
                    ImageID = 27,
                    ItemID = 27,
                    ImagePath = "product27.jpg"
                },
                new Image
                {
                    ImageID = 28,
                    ItemID = 28,
                    ImagePath = "product28.jpg"
                },
                new Image
                {
                    ImageID = 29,
                    ItemID = 29,
                    ImagePath = "product29.jpg"
                },
                new Image
                {
                    ImageID = 30,
                    ItemID = 30,
                    ImagePath = "product30.jpg"
                },
                new Image
                {
                    ImageID = 31,
                    ItemID = 31,
                    ImagePath = "product31.jpg"
                },
                new Image
                {
                    ImageID = 32,
                    ItemID = 32,
                    ImagePath = "product32.jpg"
                },
                new Image
                {
                    ImageID = 33,
                    ItemID = 33,
                    ImagePath = "product33.jpg"
                },
                new Image
                {
                    ImageID = 34,
                    ItemID = 34,
                    ImagePath = "product34.jpg"
                },
                new Image
                {
                    ImageID = 35,
                    ItemID = 35,
                    ImagePath = "product35.jpg"
                },
                new Image
                {
                    ImageID = 36,
                    ItemID = 36,
                    ImagePath = "product36.jpg"
                },
                new Image
                {
                    ImageID = 37,
                    ItemID = 37,
                    ImagePath = "product37.jpg"
                },
                new Image
                {
                    ImageID = 38,
                    ItemID = 38,
                    ImagePath = "product38.jpg"
                },
                new Image
                {
                    ImageID = 39,
                    ItemID = 39,
                    ImagePath = "product39.jpg"
                },
                new Image
                {
                    ImageID = 40,
                    ItemID = 40,
                    ImagePath = "product40.jpg"
                }
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFT3050.Models
{
    internal class ConfigureItems : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> entity)
        {
            // Seed initial data
            entity.HasData(
                new Item
                {
                    ItemID = 1,
                    ItemName = "Omega-3 Fish Oil 1000mg 60s",
                    VitaminType = "Fish Oil",
                    Description = "Ocean Health Omega 3 Fish Oil 1000mg is a 100% natural dietary supplement that is a rich source of the Omega 3 essential fatty acids EPA and DHA derived from deep water fish.",
                    Quantity = 10,
                    Category = "Heart Health",
                    Price = 24.53,
                    Company = "Ocean Health",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 2,
                    ItemName = "Eye Lutein Gummy",
                    VitaminType = "Others",
                    Description = "Holistic Way Children's Eye Lutein Gummy may help to support healthy vision in children. Lutein is a potent antioxidant which helps to filter harmful blue light.",
                    Quantity = 2,
                    Category = "Eye Health",
                    Price = 39.80,
                    Company = "Holistic Way",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 3,
                    ItemName = "Vitamin C 500mg 60s",
                    VitaminType = "Vitamin C",
                    Description = "Holistic Way Vitamin C supports healthy immune system functioning, eases cold, flu and sore throat and stimulates collagen growth.",
                    Quantity = 15,
                    Category = "Immune System",
                    Price = 26.00,
                    Company = "Holistic Way",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 4,
                    ItemName = "Centrum Multivitamin",
                    VitaminType = "Multivitamins",
                    Description = "Centrum Multivitamins provide essential vitamins and minerals to help support your overall health and well-being.",
                    Quantity = 30,
                    Category = "Overall Health",
                    Price = 50.00,
                    Company = "Centrum",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 5,
                    ItemName = "Calcium 600mg + Vitamin D3",
                    VitaminType = "Calcium",
                    Description = "Nature Made Calcium 600mg with Vitamin D3 helps support bone health and muscle function.",
                    Quantity = 20,
                    Category = "Bone Health",
                    Price = 22.00,
                    Company = "Nature Made",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 6,
                    ItemName = "Probiotic 10",
                    VitaminType = "Probiotics",
                    Description = "Nature's Bounty Probiotic 10 contains 10 unique probiotic strains to support digestive health.",
                    Quantity = 15,
                    Category = "Digestive Health",
                    Price = 30.00,
                    Company = "Nature's Bounty",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 7,
                    ItemName = "CoQ10 200mg",
                    VitaminType = "CoQ10",
                    Description = "Nature's Bounty CoQ10 200mg supports heart health and energy production.",
                    Quantity = 10,
                    Category = "Heart Health",
                    Price = 40.00,
                    Company = "Nature's Bounty",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 8,
                    ItemName = "Biotin 5000mcg",
                    VitaminType = "Biotin",
                    Description = "Nature's Bounty Biotin supports healthy hair, skin, and nails.",
                    Quantity = 25,
                    Category = "Beauty",
                    Price = 15.00,
                    Company = "Nature's Bounty",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 9,
                    ItemName = "Vitamin D3 1000 IU",
                    VitaminType = "Vitamin D",
                    Description = "Nature Made Vitamin D3 1000 IU supports bone and immune health.",
                    Quantity = 20,
                    Category = "Bone Health",
                    Price = 15.00,
                    Company = "Nature Made",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 10,
                    ItemName = "Fish Oil 1200mg",
                    VitaminType = "Fish Oil",
                    Description = "Nordic Naturals Fish Oil 1200mg supports heart health and cognitive function.",
                    Quantity = 22,
                    Category = "Heart Health",
                    Price = 25.00,
                    Company = "Nordic Naturals",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 11,
                    ItemName = "Curcumin 200mg",
                    VitaminType = "Curcumin",
                    Description = "Nordic Naturals Curcumin 200mg supports joint health and inflammatory response.",
                    Quantity = 15,
                    Category = "Joint Health",
                    Price = 35.00,
                    Company = "Nordic Naturals",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 12,
                    ItemName = "Probiotic Gummies",
                    VitaminType = "Probiotics",
                    Description = "Nordic Naturals Probiotic Gummies support digestive health.",
                    Quantity = 25,
                    Category = "Digestive Health",
                    Price = 20.00,
                    Company = "Nordic Naturals",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 13,
                    ItemName = "Collagen Peptides",
                    VitaminType = "Collagen",
                    Description = "Vital Proteins Collagen Peptides support skin, hair, nail, and joint health.",
                    Quantity = 20,
                    Category = "Beauty",
                    Price = 40.00,
                    Company = "Vital Proteins",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 14,
                    ItemName = "Vitamin C Gummies",
                    VitaminType = "Vitamin C",
                    Description = "Vitafusion Vitamin C Gummies support immune system health.",
                    Quantity = 30,
                    Category = "Immune System",
                    Price = 15.00,
                    Company = "Vitafusion",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 15,
                    ItemName = "Women's Multivitamin",
                    VitaminType = "Multivitamins",
                    Description = "Vitafusion Women's Multivitamin supports overall women's health.",
                    Quantity = 35,
                    Category = "Overall Health",
                    Price = 25.00,
                    Company = "Vitafusion",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 16,
                    ItemName = "Melatonin 5mg",
                    VitaminType = "Melatonin",
                    Description = "Vitafusion Melatonin 5mg supports healthy sleep patterns.",
                    Quantity = 28,
                    Category = "Sleep Health",
                    Price = 10.00,
                    Company = "Vitafusion",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 17,
                    ItemName = "Vitamin B Complex",
                    VitaminType = "Vitamin B",
                    Description = "Solgar Vitamin B Complex supports energy metabolism.",
                    Quantity = 20,
                    Category = "Energy",
                    Price = 20.00,
                    Company = "Solgar",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 18,
                    ItemName = "Magnesium Citrate",
                    VitaminType = "Magnesium",
                    Description = "Solgar Magnesium Citrate supports nerve and muscle function.",
                    Quantity = 18,
                    Category = "Overall Health",
                    Price = 15.00,
                    Company = "Solgar",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 19,
                    ItemName = "Folate 400mcg",
                    VitaminType = "Folate",
                    Description = "Solgar Folate 400mcg supports heart health and cellular function.",
                    Quantity = 22,
                    Category = "Heart Health",
                    Price = 12.00,
                    Company = "Solgar",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 20,
                    ItemName = "Vitamin E 200 IU",
                    VitaminType = "Vitamin E",
                    Description = "Solgar Vitamin E 200 IU supports immune and skin health.",
                    Quantity = 20,
                    Category = "Immune System",
                    Price = 18.00,
                    Company = "Solgar",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 21,
                    ItemName = "Vitamin K2 45mcg",
                    VitaminType = "Vitamin K",
                    Description = "Solgar Vitamin K2 45mcg supports bone and heart health.",
                    Quantity = 15,
                    Category = "Bone Health",
                    Price = 20.00,
                    Company = "Solgar",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 22,
                    ItemName = "Digestive Enzymes",
                    VitaminType = "Digestive Enzymes",
                    Description = "Garden of Life Digestive Enzymes support healthy digestion.",
                    Quantity = 25,
                    Category = "Digestive Health",
                    Price = 22.00,
                    Company = "Garden of Life",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 23,
                    ItemName = "Collagen Peptides Powder",
                    VitaminType = "Collagen",
                    Description = "Garden of Life Collagen Peptides Powder supports healthy skin, hair, nails, and joints.",
                    Quantity = 20,
                    Category = "Beauty",
                    Price = 45.00,
                    Company = "Garden of Life",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 24,
                    ItemName = "Men's Multivitamin",
                    VitaminType = "Multivitamins",
                    Description = "Garden of Life Men's Multivitamin supports overall men's health.",
                    Quantity = 35,
                    Category = "Overall Health",
                    Price = 30.00,
                    Company = "Garden of Life",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 25,
                    ItemName = "Turmeric 500mg",
                    VitaminType = "Turmeric",
                    Description = "Garden of Life Turmeric 500mg supports joint health and inflammatory response.",
                    Quantity = 18,
                    Category = "Joint Health",
                    Price = 28.00,
                    Company = "Garden of Life",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 26,
                    ItemName = "Vitamin C 1000mg",
                    VitaminType = "Vitamin C",
                    Description = "Garden of Life Vitamin C 1000mg supports immune system health.",
                    Quantity = 30,
                    Category = "Immune System",
                    Price = 20.00,
                    Company = "Garden of Life",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 27,
                    ItemName = "Fish Oil 1000mg",
                    VitaminType = "Fish Oil",
                    Description = "Spring Valley Fish Oil 1000mg supports heart and brain health.",
                    Quantity = 20,
                    Category = "Heart Health",
                    Price = 28.00,
                    Company = "Spring Valley",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 28,
                    ItemName = "Probiotic 50 Billion CFU",
                    VitaminType = "Probiotics",
                    Description = "Spring Valley Probiotic 50 Billion CFU supports digestive and immune health.",
                    Quantity = 25,
                    Category = "Digestive Health",
                    Price = 40.00,
                    Company = "Spring Valley",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 29,
                    ItemName = "Elderberry Gummies",
                    VitaminType = "Elderberry",
                    Description = "Nature's Way Elderberry Gummies support immune system health.",
                    Quantity = 30,
                    Category = "Immune System",
                    Price = 25.00,
                    Company = "Nature's Way",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 30,
                    ItemName = "Ashwagandha 500mg",
                    VitaminType = "Herbal",
                    Description = "Nature's Way Ashwagandha 500mg supports stress relief and energy.",
                    Quantity = 20,
                    Category = "Stress Relief",
                    Price = 20.00,
                    Company = "Nature's Way",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 31,
                    ItemName = "Vitamin D3 2000 IU",
                    VitaminType = "Vitamin D",
                    Description = "Nature's Way Vitamin D3 2000 IU supports bone and immune health.",
                    Quantity = 22,
                    Category = "Bone Health",
                    Price = 18.00,
                    Company = "Nature's Way",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 32,
                    ItemName = "Turmeric Curcumin 1000mg",
                    VitaminType = "Turmeric",
                    Description = "Nature's Way Turmeric Curcumin 1000mg supports joint health and inflammatory response.",
                    Quantity = 18,
                    Category = "Joint Health",
                    Price = 30.00,
                    Company = "Nature's Way",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 33,
                    ItemName = "Ginkgo Biloba 120mg",
                    VitaminType = "Herbal",
                    Description = "Nature's Way Ginkgo Biloba 120mg supports brain function and mental alertness.",
                    Quantity = 15,
                    Category = "Brain Health",
                    Price = 22.00,
                    Company = "Nature's Way",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 34,
                    ItemName = "Probiotic 25 Billion CFU",
                    VitaminType = "Probiotics",
                    Description = "Lake Avenue Probiotic 25 Billion CFU supports digestive health and immune function.",
                    Quantity = 25,
                    Category = "Digestive Health",
                    Price = 35.00,
                    Company = "Lake Avenue",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 35,
                    ItemName = "Vitamin C with Rose Hips 1000mg",
                    VitaminType = "Vitamin C",
                    Description = "Nature's Bounty Vitamin C with Rose Hips 1000mg supports immune system health.",
                    Quantity = 30,
                    Category = "Immune System",
                    Price = 15.00,
                    Company = "Nature's Bounty",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 36,
                    ItemName = "Zinc 50mg",
                    VitaminType = "Zinc",
                    Description = "Nature's Bounty Zinc 50mg supports immune system health.",
                    Quantity = 20,
                    Category = "Immune System",
                    Price = 12.00,
                    Company = "Nature's Bounty",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 37,
                    ItemName = "Vitamin B12 1000mcg",
                    VitaminType = "Vitamin B",
                    Description = "Nature's Bounty Vitamin B12 1000mcg supports energy metabolism and nervous system health.",
                    Quantity = 22,
                    Category = "Energy",
                    Price = 18.00,
                    Company = "Nature's Bounty",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 38,
                    ItemName = "Iron 65mg",
                    VitaminType = "Iron",
                    Description = "Nature's Bounty Iron 65mg supports red blood cell production and energy metabolism.",
                    Quantity = 20,
                    Category = "Overall Health",
                    Price = 10.00,
                    Company = "Nature's Bounty",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 39,
                    ItemName = "Calcium Citrate 600mg",
                    VitaminType = "Calcium",
                    Description = "Citracal Calcium Citrate 600mg supports bone health and muscle function.",
                    Quantity = 20,
                    Category = "Bone Health",
                    Price = 25.00,
                    Company = "Citracal",
                    DateAdded = DateTime.Now
                },
                new Item
                {
                    ItemID = 40,
                    ItemName = "Elderberry Syrup",
                    VitaminType = "Elderberry",
                    Description = "Sambucol Elderberry Syrup supports immune system health with high antioxidant levels.",
                    Quantity = 15,
                    Category = "Immune System",
                    Price = 20.00,
                    Company = "Sambucol",
                    DateAdded = DateTime.Now
                }
            );
        }
    }
}

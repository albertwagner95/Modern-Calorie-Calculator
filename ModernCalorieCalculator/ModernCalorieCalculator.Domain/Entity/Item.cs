using ModernCalorieCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class Item : Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KcalPerOneHounderGrams { get; set; }
        public decimal QuantityFatsPOHG { get; set; } //POHG = PerOneHounderdGrams
        public decimal QuantityCarbohydratesPOHG { get; set; } //POHG = PerOneHounderdGrams
        public decimal QuantityProteinsPOHG { get; set; } //POHG = PerOneHounderdGrams
        public decimal ProductCost { get; set; } //How much do you pay for a specific product e.g milk chocolate costs PLN 5. e.t.c.

        public Item(
                    int id,
                    string name,
                    decimal kcalPerOneHounderGrams,
                    decimal quantityFatsPOHG,
                    decimal quantityCarbohydratesPOHG,
                    decimal quantityProteinsPOHG,
                    decimal productCost,
                    int categoryId,
                    string categoryName
                    
                    ):base(categoryId,categoryName)
        {
            Id = id;
            Name = name;
            KcalPerOneHounderGrams = kcalPerOneHounderGrams;
            QuantityFatsPOHG = quantityFatsPOHG;
            QuantityCarbohydratesPOHG = quantityCarbohydratesPOHG;
            QuantityProteinsPOHG = quantityProteinsPOHG;
            ProductCost = productCost;
            CreationDate = DateTime.Now;

        }

    }

}

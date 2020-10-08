using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator.Domain
{
    public class ItemConfiguration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KcalPerOneHounderGrams { get; set; }
        public decimal QuantityFatsPOHG { get; set; } //POHG = PerOneHounderdGrams
        public decimal QuantityCarbohydratesPOHG { get; set; } //POHG = PerOneHounderdGrams
        public decimal QuantityProteinsPOHG { get; set; } //POHG = PerOneHounderdGrams
        public decimal ProductCost { get; set; } //How much do you pay for a specific product e.g milk chocolate costs PLN 5. e.t.c.
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

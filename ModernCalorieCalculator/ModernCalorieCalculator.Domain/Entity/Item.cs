using ModernCalorieCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace ModernCalorieCalculator.Domain.Entity
{
    public class Item : Category
    {   
        [XmlAttribute("Id")]
        
        public int Id { get; set; }
        
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("KcalPerOneHounderGrams")]
        public decimal KcalPerOneHounderGrams { get; set; }
        [XmlElement("QuantityFatsPOHG")]
        public decimal QuantityFatsPOHG { get; set; } //POHG = PerOneHounderdGrams
        [XmlElement("QuantityCarbohydratesPOHG")]
        public decimal QuantityCarbohydratesPOHG { get; set; } //POHG = PerOneHounderdGrams
        [XmlElement("QuantityProteinsPOHG")]
        public decimal QuantityProteinsPOHG { get; set; } //POHG = PerOneHounderdGrams
        [XmlElement("ProductCost")]
        public decimal ProductCost { get; set; } //How much do you pay for a specific product e.g milk chocolate costs PLN 5. e.t.c.

        public Item()
        {

        }
        public Item(ItemConfiguration itemConfiguration) : base(itemConfiguration.CategoryId, itemConfiguration.CategoryName)
        {
            Id = itemConfiguration.Id;
            Name = itemConfiguration.Name;
            KcalPerOneHounderGrams = itemConfiguration.KcalPerOneHounderGrams;
            QuantityFatsPOHG = itemConfiguration.QuantityFatsPOHG;
            QuantityCarbohydratesPOHG = itemConfiguration.QuantityCarbohydratesPOHG;
            QuantityProteinsPOHG = itemConfiguration.QuantityProteinsPOHG;
            ProductCost = itemConfiguration.ProductCost;
        }


    }

}

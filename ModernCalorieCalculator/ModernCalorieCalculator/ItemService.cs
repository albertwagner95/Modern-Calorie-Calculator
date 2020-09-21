using System;
using System.Collections.Generic;
using System.Text;

namespace ModernCalorieCalculator
{
    public class ItemService
    {
        public List<Item> Items { get; set; }

        public ItemService()
        {
            Items = new List<Item>();
        }

        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            var addNewItemMenu = actionService.GetMenuActionsByMenuName("AddNewItemMenu");
            Console.WriteLine("Please select product category");

            Program.ShowMenu(addNewItemMenu);
            var operation = Console.ReadKey();

            return operation;
        }

        public int AddNewItem(char itemType)
        {
            int typeId;
            int.TryParse(itemType.ToString(), out typeId);
            Item item = new Item();


            return AddNewItemProperties(item, typeId);
        }

        public int DetailItemView()
        {
            Console.WriteLine("Please enter id for item want to check details");
            var itemId = Console.ReadLine();
            Int32.TryParse(itemId, out int id);

            return id;
        }

        public void ShowItemDetails(int itemId)
        {
            var productDetails = Items.Find(x => x.Id == itemId);
            Console.WriteLine("Details product:");
            Console.WriteLine($"Id: {productDetails.Id}");
            Console.WriteLine($"Name: {productDetails.Name}");
            Console.WriteLine($"Kcal per 100 grams: {productDetails.KcalPerOneHounderGrams}");
        }
        public int AddNewItemProperties(Item item, int typeId)
        {
            item.CategoryId = typeId;
            item.Id = Items.Count + 1;
            Console.WriteLine("Please enter name for your new product");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter kcal per 100 grams");
            var kcalPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(kcalPerOneHoundredGramsReading, out decimal kcalPerOneHoundredGrams);
            Console.WriteLine("Please enter quantity fats per one houndred grams");
            var quantityFatsPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(quantityFatsPerOneHoundredGramsReading, out decimal quantityFatsPerOneHoundredGrams);

            item.Name = name;
            item.KcalPerOneHounderGrams = kcalPerOneHoundredGrams;
            item.QuantityFatsPOHG = quantityFatsPerOneHoundredGrams;

            Items.Add(item);
            Console.Clear();

            return item.Id;
        }
    }
}

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

        public void ShowItemDetails(int itemId, List<ItemCategory> itemCategoryList)
        {
            var productDetails = Items.Find(x => x.Id == itemId);

            if (productDetails == null)
            {
                Console.WriteLine("Doesn't found product for this id.");
            }
            else
            {
                var categoryName = itemCategoryList.Find(x => x.Id == productDetails.CategoryId);

                Console.WriteLine("Details product:");
                Console.WriteLine($"Id: {productDetails.Id}");
                Console.WriteLine($"Name: {productDetails.Name}");
                Console.WriteLine($"Kcal per 100 grams: {productDetails.KcalPerOneHounderGrams}");
                Console.WriteLine($"Fat per 100 grams: {productDetails.QuantityFatsPOHG}");
                Console.WriteLine($"Protein per 100 grams: {productDetails.QuantityProteinsPOHG}");
                Console.WriteLine($"Carbohydrates per 100 grams: {productDetails.QuantityCarbohydratesPOHG}");
                Console.WriteLine($"Product cost: {productDetails.ProductCost}");
                Console.WriteLine($"Category name: {categoryName.CategoryName}");
                Console.WriteLine($"Date added: {productDetails.DateAdded}");
            }
        }

        public void ModifyItemBySelectedCategory(char modifyMenu, List<ItemCategory> itemCategoryList)
        {
            if (modifyMenu == '7')
            {
                var menu = new MenuActionService();
                var menuToGo = menu.GetMenuActionsByMenuName("Main");
                Program.ShowMenu(menuToGo);
            }
            else
            {
                Console.WriteLine("Enter id product which you want to modify.");
                var idLoading = Console.ReadLine();
                Int32.TryParse(idLoading, out int idModifyProduct);
                var productToModify = Items.Find(x => x.Id.Equals(idModifyProduct));
                if (productToModify != null)
                {
                    switch (modifyMenu)
                    {
                        case '1':
                            Console.WriteLine("Enter new product name");
                            var newProductName = Console.ReadLine();
                            productToModify.Name = newProductName;
                            break;

                        case '2':
                            Console.WriteLine("Enter new product calories per 100/g");
                            var modifiedProductCaloriesPerOneHoundredGramsLoading = Console.ReadLine();
                            decimal modifiedProductCaloriesPerOneHoundredGrams;
                            decimal.TryParse(modifiedProductCaloriesPerOneHoundredGramsLoading, out modifiedProductCaloriesPerOneHoundredGrams);
                            productToModify.KcalPerOneHounderGrams = modifiedProductCaloriesPerOneHoundredGrams;
                            break;
                        case '3':
                            Console.WriteLine("Enter new product fats per 100/g");
                            var modifiedProductFatsPerOneHoundredGramsLoading = Console.ReadLine();
                            decimal modifiedProductFatsPerOneHoundredGrams;
                            decimal.TryParse(modifiedProductFatsPerOneHoundredGramsLoading, out modifiedProductFatsPerOneHoundredGrams);
                            productToModify.QuantityFatsPOHG = modifiedProductFatsPerOneHoundredGrams;
                            break;
                        case '4':
                            Console.WriteLine("Enter new product carbohydrates 100/g");
                            var modifiedProductCarbohydratesPerOneHoundredGramsLoading = Console.ReadLine();
                            decimal modifiedProductCarbohydratesPerOneHoundredGrams;
                            decimal.TryParse(modifiedProductCarbohydratesPerOneHoundredGramsLoading, out modifiedProductCarbohydratesPerOneHoundredGrams);
                            productToModify.QuantityCarbohydratesPOHG = modifiedProductCarbohydratesPerOneHoundredGrams;
                            break;
                        case '5':
                            Console.WriteLine("Enter new product proteins 100/g");
                            var modifiedProductProteinsPerOneHoundredGramsLoading = Console.ReadLine();
                            decimal modifiedProductProteinsPerOneHoundredGrams;
                            decimal.TryParse(modifiedProductProteinsPerOneHoundredGramsLoading, out modifiedProductProteinsPerOneHoundredGrams);
                            productToModify.QuantityProteinsPOHG = modifiedProductProteinsPerOneHoundredGrams;
                            break;
                        case '6':
                            Console.WriteLine("Enter new product cost");
                            var modifiedProductCostLoading = Console.ReadLine();
                            decimal modifiedProductCost;
                            decimal.TryParse(modifiedProductCostLoading, out modifiedProductCost);
                            productToModify.ProductCost = modifiedProductCost;
                            break;

                        default:
                            Console.WriteLine("bad");
                            break;
                    }
                    Console.WriteLine("The product has been successfully modified.");
                    Console.WriteLine("The current product data is:");
                    ShowItemDetails(idModifyProduct, itemCategoryList);
                }
                else
                {
                    Console.WriteLine("Doesn't found product for this id.");
                }
            }

        }



        public ConsoleKeyInfo ModifyItemView(MenuActionService actionService)
        {
            var modifyItemByIdMenu = actionService.GetMenuActionsByMenuName("ModifyItemByIdMenu");
            Console.WriteLine("Please select what do you want modify");
            Program.ShowMenu(modifyItemByIdMenu);

            var operation = Console.ReadKey();
            Console.Clear();
            return operation;
        }


        public int AddNewItemProperties(Item item, int typeId)
        {

            Console.WriteLine("Please enter name for your new product");
            var name = Console.ReadLine();

            Console.WriteLine("Please enter kcal per 100 grams");
            var kcalPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(kcalPerOneHoundredGramsReading, out decimal kcalPerOneHoundredGrams);

            Console.WriteLine("Please enter quantity fats per one houndred grams");
            var quantityFatsPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(quantityFatsPerOneHoundredGramsReading, out decimal quantityFatsPerOneHoundredGrams);

            Console.WriteLine("Please enter quantity carbohydrates per one houndred grams");
            var quantityCarboPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(quantityCarboPerOneHoundredGramsReading, out decimal quantityCarboPerOneHoundredGrams);

            Console.WriteLine("Please enter quantity proteins per one houndred grams");
            var quantityProteinsPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(quantityProteinsPerOneHoundredGramsReading, out decimal quantityProteinsPerOneHoundredGrams);

            Console.WriteLine("Please enter cost your product");
            var productCostLoading = Console.ReadLine();
            decimal.TryParse(productCostLoading, out decimal productCost);

            item.CategoryId = typeId;
            item.Id = Items.Count + 1;
            item.Name = name;
            item.KcalPerOneHounderGrams = kcalPerOneHoundredGrams;
            item.QuantityFatsPOHG = quantityFatsPerOneHoundredGrams;
            item.QuantityCarbohydratesPOHG = quantityCarboPerOneHoundredGrams;
            item.QuantityProteinsPOHG = quantityProteinsPerOneHoundredGrams;
            item.ProductCost = productCost;
            item.DateAdded = DateTime.Now;

            Items.Add(item);
            Console.Clear();

            return item.Id;
        }
    }
}

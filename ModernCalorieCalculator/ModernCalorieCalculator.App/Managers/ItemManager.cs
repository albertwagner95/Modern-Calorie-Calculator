using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernCalorieCalculator.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private ItemService _itemService;
        public ItemManager(MenuActionService actionService)
        {
            _itemService = new ItemService();
            _actionService = actionService;
        }

        public int AddNewItem()
        {
            Console.WriteLine("Please select product category");

            _actionService.ShowMenu("addNewItemMenu");

            var operation = Console.ReadKey();
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

            int id = _itemService.GetLastId() + 1;
            Item item = new Item(id, name, kcalPerOneHoundredGrams, quantityFatsPerOneHoundredGrams, quantityCarboPerOneHoundredGrams, quantityProteinsPerOneHoundredGrams, productCost, 2);

            _itemService.AddItem(item);
            Console.Clear();
            return item.Id;
        }

        public List<Item> GetAllItems()
        {
            return _itemService.GetAllItems();
        }

        public void ShowOneProduct()
        {
            Console.WriteLine("Enter the product id");
            var userIdLoading = Console.ReadLine();

            var isLoading = int.TryParse(userIdLoading, out int idFromUser);
            if (isLoading == false)
            {
                Console.WriteLine("The entered data is incorrect!");
            }
            else
            {
                ShowItemDetails(idFromUser);
            }
        }


        public void ShowItemDetails(int itemId)
        {
            var productDetails = _itemService.GetProductById(itemId);

            if (productDetails == null)
            {
                Console.WriteLine("Doesn't found product for this id.");
            }
            else
            {

                Console.WriteLine("Details product:");
                Console.WriteLine($"Id: {productDetails.Id}");
                Console.WriteLine($"Name: {productDetails.Name}");
                Console.WriteLine($"Kcal per 100 grams: {productDetails.KcalPerOneHounderGrams}");
                Console.WriteLine($"Fat per 100 grams: {productDetails.QuantityFatsPOHG}");
                Console.WriteLine($"Protein per 100 grams: {productDetails.QuantityProteinsPOHG}");
                Console.WriteLine($"Carbohydrates per 100 grams: {productDetails.QuantityCarbohydratesPOHG}");
                Console.WriteLine($"Product cost: {productDetails.ProductCost}");
                Console.WriteLine($"Date added: {productDetails.CreationDate}");
            }
        }

        public void updateitem()
        {

            _actionService.ShowMenu("ModifyItemByIdMenu");
            var loadingOperation = Console.ReadKey();
            bool isLoadingOperation = int.TryParse(loadingOperation.KeyChar.ToString(), out int operation);

            var productIdToUpdate = LoadingProductId();
            var productToUpadte = _itemService.GetProductById(productIdToUpdate);

            if (productToUpadte == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                _itemService.UpdateProductByProperty(productToUpadte, operation);
            }

        }

        public int LoadingProductId()
        {
            Console.WriteLine("Enter id of the product which you want update");
            var loadingId = Console.ReadLine();
            bool isLoading = int.TryParse(loadingId, out int idToUpdate);

            while (!isLoading)
            {
                Console.WriteLine("Data is incorrect, please enter id once again. If you wan exit, press Y");
                loadingId = Console.ReadLine();

                if (loadingId.ToUpper() == "Y")
                {
                    break;
                }
                else
                {
                    isLoading = int.TryParse(loadingId, out idToUpdate);
                }
            }

            return idToUpdate;
        }
    }
}

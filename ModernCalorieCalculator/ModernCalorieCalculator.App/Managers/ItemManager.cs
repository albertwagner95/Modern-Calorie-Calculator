using ModernCalorieCalculator.App.Abstract;
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
        private IService _itemService;
        private ICategory _categoryService;

        public ItemManager(MenuActionService actionService, IService itemService, ICategory category)
        {
            _itemService = itemService;
            _actionService = actionService;
            _categoryService = category;
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

            Item item = new Item(id, name, kcalPerOneHoundredGrams, quantityFatsPerOneHoundredGrams, quantityCarboPerOneHoundredGrams, quantityProteinsPerOneHoundredGrams, productCost);

            _itemService.AddItem(item);
            Console.Clear();
            return item.Id;
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
            var productDetails = _itemService.GetItemById(itemId);

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
            var productToUpadte = _itemService.GetItemById(productIdToUpdate);

            if (productToUpadte == null)
            {
                Console.WriteLine("Product not found");
            }
            else
            {
                UpdateProductByProperty(productToUpadte, operation);
            }

        }

        public int LoadingProductId()
        {
            Console.WriteLine("Enter id of the product which you want update");
            var loadingId = Console.ReadLine();
            var id = LoadingProductIdToInt(loadingId);

            while (id == 0)
            {
                Console.WriteLine("Data is incorrect, please enter id once again. If you wan exit, press Y");
                loadingId = Console.ReadLine();

                if (loadingId.ToUpper() == "Y")
                {
                    break;
                }
                else
                {
                    id = LoadingProductIdToInt(loadingId);
                }
            }

            return id;
        }

        /// <summary>
        /// When loading id from user is fail return 0.
        /// </summary>
        /// <param name="idFromUser"></param>
        /// <returns>If fail return 0 else return good id from user</returns>
        public int LoadingProductIdToInt(string idFromUser)
        {
            var id = int.TryParse(idFromUser, out int idToUpdate);
            if (id)
            {
                return idToUpdate;
            }
            else
            {
                return 0;
            }
        }


        public Item GetProductById(int id)
        {
            var selectedProduct = _itemService.GetItemById(id);
            if (selectedProduct != null)
            {
                return selectedProduct;
            }
            else
            {
                return null;
            }
        }

        public int UpdateProductName(Item item)
        {
            Console.WriteLine("Enter new item name");
            var loadingProductName = Console.ReadLine();
            var id = _itemService.UpdateName(loadingProductName, item);
            return id;
        }
        
        public int UpdateKcalPerOneHoundredGrams(Item productToUpdate)
        {
            Console.WriteLine("Enter kcal 100/g of the product which you want update");
            var kcal = Console.ReadLine();
            bool isLoading = int.TryParse(kcal, out int kcalToUpdate);
            if (!isLoading)
            {
                while (!isLoading)
                {
                    Console.WriteLine("Data is incorrect, please enter kcal 100/g once again. If you want exit, press Y");
                    kcal = Console.ReadLine();

                    if (kcal.ToUpper() == "Y")
                    {
                        break;
                    }
                    else
                    {
                        isLoading = int.TryParse(kcal, out kcalToUpdate);
                        _itemService.UpdateKcalPerOneHoundredGrams(kcalToUpdate, productToUpdate);
                    }
                }
            }
            else
            {
                productToUpdate.KcalPerOneHounderGrams = kcalToUpdate;
            }

            return productToUpdate.Id;
        }

        public int UpdateQuantityFat(Item productToUpdate)
        {
            {
                Console.WriteLine("Enter fat 100/g of the product which you want update");
                var fat = Console.ReadLine();
                bool isLoading = int.TryParse(fat, out int fatToUpdate);
                if (!isLoading)
                {
                    while (!isLoading)
                    {
                        Console.WriteLine("Data is incorrect, please enter fat 100/g once again. If you want exit, press Y");
                        fat = Console.ReadLine();

                        if (fat.ToUpper() == "Y")
                        {
                            break;
                        }
                        else
                        {
                            isLoading = int.TryParse(fat, out fatToUpdate);
                            _itemService.UpdateFatsPerOneHoundredGrams(fatToUpdate, productToUpdate);
                        }
                    }
                }
                else
                {
                    productToUpdate.QuantityFatsPOHG = fatToUpdate;
                }
                return productToUpdate.Id;
            }

        }

        public int UpdateQuantityCarbohydrates(Item productToUpdate)
        {
            Console.WriteLine("Enter carbo 100/g of the product which you want update");
            var carbo = Console.ReadLine();
            bool isLoading = int.TryParse(carbo, out int carboToUpdate);
            if (!isLoading)
            {
                while (!isLoading)
                {
                    Console.WriteLine("Data is incorrect, please enter fat 100/g once again. If you want exit, press Y");
                    carbo = Console.ReadLine();

                    if (carbo.ToUpper() == "Y")
                    {
                        break;
                    }
                    else
                    {
                        isLoading = int.TryParse(carbo, out carboToUpdate);
                        _itemService.UpdateCarbohydratesPerOneHoundredGrams(carboToUpdate, productToUpdate);
                    }
                }
            }
            else
            {
                productToUpdate.QuantityCarbohydratesPOHG = carboToUpdate;
            }
            return productToUpdate.Id;
        }

        public int UpdateQuantityProteins(Item productToUpdate)
        {
            Console.WriteLine("Enter protein 100/g of the product which you want update");
            var protein = Console.ReadLine();

            bool isLoading = int.TryParse(protein, out int proteinToUpdate);

            if (!isLoading)
            {
                while (!isLoading)
                {
                    Console.WriteLine("Data is incorrect, please enter fat 100/g once again. If you want exit, press Y");
                    protein = Console.ReadLine();

                    if (protein.ToUpper() == "Y")
                    {
                        break;
                    }
                    else
                    {
                        isLoading = int.TryParse(protein, out proteinToUpdate);
                        _itemService.UpdateProteinsPerOneHoundredGrams(proteinToUpdate, productToUpdate);
                    }
                }
            }
            else
            {
                productToUpdate.QuantityProteinsPOHG = proteinToUpdate;
            }
            return productToUpdate.Id;

        }

        public int UpdateProductByProperty(Item productToUpdate, int operation)
        {
            switch (operation)
            {
                case 1:
                    return UpdateProductName(productToUpdate);
                case 2:
                    return UpdateKcalPerOneHoundredGrams(productToUpdate);
                case 3:
                    return UpdateQuantityFat(productToUpdate);
                case 4:
                    return UpdateQuantityCarbohydrates(productToUpdate);
                case 5:
                    return UpdateQuantityProteins(productToUpdate);
                default:
                    Console.WriteLine("");
                    return productToUpdate.Id;
            }
        }
    }
}

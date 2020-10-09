using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain;
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

        public ItemManager(MenuActionService actionService, IService itemService, ICategory categoryService)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _actionService = actionService;
        }


        public int AddNewItem()
        {
            Console.WriteLine("Please select product category");

            foreach (var categoryProduct in _categoryService.Categories)
            {
                Console.WriteLine($"{categoryProduct.CategoryId}. {categoryProduct.CategoryName}");
            }
            int productCategoryId = 0;

            while (true)
            {
                var productCategory = Console.ReadLine();

                productCategoryId = ItemManagerHelper.ReadCategory(productCategory.ToString());
                if (productCategoryId == 0)
                {
                    Console.WriteLine("Data is incorrect!");
                }
                else
                {
                    break;
                }

            }

            int id = _itemService.GetLastId() + 1;

            _itemService.ItemConfiguration.CategoryId = productCategoryId;

            _itemService.ItemConfiguration.CategoryName = _categoryService.GetCategoryNameById(productCategoryId);

            _itemService.ItemConfiguration.Name = ItemManagerHelper.LoadingNameFromUser();

            _itemService.ItemConfiguration.KcalPerOneHounderGrams = ItemManagerHelper.LoadingKcalPOHG();

            _itemService.ItemConfiguration.QuantityFatsPOHG = ItemManagerHelper.LoadingFatPOHG();

            _itemService.ItemConfiguration.QuantityCarbohydratesPOHG = ItemManagerHelper.LoadingCarboPOHG();

            _itemService.ItemConfiguration.QuantityProteinsPOHG = ItemManagerHelper.LoadingProteinsPOHG();

            _itemService.ItemConfiguration.Id = id;

            _itemService.ItemConfiguration.ProductCost = ItemManagerHelper.LoadingProductCost();

            Item item = new Item(_itemService.ItemConfiguration);
            _itemService.AddItem(item);
            _itemService.AddItemToXml(item);
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

        public int UpdateProductByProperty(Item productToUpdate, int operation)
        {
            switch (operation)
            {
                case 1:
                    //return UpdateProductName(productToUpdate);
                    return ItemManagerHelper.UpdateProductName(productToUpdate, _itemService);

                case 2:
                    return ItemManagerHelper.UpdateKcalPerOneHoundredGrams(productToUpdate, _itemService);
                case 3:
                    return ItemManagerHelper.UpdateQuantityFat(productToUpdate, _itemService);
                case 4:
                    return ItemManagerHelper.UpdateQuantityCarbohydrates(productToUpdate, _itemService);
                case 5:
                    return ItemManagerHelper.UpdateQuantityProteins(productToUpdate, _itemService);
                default:
                    Console.WriteLine("");
                    return productToUpdate.Id;
            }
        }
    }
}

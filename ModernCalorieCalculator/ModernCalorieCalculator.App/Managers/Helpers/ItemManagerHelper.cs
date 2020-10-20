using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.Domain.Entity;
using System;

namespace ModernCalorieCalculator.App.Managers.Helpers
{
    public static class ItemManagerHelper
    {
        public static int UpdateProductName(Item item, IService itemService)
        {
            Console.WriteLine("Enter new item name");
            var loadingProductName = Console.ReadLine();
            var id = itemService.UpdateName(loadingProductName, item);
            return id;
        }

        public static int UpdateKcalPerOneHoundredGrams(Item productToUpdate, IService itemService)
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
                        itemService.UpdateKcalPerOneHoundredGrams(kcalToUpdate, productToUpdate);
                    }
                }
            }
            else
            {
                productToUpdate.KcalPerOneHounderGrams = kcalToUpdate;
            }

            return productToUpdate.Id;
        }


        public static int UpdateQuantityFat(Item productToUpdate, IService itemService)
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
                            itemService.UpdateFatsPerOneHoundredGrams(fatToUpdate, productToUpdate);
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

        public static int UpdateQuantityCarbohydrates(Item productToUpdate, IService itemService)
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
                        itemService.UpdateCarbohydratesPerOneHoundredGrams(carboToUpdate, productToUpdate);
                    }
                }
            }
            else
            {
                productToUpdate.QuantityCarbohydratesPOHG = carboToUpdate;
            }
            return productToUpdate.Id;
        }

        public static int UpdateQuantityProteins(Item productToUpdate, IService itemService)
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
                        itemService.UpdateProteinsPerOneHoundredGrams(proteinToUpdate, productToUpdate);
                    }
                }
            }
            else
            {
                productToUpdate.QuantityProteinsPOHG = proteinToUpdate;
            }
            return productToUpdate.Id;

        }

        public static string LoadingNameFromUser()
        {
            Console.WriteLine("Please enter name for your new product");
            var name = Console.ReadLine();
            return name;
        }
        //POHG per one houndred grams
        public static decimal LoadingKcalPOHG()
        {
            Console.WriteLine("Please enter kcal per 100 grams");
            var kcalPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(kcalPerOneHoundredGramsReading, out decimal kcalPerOneHoundredGrams);
            return kcalPerOneHoundredGrams;
        }

        public static decimal LoadingFatPOHG()
        {
            Console.WriteLine("Please enter quantity fats per one houndred grams");
            var quantityFatsPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(quantityFatsPerOneHoundredGramsReading, out decimal quantityFatsPerOneHoundredGrams);
            return quantityFatsPerOneHoundredGrams;
        }

        public static decimal LoadingCarboPOHG()
        {
            Console.WriteLine("Please enter quantity carbohydrates per one houndred grams");
            var quantityCarboPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(quantityCarboPerOneHoundredGramsReading, out decimal quantityCarboPerOneHoundredGrams);
            return quantityCarboPerOneHoundredGrams;
        }

        public static decimal LoadingProteinsPOHG()
        {
            Console.WriteLine("Please enter quantity proteins per one houndred grams");
            var quantityProteinsPerOneHoundredGramsReading = Console.ReadLine();
            decimal.TryParse(quantityProteinsPerOneHoundredGramsReading, out decimal quantityProteinsPerOneHoundredGrams);
            return quantityProteinsPerOneHoundredGrams;
        }

        public static decimal LoadingProductCost()
        {
            Console.WriteLine("Please enter cost your product");
            var productCostLoading = Console.ReadLine();
            decimal.TryParse(productCostLoading, out decimal productCost);
            return productCost;
        }

        public static int ReadCategory(string productCategory)
        {
            int categoryId;
            bool isLoading = int.TryParse(productCategory, out categoryId);

            if (isLoading == false)
            {
                return 0;
            }
            if (categoryId > 8 || categoryId < 1)
            {
                return 0;
            }

            return categoryId;

        }

    }
}

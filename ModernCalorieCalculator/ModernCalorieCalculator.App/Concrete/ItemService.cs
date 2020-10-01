using ModernCalorieCalculator.App.Common;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernCalorieCalculator.App.Concrete
{
    public class ItemService : BaseService<Item>
    {

        public Item GetProductById(int id)
        {
            var selectedProduct = Items.FirstOrDefault(x => x.Id == id);
            if (selectedProduct != null)
            {
                return selectedProduct;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// POHG - abbreviation Per One Houndred Grams
        /// This method return id product after update Calories etc and Per One Hounder Grams.
        /// </summary>
        /// <param name="productToUpdate"></param>
        /// <returns>This method return id product after update Calories etc Per One Hounder Grams.</returns>
        public int UpdateProductByProperty(Item productToUpdate, int operation)
        {
            switch (operation)
            {
                case 1:
                    Console.WriteLine("Enter new item name");
                    var loadingProductName = Console.ReadLine();

                    productToUpdate.Name = loadingProductName;
                    productToUpdate.UpdateTime = DateTime.Now;
                    return productToUpdate.Id;

                case 2:
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
                                    productToUpdate.KcalPerOneHounderGrams = kcalToUpdate;
                                    productToUpdate.UpdateTime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            productToUpdate.KcalPerOneHounderGrams = kcalToUpdate;
                        }
                        return productToUpdate.Id;
                    }

                case 3:


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
                                    productToUpdate.QuantityFatsPOHG = fatToUpdate;
                                    productToUpdate.UpdateTime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            productToUpdate.QuantityFatsPOHG = fatToUpdate;
                        }
                        return productToUpdate.Id;
                    }
                case 4:
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
                                    productToUpdate.QuantityFatsPOHG = carboToUpdate;
                                    productToUpdate.UpdateTime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            productToUpdate.QuantityCarbohydratesPOHG = carboToUpdate;
                        }
                        return productToUpdate.Id;
                    }
                case 5:

                    {
                        Console.WriteLine("Enter fat 100/g of the product which you want update");
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
                                    productToUpdate.QuantityFatsPOHG = proteinToUpdate;
                                    productToUpdate.UpdateTime = DateTime.Now;
                                }
                            }
                        }
                        else
                        {
                            productToUpdate.QuantityProteinsPOHG = proteinToUpdate;
                        }
                        return productToUpdate.Id;
                    }
                
                default:
                    Console.WriteLine("");
                    return productToUpdate.Id;
            }
        }


    }
}

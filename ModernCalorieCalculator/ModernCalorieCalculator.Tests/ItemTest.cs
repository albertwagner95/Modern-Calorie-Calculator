using FluentAssertions;
using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.App.Managers;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain;
using ModernCalorieCalculator.Domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;

namespace ModernCalorieCalculator.Tests
{
    public class ItemTest
    {
        [Fact]
        public void ShouldBeAddItem()
        {
            //Arrange
            ItemService itemService = new ItemService();
            ItemConfiguration itemConfig = new ItemConfiguration();
            CategoryService itemCategory = new CategoryService();
            itemConfig.Name = "Kotlet";
            itemConfig.KcalPerOneHounderGrams = 199;
            itemConfig.QuantityCarbohydratesPOHG = 120;
            itemConfig.QuantityFatsPOHG = 122;
            itemConfig.QuantityProteinsPOHG = 212;
            itemConfig.ProductCost = 122;

            Item item2 = new Item(itemConfig);
            Item item = new Item(itemConfig);

            var manager = new ItemManager(new MenuActionService(), itemService, itemCategory);
            //act
            var loadingId = manager.LoadingProductIdToInt("1");
            var loadingId2 = manager.LoadingProductIdToInt("asd");
            //Assert
            loadingId.Should().Be(1);
            loadingId2.Should().Be(0);
        }

        [Fact]
        public void ShouldBeUpdateItemProperty()
        {
            //Arrange 
            ItemService itemService = new ItemService();
            ItemConfiguration itemConfig = new ItemConfiguration();
            CategoryService itemCategory = new CategoryService();
            Item item = new Item(itemConfig); 

            var manager = new ItemManager(new MenuActionService(), itemService, itemCategory);
            itemService.AddItem(item); 
            //Act  
            itemService.UpdateName("pierogi", item); 
            itemService.UpdateKcalPerOneHoundredGrams(100, item);
            itemService.UpdateCarbohydratesPerOneHoundredGrams(100, item);
            itemService.UpdateFatsPerOneHoundredGrams(100, item);
            itemService.UpdateProteinsPerOneHoundredGrams(100, item);
            //Assert
            item.Should().NotBeNull();
            item.Name.Should().Be("pierogi");
            item.Should().BeOfType<Item>();
            item.KcalPerOneHounderGrams.Should().Be(100);
            item.QuantityCarbohydratesPOHG.Should().Be(100);
            item.QuantityFatsPOHG.Should().Be(100);
            item.QuantityProteinsPOHG.Should().Be(100);
            }
        
        [Fact]
        public void ShouldBeReturnCategoryId()
        {
            //arrange
           var optionOne = ItemManagerHelper.ReadCategory("1");
           var optionTwo = ItemManagerHelper.ReadCategory("12");
           var optionThree = ItemManagerHelper.ReadCategory("1asd2asdxz");
           var optionFour = ItemManagerHelper.ReadCategory("8");
           var optionFive = ItemManagerHelper.ReadCategory("1");
           var optionSix = ItemManagerHelper.ReadCategory("0");

            //assert
            optionOne.Should().Be(1);
            optionTwo.Should().Be(0);
            optionThree.Should().Be(0);
            optionFour.Should().Be(8);
            optionFive.Should().Be(1);
            optionSix.Should().Be(0);
        }
    }
    
    }

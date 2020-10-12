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
using System.Security.Permissions;
using Xunit;

namespace ModernCalorieCalculator.Tests
{
    public class ItemManagerTests
    {
        [Fact]
        public void ShouldAddItem()
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
        public void ShouldReturnCategoryId()
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

        [Fact]
        public void ShouldReturnProductToUpdate()
        {
            //arrange
            ItemConfiguration itemConfig = new ItemConfiguration();
            itemConfig.Name = "Kotlet";
            itemConfig.KcalPerOneHounderGrams = 199;
            itemConfig.QuantityCarbohydratesPOHG = 120;
            itemConfig.QuantityFatsPOHG = 122;
            itemConfig.QuantityProteinsPOHG = 212;
            itemConfig.ProductCost = 122;
            itemConfig.Id = 1;
            itemConfig.CategoryId = 1;
            itemConfig.CategoryName = "Pieczywo";
            Item item = new Item(itemConfig);
            List<Item> items = new List<Item>();
            var mock = new Mock<IService>();
            var x = mock.Setup(x => x.GetItemById(1)).Returns(item);
            var manager = new ItemManager(new MenuActionService(), mock.Object, new CategoryService());
            //act
            var result = manager.GetProductById(item.Id);
            //assert
            result.Id.Should().Be(1);
        }

        [Fact]
        public void ShouldReadCategoryFromStringValue()
        {
            //arrange
            string test = "1";
            string testTwo = "12";
            //act
            var result = ItemManagerHelper.ReadCategory(test);
            var two = ItemManagerHelper.ReadCategory(testTwo);
            //assert
            result.Should().Be(1);
            two.Should().Be(0);
            
        }
    }

}

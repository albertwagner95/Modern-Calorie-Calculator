using FluentAssertions;
using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.App.Managers;
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
        public void ShouldBeGetProductById()
        {
            // Arrange
            Item item = new Item(1, "Kotlet", 1, 2, 3, 3, 3);

            var mock = new Mock<IService>();
            mock.Setup(s => s.GetItemById(1)).Returns(item);
            var manager = new ItemManager(new MenuActionService(), mock.Object);
            // Act
            var product = manager.GetProductById(1);
            // Assert
            item.Should().BeSameAs(product);
            item.Should().BeOfType<Item>();


        }
        [Fact]
        public void ShouldBeAddItem()
        {
            //Arrange
            var mock = new Mock<IService>();
            var manager = new ItemManager(new MenuActionService(), mock.Object);
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

            Item item = new Item(1, "Kotlet", 1, 2, 3, 3, 3);
            Item item1 = new Item(2, "Kotlet", 1, 2, 3, 3, 3);

            var manager = new ItemManager(new MenuActionService(), itemService);
            itemService.AddItem(item);
            itemService.AddItem(item1);
            //Act  
            itemService.UpdateName("pierogi", item);
            itemService.UpdateName("", item1);
            itemService.UpdateKcalPerOneHoundredGrams(100, item);
            itemService.UpdateCarbohydratesPerOneHoundredGrams(100, item);
            itemService.UpdateFatsPerOneHoundredGrams(100, item);
            itemService.UpdateProteinsPerOneHoundredGrams(100, item);
            //Assert
            item.Should().NotBeNull();
            item.Name.Should().Be("pierogi");
            item1.Name.Should().Be("");
            item.Should().BeOfType<Item>();
            item.KcalPerOneHounderGrams.Should().Be(100);
            item.QuantityCarbohydratesPOHG.Should().Be(100);
            item.QuantityFatsPOHG.Should().Be(100);
            item.QuantityProteinsPOHG.Should().Be(100);
        }
    }
}

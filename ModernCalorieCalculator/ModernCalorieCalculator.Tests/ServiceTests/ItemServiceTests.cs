using FluentAssertions;
using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.Domain;
using ModernCalorieCalculator.Domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ModernCalorieCalculator.Tests.ServiceTests
{
    public class ItemServiceTests
    {
        [Fact]
        public void ShouldGetAllItems()
        {   //Arrange 
            Item item = new Item();
            Item item2 = new Item();
            ItemService itemService = new ItemService();
            //Act
            itemService.AddItem(item);
            itemService.AddItem(item2);

            var result = itemService.GetAllItems();

            //Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(2);
            result.Should().NotBeNull();

            //Clear
            itemService.RemoveItem(item);
            itemService.RemoveItem(item2);
        }

        [Fact]
        public void ShouldRemoveItem()
        {
            //Arrange  
            ItemConfiguration itemConfig = new ItemConfiguration();
            Item item = new Item(itemConfig);
            Item item2 = new Item(itemConfig);
            ItemService itemService = new ItemService();
            itemService.AddItem(item);
            itemService.AddItem(item2);
            //Act
            itemService.RemoveItem(item);
            itemService.RemoveItem(item2);
            var result = itemService.GetAllItems();
            //Assert
            result.Should().BeNullOrEmpty();
            result.Should().HaveCount(0);
        }

        [Fact]
        public void ShouldReturnItemById()
        {
            //Arrange
            Item item = new Item();
            item.Id = 1;
            ItemService itemService = new ItemService();
            //Act
            itemService.AddItem(item);
            var result = itemService.GetItemById(1);
            //Assert
            result.Should().Be(item);
            result.Should().BeOfType(typeof(Item));
        }
    }
}

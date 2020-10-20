using FluentAssertions;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain.Entity;
using System.Collections.Generic;
using Xunit;

namespace ModernCalorieCalculator.Tests.UsertTests
{
    public class UserManagerHelpersTests
    {
        [Fact]
        public void ShouldReturnCaloriesDailySummary()
        {
            //Arrange
            List<UserItem> userItems = new List<UserItem>();
            List<UserItem> userItem = new List<UserItem>();
            userItems.Add(new UserItem { Id = 1, KcalPerOneHounderGrams = 100 });
            userItems.Add(new UserItem { Id = 2, KcalPerOneHounderGrams = 200 });
            userItems.Add(new UserItem { Id = 3, KcalPerOneHounderGrams = 300 });
            userItems.Add(new UserItem { Id = 3, KcalPerOneHounderGrams = 400 });
            //Act
            var kcalSummary = DayManagerHelpers.ReturnCalorieSummary(userItems);
            var kcalSummaryNull = DayManagerHelpers.ReturnCalorieSummary(userItem);
            //Assert
            kcalSummary.Should().Be(1000);
            kcalSummaryNull.Should().Be(0);
        }

        [Fact]
        public void ShouldConvertTheGivenValu()
        {
            //act
            Item item = new Item()
            {
                Id = 1,
                KcalPerOneHounderGrams = 83,
                QuantityCarbohydratesPOHG = 3.00M,
                QuantityFatsPOHG = 3.00M,
                QuantityProteinsPOHG = 11,
                ProductCost = 10M
            };

            //arrange
            UserItem convertedValues = DayManagerHelpers.ReturnConvertedValue(50, item);
            UserItem secondConvertedValues = DayManagerHelpers.ReturnConvertedValue(250, item);
            //assert
            convertedValues.KcalPerOneHounderGrams.Should().Be(42);
            convertedValues.QuantityCarbohydratesPOHG.Should().Be(1.5M);
            convertedValues.QuantityFatsPOHG.Should().Be(1.5M);
            convertedValues.QuantityProteinsPOHG.Should().Be(5.5M);
            convertedValues.ProductCost.Should().Be(5.0M);

            secondConvertedValues.KcalPerOneHounderGrams.Should().Be(208);
            secondConvertedValues.QuantityCarbohydratesPOHG.Should().Be(7.5M);
            secondConvertedValues.QuantityFatsPOHG.Should().Be(7.5M);
            secondConvertedValues.QuantityProteinsPOHG.Should().Be(27.5M);
            secondConvertedValues.ProductCost.Should().Be(25.0M);
        }

    }
}

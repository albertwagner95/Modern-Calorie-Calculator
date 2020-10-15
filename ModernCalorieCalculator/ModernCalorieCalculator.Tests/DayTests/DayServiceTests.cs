using FluentAssertions;
using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.App.Managers;
using ModernCalorieCalculator.App.Managers.Helpers;
using ModernCalorieCalculator.Domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ModernCalorieCalculator.Tests.DayTests
{
    public class DayServiceTests
    {
        //[Fact]
        //public void ShouldReturnUserDays()
        //{
        //    //Arrange
        //    User user = new User(1, "Janusz", "Wajs", "Wajo");
        //    Day day = new Day();
        //    day.UserDay = DayManagerHelpers.ReturnDayFromString("11/10/2020");
        //    day.UserId = 1;
        //    day.Id = 1;
        //    Day daySecond = new Day();
        //    daySecond.UserDay = DayManagerHelpers.ReturnDayFromString("10/22/2019");
        //    daySecond.Id = 2;
        //    daySecond.UserId = 1;
        //    Day dayThird = new Day() { Id = 3, UserId = 2 };
        //    var mock = new Mock<IUser>();
        //    mock.Setup(x => x.GetUserById(1)).Returns(user);
        //    var dayService = new DayService(mock.Object);
        //    //Act
        //    dayService.AddDay(day);
        //    dayService.AddDay(daySecond);
        //    dayService.AddDay(dayThird);
        //    var result = dayService.GetAllUserDays(1);
        //    var secondResult = dayService.GetAllUserDays(21);

        //    //assert
        //    result.Should().HaveCount(2);
        //    secondResult.Should().BeNull();
        //}
    }
}

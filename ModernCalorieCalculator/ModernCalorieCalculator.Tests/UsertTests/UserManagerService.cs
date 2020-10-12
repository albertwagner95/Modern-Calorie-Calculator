using FluentAssertions;
using ModernCalorieCalculator.App.Abstract;
using ModernCalorieCalculator.App.Managers;
using ModernCalorieCalculator.Domain.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ModernCalorieCalculator.Tests.UsertTests
{
    public class UserManagerService
    {
        [Fact]
        public void shouldAddUser()
        {
            //Arrange
            User user = new User(1, "Andrzej", "Kowalski", "Bertson");
            User userNull = new User();
            var mock = new Mock<IUser>();
            var mockUserNull = new Mock<IUser>();
            mock.Setup(x => x.AddUser(user)).Returns(1);
            mockUserNull.Setup(x => x.AddUser(user)).Returns(1);

            var manager = new UserManager(mock.Object);
            //Act
            var result = manager.AddUser(user);
            var resultNull = manager.AddUser(userNull);
            //Asset

            result.Should().Be(1);
            resultNull.Should().Be(0);
        }

        [Fact]
        public void ShouldRegisterUser()
        {
            //Arrange
            User user = new User(1, "Andrzej", "Kowalski", "Bertson");
            User userNull = new User();
            var mock = new Mock<IUser>();
            mock.Setup(x => x.AddUser(user)).Returns(user.Id);
            mock.Setup(x => x.FindUserByLogin("Bertson")).Returns(user);

            var manager = new UserManager(mock.Object);
            //Act
            User result = manager.RegisterUser("Janusz", "Laskowski", "Trol");
            User resultTwo = manager.RegisterUser("Janusz", "Laskowski", "Bertson");
            //Assets

            result.Should().BeOfType(typeof(User));
            result.Should().Be(result);
            result.Should().NotBeNull(); 
            resultTwo.Should().BeNull();
        }

        [Fact]
        public void ShouldLoggInApp()
        {
            //Arrange
            User user = new User(1, "Andrzej", "Kowalski", "Bertson");
            User userNull = new User();
            var mock = new Mock<IUser>();
            mock.Setup(x => x.AddUser(user)).Returns(1);
            mock.Setup(x => x.FindUserByLogin("Bertson")).Returns(user);
            UserManager manager = new UserManager(mock.Object);
            //Act
            User result = manager.LogIn("Bertson");
            User resultSecondOption = manager.LogIn("Bertsons");
            //Assets
            result.Should().Be(user);
            result.Should().NotBeNull();
            result.Login.Should().Be("Bertson");
            resultSecondOption.Should().BeNull();
        }
    }
}

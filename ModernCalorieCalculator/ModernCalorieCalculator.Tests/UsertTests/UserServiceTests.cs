using FluentAssertions;
using ModernCalorieCalculator.App.Concrete;
using ModernCalorieCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ModernCalorieCalculator.Tests.UsertTests
{
    public class UserServiceTests
    {
        [Fact]
        public void ShuoldReturnUserOrNullById()
        {
            //Arrange
            UserService userService = new UserService();
            User user = new User(1, "Andrzej", "Kowalski","janex");
            //Act
            userService.AddUser(user);
            var result = userService.GetUserById(user.Id);
            //Assets
            result.Should().NotBeNull();
            result.Should().Be(user);
            result.Should().BeOfType(typeof(User));
        }

        [Fact]
        public void ShouldReturnAllUsers()
        {
            //Arrange
            UserService userService = new UserService();
            User user = new User(1, "Andrzej", "Kowalski","Janex");
            User userTwo = new User(2, "Andrzej", "Kowalski","Panex");
            //Act
            userService.AddUser(user);
            userService.AddUser(userTwo);
            var result = userService.GetUsers();
            //Assets
            result.Should().HaveCount(2);
            result.Should().NotBeEmpty();
            result.Should().NotBeNull();
            result.Should().AllBeOfType(typeof(User));
        }

        [Fact]
        public void ShouldFindUserByLogin()
        {
            //Arrange
            UserService userService = new UserService();
            User user = new User(1, "Andrzej", "Kowalski", "Janex");
            User userTwo = new User(2, "Andrzej", "Kowalski", "Panex");
            //Act
            userService.AddUser(user);
            userService.AddUser(userTwo);
            var result = userService.FindUserByLogin("Janex");
            var resultTwo = userService.FindUserByLogin("Janexs");
            //Assets
            result.Login.Should().Be("Janex");
            result.Id.Should().Be(1);
            result.Should().BeOfType(typeof(User));
            result.Should().NotBeNull();
            result.Should().Be(user);
            resultTwo.Should().BeNull(); 
        }

    }
}

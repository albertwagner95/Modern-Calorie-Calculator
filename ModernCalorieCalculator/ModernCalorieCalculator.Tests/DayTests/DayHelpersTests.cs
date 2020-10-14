using FluentAssertions;
using ModernCalorieCalculator.App.Managers.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ModernCalorieCalculator.Tests.DayTests
{
    public class DayHelpersTests
    {
        [Fact]
        public void ShouldValidateDateOfBirthFromUser()
        {
            //Arrange
            string d1 = "2000/10/20"; //should false
            string d2 = "13/33/200"; //should false
            string d3 = "12/12/2000"; //should true
            string d4 = "12/12/2000"; //should true
            string d5 = "02/29/2020"; //should true
            string d6 = "02/29/2021"; //should false
            string d7 = "02/32/2021"; //should false
            string d8 = "02832/2021"; //should false
            string d9 = "02832/20asd21"; //should false
            string d10 = "02832/2021 "; //should false
            string d11 = "2000/10/20 "; //should false
            string d12 = "2000-10-20 "; //should false
            string d13 = "12-12-2000 "; //should false
            string d14 = "12:12:2000 "; //should false
            string d15 = "12/08/2012 "; //should true


            //Act
            var result1 = DayManagerHelpers.ReturnDayFromString(d1);
            var result2 = DayManagerHelpers.ReturnDayFromString(d2);
            var result3 = DayManagerHelpers.ReturnDayFromString(d3);
            var result4 = DayManagerHelpers.ReturnDayFromString(d4);
            var result5 = DayManagerHelpers.ReturnDayFromString(d5);
            var result6 = DayManagerHelpers.ReturnDayFromString(d6);
            var result7 = DayManagerHelpers.ReturnDayFromString(d7);
            var result8 = DayManagerHelpers.ReturnDayFromString(d8);
            var result9 = DayManagerHelpers.ReturnDayFromString(d9);
            var result10 = DayManagerHelpers.ReturnDayFromString(d10);
            var result11 = DayManagerHelpers.ReturnDayFromString(d11);
            var result12 = DayManagerHelpers.ReturnDayFromString(d12);
            var result13 = DayManagerHelpers.ReturnDayFromString(d13);
            var result14 = DayManagerHelpers.ReturnDayFromString(d14);
            var result15 = DayManagerHelpers.ReturnDayFromString(d15);
            //var a = o[0]; 
            //Assert 
            result1.Should().Be(DateTime.MinValue);
            result2.Should().Be(DateTime.MinValue);
            result3.Should().Be(new DateTime(2000, 12, 12));
            result4.Should().Be(new DateTime(2000, 12, 12));
            result5.Should().Be(new DateTime(2020, 02, 29));
            result6.Should().Be(DateTime.MinValue);
            result7.Should().Be(DateTime.MinValue);
            result8.Should().Be(DateTime.MinValue);
            result9.Should().Be(DateTime.MinValue);
            result10.Should().Be(DateTime.MinValue);
            result11.Should().Be(DateTime.MinValue);
            result12.Should().Be(DateTime.MinValue);
            result13.Should().Be(DateTime.MinValue);
            result14.Should().Be(DateTime.MinValue);
            result15.Should().Be(new DateTime(2012, 12, 08));

        }
    }
}

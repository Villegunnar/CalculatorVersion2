using CalculatorVersion2;
using System;
using System.Collections.Generic;
using Xunit;

namespace CalculatiorVersion2.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void Adding_Multiple_Numbers_4_4_2_Return_10()
        {

            // Arrange
            Calculator myCal = new Calculator();

            List<double> userInputs = new List<double>();
            userInputs.Add(4);
            userInputs.Add(4);
            userInputs.Add(2);
            // Act

            var actual = myCal.Addition(userInputs);
            var result = 10;

            // Assert
            Assert.Equal(actual, result);

        }
        [Fact]
        public void Subtract_Multiple_Numbers_4_4_2_Return_negative2()
        {

            // Arrange
            Calculator myCal = new Calculator();

            List<double> userInputs = new List<double>();
            userInputs.Add(4);
            userInputs.Add(4);
            userInputs.Add(2);

            // Act

            var actual = myCal.Subtraction(userInputs);
            var result = -2;

            // Assert
            Assert.Equal(actual, result);

        }
        [Theory]
        [InlineData(6, 2, 3,1)]
        [InlineData(10, 2, 2,2.5)]
        [InlineData(100, 4, 5,5)]
        [InlineData(60, 10, 3,2)]
        [InlineData(-60, 3,0.5,-40)]
        public void Divide_Multiple_Numbers_and_return_Correct_Sum(double a, double b, double c, double expected)
        {
            // Arrange
            Calculator myCal = new Calculator();

            List<double> userInputs = new List<double>();
            userInputs.Add(a);
            userInputs.Add(b);
            userInputs.Add(c);
            // Act

            var actual = myCal.Division(userInputs);
            var result = expected;

            // Assert
            Assert.Equal(actual, result);


        }
        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(10, 2, 2, 40)]
        [InlineData(100, 4, 5, 2000)]
        [InlineData(-1, 10, 3, -30)]
        [InlineData(-60, 3, 0.5, -90)]
        public void Multiply_Multiple_Numbers_and_return_Correct_Sum(double a, double b, double c, double expected)
        {
            // Arrange
            Calculator myCal = new Calculator();

            List<double> userInputs = new List<double>();
            userInputs.Add(a);
            userInputs.Add(b);
            userInputs.Add(c);
            // Act

            var actual = myCal.Multiplication(userInputs);
            var result = expected;

            // Assert
            Assert.Equal(actual, result);


        }


        [Theory]
        [InlineData(6, 2, 3,"+","6 + 2 + 3 = 11")]
        [InlineData(10, 2, 2, "-", "10-2-2")]
        [InlineData(100, 4, 5, "/", "100 4/5 = 0")]
        [InlineData(60, 10, 3, "*", "60*10*3")]
        [InlineData(-60, 3, 0.5, "*", "-60*3*0,5")]
        public void StoreCalculation_Save_Calculation_Return_Same_Calculation(double a, double b, double c, string d, string expected)
        {
            // Arrange
            Calculator myCal = new Calculator();

            List<double> userInputs = new List<double>();
            userInputs.Add(a);
            userInputs.Add(b);
            userInputs.Add(c);
            // Act

            string actual = myCal.StoreCalculation( d, userInputs);
            string result = expected;
            
            // Assert
            Assert.Equal(actual, result);

        }
    }
}

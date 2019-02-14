using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Business;

namespace SudokuSolver.Tests.Business
{
    [TestClass]
    public class BoardValidatorTest
    {
        private readonly BoardValidator _boardValidator = new BoardValidator();

        [TestMethod]
        public void IsValid_True_Test()
        {
            // Arrange
            var boardHash =
                "123456789" +
                "234567891" +
                "345678912" +
                "456789123" +
                "567891234" +
                "678912345" +
                "789123456" +
                "891234567" +
                "912345678";

            var board = (new BoardHash()).LoadFromHash(boardHash);

            // Act
            var result = _boardValidator.IsValid(board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_False_Test()
        {
            // Arrange
            var boardHash =
                "123456789" +
                "234567891" +
                "345678912" +
                "456789123" +
                "567891234" +
                "678922345" +
                "789123456" +
                "891234567" +
                "912345678";

            var board = (new BoardHash()).LoadFromHash(boardHash);

            // Act
            var result = _boardValidator.IsValid(board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsComplete_True_Test()
        {
            // Arrange
            var boardHash =
                "123456789" +
                "234567891" +
                "345678912" +
                "456789123" +
                "567891234" +
                "678912345" +
                "789123456" +
                "891234567" +
                "912345678";

            var board = (new BoardHash()).LoadFromHash(boardHash);

            // Act
            var result = _boardValidator.IsComplete(board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsComplete_False_Test()
        {
            // Arrange
            var boardHash =
                "123456789" +
                "234567891" +
                "345678912" +
                "4567x9123" +
                "567891234" +
                "678912345" +
                "789123456" +
                "891234567" +
                "912345678";

            var board = (new BoardHash()).LoadFromHash(boardHash);

            // Act
            var result = _boardValidator.IsComplete(board);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

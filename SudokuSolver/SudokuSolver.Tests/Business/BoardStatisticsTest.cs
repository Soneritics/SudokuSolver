using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Business;
using SudokuSolver.Models;

namespace SudokuSolver.Tests.Business
{
    [TestClass]
    public class BoardStatisticsTest
    {
        [TestMethod]
        public void GetPossibilities_0Test()
        {
            // Arrange
            var hash = "123456789" +
                       "234567891" +
                       "345678912" +
                       "456789123" +
                       "567891234" +
                       "678912345" +
                       "789123456" +
                       "891234567" +
                       "912345678";
            var boardStatistics = GetBoardStatistics(hash);

            // Act
            var result = boardStatistics.GetPossibilities();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetPossibilities_1Test()
        {
            // Arrange
            var hash = "1234x6789" +
                       "234567891" +
                       "345678912" +
                       "456789123" +
                       "567891234" +
                       "678912345" +
                       "789123456" +
                       "891234567" +
                       "912345678";
            var boardStatistics = GetBoardStatistics(hash);

            // Act
            var result = boardStatistics.GetPossibilities();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetPossibilities_MultipleTest()
        {
            // Arrange
            var hash = "12x4x67x9" +
                       "23x5x78x1" +
                       "34xx78912" +
                       "456xx91x3" +
                       "5678x1234" +
                       "67xx12345" +
                       "xxxxxxxxx" +
                       "891234567" +
                       "912345678";
            var boardStatistics = GetBoardStatistics(hash);

            // Act
            var result = boardStatistics.GetPossibilities();

            // Assert
            Assert.AreEqual(153600, result);
        }

        [TestMethod]
        public void GetTotalFieldsTest()
        {
            // Arrange
            var board = new Board();
            var boardStatistics = new BoardStatistics(board, GetPossibilityCalculator(board));

            // Act
            var fields = boardStatistics.GetTotalFields();

            // Assert
            Assert.AreEqual(81, fields);
        }

        [TestMethod]
        public void GetOpenFieldsTest()
        {
            // Arrange
            var hash = "123456789" +
                       "23xx67891" +
                       "3456xx912" +
                       "456789123" +
                       "5678x1234" +
                       "678912345" +
                       "78912xx56" +
                       "891234567" +
                       "91234567x";
            var boardStatistics = GetBoardStatistics(hash);

            // Act
            var fields = boardStatistics.GetOpenFields();

            // Assert
            Assert.AreEqual(8, fields);
        }

        [TestMethod]
        public void GetFilledFieldsTest()
        {
            // Arrange
            var hash = "123456789" +
                       "23xx67891" +
                       "3456xx912" +
                       "456789123" +
                       "5678x1234" +
                       "678912345" +
                       "78912xx56" +
                       "891234567" +
                       "91234567x";
            var boardStatistics = GetBoardStatistics(hash);

            // Act
            var fields = boardStatistics.GetFilledFields();

            // Assert
            Assert.AreEqual(73, fields);
        }

        private PossibilityCalculator GetPossibilityCalculator(Board board) => new PossibilityCalculator(board);

        private BoardStatistics GetBoardStatistics(string hash)
        {
            var board = (new BoardHash()).LoadFromHash(hash);
            var possibilityCalculator = GetPossibilityCalculator(board);
            var boardStatistics = new BoardStatistics(board, possibilityCalculator);

            return boardStatistics;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Business;
using SudokuSolver.Models;

namespace SudokuSolver.Tests.Business
{
    [TestClass]
    public class PossibilityCalculatorTest
    {
        // Test if an existing value always returns this value
        [TestMethod]
        public void PossibilitiesFor_ExistingValueTest()
        {
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
            var possibilityCalculator = new PossibilityCalculator(board);

            for (var line = 0; line < board.Lines; line++)
                for (var column = 0; column < board.Columns; column++)
                    Assert.AreEqual(
                        board.GetBoardValue(line, column).Value,
                        possibilityCalculator.PossibilitiesFor(line, column).First()
                    );
        }

        // Test possible values for a line and column
        [TestMethod]
        public void PossibilitiesFor_EmptyFields()
        {
            // Arrange
            var boardHash = new BoardHash();
            var testSet = GetTestSet();

            foreach (var assert in testSet)
            {
                // Act
                var board = boardHash.LoadFromHash(assert.Hash);
                var possibilityCalculator = new PossibilityCalculator(board);

                var actual = possibilityCalculator.PossibilitiesFor(assert.Line, assert.Column);

                // Assert
                CollectionAssert.AreEqual(assert.ExpectedResult, actual);
            }
        }

        private List<PossibilityCalculaterAssert> GetTestSet()
        {
            return PossibilityCalculatorTestSet.TestSet;
        }
    }
}

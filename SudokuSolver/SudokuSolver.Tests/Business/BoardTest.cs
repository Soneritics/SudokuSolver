using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Business;
using SudokuSolver.Models;

namespace SudokuSolver.Tests.Business
{
    [TestClass]
    public class BoardTest
    {
        private string _emptyHash = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

        [TestMethod]
        public void TestClearBoard()
        {
            var board = new Board();
            var hashGenerator = new BoardHash();

            // First check if the newly created board is empty
            Assert.AreEqual(_emptyHash, hashGenerator.GetHash(board));

            // Change the board to see if they're not empty
            board.SetBoardValue(1, 1, new BoardValue(1));
            Assert.AreNotEqual(_emptyHash, hashGenerator.GetHash(board));

            // Clear and check if it's empty
            board.Clear();
            Assert.AreEqual(_emptyHash, hashGenerator.GetHash(board));
        }
    }
}

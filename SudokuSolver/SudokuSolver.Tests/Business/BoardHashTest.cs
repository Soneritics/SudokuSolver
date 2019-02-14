using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Business;
using SudokuSolver.Models;

namespace SudokuSolver.Tests.Business
{
    [TestClass]
    public class BoardGeneratorTest
    {
        private string _emptyHash = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

        [TestMethod]
        public void TestGenerateEmptyBoard()
        {
            var hashGenerator = new BoardHash();
            var board = new Board();

            var hash = hashGenerator.GetHash(board);

            Assert.AreEqual(_emptyHash, hash);
        }

        [TestMethod]
        public void TestLoadBoardFromHash()
        {
            var hashGenerator = new BoardHash();
            var hash = String.Empty;

            for (int line = 0; line < 9; line++)
                for (int column = 0; column < 9; column++)
                    hash += column + 1;

            var board = hashGenerator.LoadFromHash(hash);
            Assert.AreEqual(hash, hashGenerator.GetHash(board));
        }
    }
}

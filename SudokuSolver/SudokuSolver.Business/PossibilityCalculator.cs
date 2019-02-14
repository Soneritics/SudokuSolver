using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Models;

namespace SudokuSolver.Business
{
    public class PossibilityCalculator : IPossibilityCalculator
    {
        private readonly Board _board;

        public PossibilityCalculator(Board board)
        {
            _board = board;
        }

        // Get the possible values for a field in the board
        public List<int> PossibilitiesFor(int line, int column)
        {
            // If already has a value, return that value
            if (_board.GetBoardValue(line, column).Value > 0)
            {
                return new List<int>() { _board.GetBoardValue(line, column).Value };
            }

            var result = new List<int>();
            var impossibilities = new List<int>();

            // Loop horizontal
            for (var i = 0; i < _board.Columns; i++)
            {
                var value = _board.GetBoardValue(line, i).Value;

                if (value > 0)
                {
                    impossibilities.Add(value);
                }
            }

            // Loop vertical
            for (var i = 0; i < _board.Lines; i++)
            {
                var value = _board.GetBoardValue(i, column).Value;

                if (value > 0)
                {
                    impossibilities.Add(value);
                }
            }

            // Check possible values
            for (var i = 1; i <= 9; i++)
            {
                if (!impossibilities.Contains(i) && !result.Contains(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Business.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Business
{
    public class BoardStatistics
    {
        private readonly Board _board;
        private readonly IPossibilityCalculator _possibilityCalculator;

        public BoardStatistics(Board board, IPossibilityCalculator possibilityCalculator)
        {
            _board = board;
            _possibilityCalculator = possibilityCalculator;
        }

        // Calculate the total number of possibilities
        public long GetPossibilities()
        {
            long possibilities = 0;

            for (var line = 0; line < _board.Lines; line++)
            {
                for (var column = 0; column < _board.Columns; column++)
                {
                    var value = _board.GetBoardValue(line, column).Value;

                    if (value == 0)
                    {
                        possibilities = possibilities == 0 ? 1 : possibilities;
                        possibilities *= _possibilityCalculator.PossibilitiesFor(line, column).Count;
                    }
                }
            }

            return possibilities;
        }

        // Get the total number of fields
        public int GetTotalFields() => _board.Columns * _board.Lines;

        // Get the total number of filled fields
        public int GetFilledFields()
        {
            var fields = 0;

            for (var line = 0; line < _board.Lines; line++)
            {
                for (var column = 0; column < _board.Columns; column++)
                {
                    var value = _board.GetBoardValue(line, column).Value;

                    if (value > 0)
                    {
                        fields++;
                    }
                }
            }

            return fields;
        }

        public int GetOpenFields() => GetTotalFields() - GetFilledFields();
    }
}

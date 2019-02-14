﻿using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Models;

namespace SudokuSolver.Business
{
    public class BoardValidator
    {
        // Check if the board is valid
        public bool IsValid(Board board)
        {
            // Loop horizontal
            for (var line = 0; line < board.Lines; line++)
            {
                var items = new List<int>();

                for (var column = 0; column < board.Columns; column++)
                {
                    var value = board.GetBoardValue(line, column).Value;

                    if (value > 0)
                    {
                        if (items.Contains(value))
                        {
                            return false;
                        }

                        items.Add(value);
                    }
                }
            }

            // Loop vertical
            for (var column = 0; column < board.Columns; column++) 
            {
                var items = new List<int>();

                for (var line = 0; line < board.Lines; line++)
                {
                    var value = board.GetBoardValue(line, column).Value;

                    if (value > 0)
                    {
                        if (items.Contains(value))
                        {
                            return false;
                        }

                        items.Add(value);
                    }
                }
            }

            return true;
        }

        // Check if the board is complete
        public bool IsComplete(Board board)
        {
            var stats = GetBoardStatistics(board);
            return stats.GetFilledFields() == stats.GetTotalFields() && IsValid(board);
        }

        // Get BoardStatistics object
        private BoardStatistics GetBoardStatistics(Board board) =>
            new BoardStatistics(board, new PossibilityCalculator(board));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models
{
    public class Board
    {
        private BoardValue[,] _board;

        public int Lines { get; private set; } = 3 * 3;
        public int Columns { get; private set; } = 3 * 3;

        // Create an empty board
        public Board()
        {
            Clear();
        }

        // Return the BoardValue of a specific line and column
        public BoardValue GetBoardValue(int line, int column)
        {
            return _board[line, column];
        }

        // Set board value for a specific column on a specific line
        public void SetBoardValue(int line, int column, BoardValue value)
        {
            _board[line, column] = value;
        }

        // Clear the board
        public void Clear()
        {
            _board = new BoardValue[Lines, Columns];

            for (var line = 0; line < Lines; line++)
            {
                for (var column = 0; column < Columns; column++)
                    _board[line, column] = new BoardValue();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models
{
    public class BoardValue
    {
        public int Value { get; set; }
        public bool IsProvided { get; set; }

        public BoardValue()
        {
            IsProvided = false;
            Value = 0;
        }

        public BoardValue(int value)
        {
            IsProvided = true;
            Value = value;
        }
    }
}

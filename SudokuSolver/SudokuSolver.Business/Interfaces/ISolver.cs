using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Models;

namespace SudokuSolver.Business.Interfaces
{
    public interface ISolver
    {
        Board Solve(Board board);
    }
}

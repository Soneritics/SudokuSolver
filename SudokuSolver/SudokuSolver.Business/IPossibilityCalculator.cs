using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Business
{
    public interface IPossibilityCalculator
    {
        List<int> PossibilitiesFor(int line, int column);
    }
}

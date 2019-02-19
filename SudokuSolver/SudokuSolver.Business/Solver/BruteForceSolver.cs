using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Business.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Business.Solver
{
    class BruteForceSolvingPossibility
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public List<int> Possibilities { get; set; }
    }

    public class BruteForceSolver : ISolver
    {
        public long Attempts { get; private set; }  = 0;
        private BoardValidator _boardValidator = new BoardValidator();

        public Board Solve(Board board)
        {
            var possibilityCalculator = new PossibilityCalculator(board);

            // Get the brute force possibilities
            var bruteForceSolvingPossibilities = new List<BruteForceSolvingPossibility>();
            for (var line = 0; line < board.Lines; line++)
            {
                for (var column = 0; column < board.Columns; column++)
                {
                    var value = board.GetBoardValue(line, column);

                    if (!value.IsProvided)
                    {
                        bruteForceSolvingPossibilities.Add(
                            new BruteForceSolvingPossibility()
                            {
                                Column = column,
                                Line = line,
                                Possibilities = possibilityCalculator.PossibilitiesFor(line, column)
                            }
                        );
                    }
                }
            }

            // Brute force solve the board
            return GetSolution(board, bruteForceSolvingPossibilities, 0);
        }

        private Board GetSolution(Board board, List<BruteForceSolvingPossibility> possibilities, int possibility)
        {
            if (_boardValidator.IsComplete(board))
                return board;

            if (possibility >= possibilities.Count)
                throw new Exception("Board is unsolvable!"); // @todo make specific exception type

            if (possibilities[possibility].Possibilities.Count == 0)
                throw new Exception("No possibilities for this field!"); // @todo make specific exception type

            foreach (var nr in possibilities[possibility].Possibilities)
            {
                Attempts++;

                board.SetBoardValue(possibilities[possibility].Line, possibilities[possibility].Column, new BoardValue(nr));

                if (_boardValidator.IsComplete(board))
                    return board;

                if (_boardValidator.IsValid(board) && possibility < possibilities.Count)
                {
                    board = GetSolution(board, possibilities, possibility + 1);

                    if (_boardValidator.IsComplete(board))
                        return board;
                }
            }

            // Reset the value
            board.SetBoardValue(possibilities[possibility].Line, possibilities[possibility].Column, new BoardValue());
            return board;
        }
    }
}

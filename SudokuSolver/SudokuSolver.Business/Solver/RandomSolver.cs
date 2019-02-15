using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Business.Interfaces;
using SudokuSolver.Models;

namespace SudokuSolver.Business.Solver
{
    public class RandomSolver : ISolver
    {
        private readonly BoardHash _boardHash = new BoardHash();
        private readonly BoardValidator _boardValidator = new BoardValidator();
        private readonly Random _random = new Random();

        public int Attempts { get; protected set; } = 0;

        // Solve the board
        public Board Solve(Board board)
        {
            Attempts = 0;
            var hash = _boardHash.GetHash(board);
            Board result;

            do
            {
                result = GetRandomBoard(hash);
                Attempts++;
            } while (!_boardValidator.IsComplete(result));

            return result;
        }

        // Get the board randomly filled
        private Board GetRandomBoard(string hash)
        {
            var result = _boardHash.LoadFromHash(hash);
            var possibilityCalculator = new PossibilityCalculator(_boardHash.LoadFromHash(hash));

            for (var line = 0; line < result.Lines; line++)
            {
                for (var column = 0; column < result.Columns; column++)
                {
                    var value = result.GetBoardValue(line, column);

                    if (!value.IsProvided)
                    {
                        var possibilities = possibilityCalculator.PossibilitiesFor(line, column);
                        var rnd = _random.Next(possibilities.Count);
                        var newValue = possibilities[rnd];
                        result.SetBoardValue(line, column, new BoardValue(newValue));
                    }
                }
            }

            return result;
        }
    }
}

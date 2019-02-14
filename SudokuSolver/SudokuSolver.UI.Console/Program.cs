using SudokuSolver.Business;
using SudokuSolver.Business.Solver;
using SudokuSolver.Models;

namespace SudokuSolver.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Board values in 1 line. x for unknown value. ");
            var hash = System.Console.ReadLine();

            System.Console.WriteLine("\n\nStarting solving..");

            var solver = new RandomSolver();
            var result = solver.Solve((new BoardHash()).LoadFromHash(hash));

            System.Console.WriteLine($"Solved in {solver.Attempts} attempts.\n\n");
            OutputBoard(result);
        }

        public static void OutputBoard(Board board)
        {
            System.Console.WriteLine("+---------+---------+---------+");

            for (var line = 0; line < board.Lines; line++)
            {
                System.Console.Write("|");
                for (var column = 0; column < board.Columns; column++)
                {
                    System.Console.Write($" {board.GetBoardValue(line, column).Value} ");

                    if (column % 3 == 2)
                    {
                        System.Console.Write("|");
                    }
                }
                System.Console.WriteLine();

                if (line % 3 == 2)
                {
                    System.Console.WriteLine("+---------+---------+---------+");
                }
            }
        }
    }
}

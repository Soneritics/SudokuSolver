using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Models;

namespace SudokuSolver.Business
{
    public class BoardHash
    {
        public string GetHash(Board board)
        {
            var result = String.Empty;

            for (var line = 0; line < board.Lines; line++)
            {
                for (var column = 0; column < board.Columns; column++)
                {
                    var boardValue = board.GetBoardValue(line, column);
                    result += boardValue.IsProvided ? boardValue.Value.ToString() : "x";
                }
            }

            return result;
        }

        public Board LoadFromHash(string hash)
        {
            var result = new Board();

            var line = 0;
            var column = 0;
            var character = 0;
            while (line < 9 && character < hash.Length)
            {
                var value = hash[character++].ToString();

                if (int.TryParse(value, out var intValue))
                    result.SetBoardValue(line, column, new BoardValue(intValue));

                column++;
                if (column == 9)
                {
                    line++;
                    column = 0;
                }
            }

            return result;
        }
    }
}

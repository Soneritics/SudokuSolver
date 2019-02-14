using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Tests.Business
{
    public class PossibilityCalculaterAssert
    {
        public string Hash { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
        public List<int> ExpectedResult { get; set; }
    }

    public static class PossibilityCalculatorTestSet
    {
        public static List<PossibilityCalculaterAssert> TestSet { get; private set; } = new List<PossibilityCalculaterAssert>()
        {
            new PossibilityCalculaterAssert()
            {
                Hash = "1234x6789" +
                       "234567891" +
                       "345678912" +
                       "456789123" +
                       "5678x1234" +
                       "678912345" +
                       "789123456" +
                       "8912x4567" +
                       "912345678",
                Line = 0,
                Column = 4,
                ExpectedResult = new List<int>() { 5 }
            },

            new PossibilityCalculaterAssert()
            {
                Hash = "12x4x678x" +
                       "234567891" +
                       "345678912" +
                       "456789123" +
                       "5678x1234" +
                       "678912345" +
                       "789123456" +
                       "8912x4567" +
                       "912345678",
                Line = 0,
                Column = 4,
                ExpectedResult = new List<int>() { 3, 5, 9 }
            },
        };
    }
}

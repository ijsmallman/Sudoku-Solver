using System;
using System.Collections.Generic;

namespace Sudoku
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(@"
Joe's Sudoku Solver
===================
Program to solve sudokus using various techniques.
");

            string path;
            if (args.Length > 0)
                path = args[0];
            else
                path = @"9x9sudoku.txt";

            ISudokuReader reader = new BasicSudokuReader();
            ISudokuPrinter printer = new BasicSudokuPrinter();
            Sudoku sudoku = reader.Read(path);

            Console.WriteLine("Unsolved Sudoku:");
            printer.Print(sudoku);

            List<ISudokuSolverStrategy> strategies = new List<ISudokuSolverStrategy>
            {
                new DepthFirstBacktrackingRecursiveStrategy(),
                new DepthFirstBacktrackingStrategy(),
                new BreadthFirstStrategy(),
                new MultithreadedStrategy(3)
            };

            foreach (ISudokuSolverStrategy strategy in strategies)
            {
                Console.WriteLine("\nSolving...");
                DateTime start = DateTime.Now;
                Sudoku solvedSudoku = new SudokuSolver(strategy).Solve(sudoku);
                Console.WriteLine("Solved Sudoku in {0}ms:",
                    (int)(DateTime.Now - start).Duration().TotalMilliseconds);
                printer.Print(solvedSudoku);
            }
            Console.WriteLine("\nDone");
            Console.ReadKey();
        }
    }
}


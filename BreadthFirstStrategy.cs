using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class BreadthFirstStrategy : ISudokuSolverStrategy
    {
        private Sudoku Sudoku;

        public Sudoku Solve(Sudoku sudoku)
        {
            // It seems concevable to me that there may not be
            // a starting point where there is only one option.
            // Therefore we may need to search multiple trees.
            Console.WriteLine("WARNING: This may require a large amount of memory.");
            Sudoku = sudoku;
            int firstPos = Sudoku.FindZero();
            foreach (int i in Sudoku.AvailableNumbers(firstPos))
            {
                Sudoku.Values[firstPos] = i;
                if (BreadthFirstSearch(new Node(firstPos, i, false, Sudoku))) break;
            }
            return Sudoku;
        }

        public bool BreadthFirstSearch(Node start)
        {
            Queue<Node> queue = new Queue<Node>();
            Node currentNode;

            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                currentNode.GenerateChildrenAndRecordSudoku();

                foreach (Node child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
                if (currentNode.CurrentSudoku.Complete())
                {
                    Sudoku = currentNode.CurrentSudoku;
                    return true;
                }
            }
            return false;
        }
    }
}


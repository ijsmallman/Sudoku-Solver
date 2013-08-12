using System;
using System.Collections.Generic;

namespace Sudoku
{
	public class DepthFirstBacktrackingStrategy : ISudokuSolverStrategy
	{
        private Sudoku Sudoku;

		public Sudoku Solve(Sudoku sudoku)
		{
			// It seems concevable to me that there may not be
			// a starting point where there is only one option.
			// Therefore we may need to search multiple trees.
            Sudoku = new Sudoku(sudoku);
			int firstPos = Sudoku.FindZero();
			foreach (int i in sudoku.AvailableNumbers(firstPos))
			{
				if (DepthFirstSearch(Sudoku, new Node(firstPos, i, false))) break;
			}
			return Sudoku;
		}
		
		public static bool DepthFirstSearch(Sudoku sudoku, Node start)
		{
			Stack<Node> stack = new Stack<Node>();
			Node currentNode;
			
			stack.Push(start);
			while ( stack.Count > 0 )
			{
				currentNode = stack.Peek();
				if (!currentNode.Visited)
				{
					sudoku.Values[currentNode.Pos] = currentNode.Value;
					currentNode.GenerateChildren(sudoku);
					currentNode.Visited = true;
				}

                List<Node> unvisitedChildren = currentNode.Children.FindAll(c => !c.Visited);
                if (unvisitedChildren.Count > 0)
				{
                    Node child = unvisitedChildren[0];
					stack.Push(child);
					sudoku.Values[child.Pos] = child.Value;
				}
                else
                {
                    stack.Pop();
                    if (sudoku.Complete())
                    {
                        sudoku.Solved = true;
                        return true;
                    }
                    sudoku.Values[currentNode.Pos] = 0;
                }
			}
			return false;
		}
	}
}


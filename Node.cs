using System;
using System.Collections.Generic;

namespace Sudoku
{
    public class Node
    {
        public int Pos { get; set; }
        public int Value { get; set; }
        public bool Visited { get; set; }

        private List<Node> _Children = new List<Node>();
        public List<Node> Children { get { return _Children; } }

        private Sudoku _CurrentSudoku = null;
        public Sudoku CurrentSudoku { get { return _CurrentSudoku; } }

        public Node(int pos, int value, bool visited) : this(pos, value, visited, null) {}
        public Node(int pos, int value, bool visited, Sudoku sudoku)
        {
            Pos = pos;
            Value = value;
            Visited = visited;
            if (sudoku != null) _CurrentSudoku = new Sudoku(sudoku);
        }

        public void GenerateChildren(Sudoku sudoku)
        {
            int nextPos = sudoku.FindZero();
            if (nextPos != -1)
            {
                foreach (int i in sudoku.AvailableNumbers(nextPos))
                {
                    Children.Add(new Node(nextPos, i, false));
                }
            }
        }
        public void GenerateChildrenAndRecordSudoku()
        {
            int nextPos = CurrentSudoku.FindZero();
            if (nextPos != -1)
            {
                foreach (int i in CurrentSudoku.AvailableNumbers(nextPos))
                {
                    Sudoku childSudoku = new Sudoku(CurrentSudoku);
                    childSudoku.Values[nextPos] = i;
                    Children.Add(new Node(nextPos, i, false, childSudoku));
                }
            }
        }
    }
}


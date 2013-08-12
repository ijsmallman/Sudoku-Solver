using System;
using System.Collections.Generic;

namespace Sudoku
{
	public class Sudoku
	{
        private List<int> _Values = new List<int>();
        public List<int> Values { get { return _Values; } }
		public int MaxValue { get; set; }

        private int _SqrtMaxValue;
        public int SqrtMaxValue { get { return _SqrtMaxValue; } }

        private int _SecRowCount;
        public int SecRowCount { get { return _SecRowCount; } }

		public bool Solved { get; set; }
		
		public Sudoku (Sudoku init)
		{
			MaxValue = init.MaxValue;
			_SqrtMaxValue = init.SqrtMaxValue;
			_SecRowCount = init.SecRowCount;
			Solved = init.Solved;
            _Values = new List<int>(init.Values);
		}
		
		public Sudoku (List<int> initValues)
		{
			MaxValue = (int)Math.Sqrt(initValues.Count);
			_SqrtMaxValue = (int)Math.Sqrt(Math.Sqrt(initValues.Count));
			_SecRowCount = SqrtMaxValue*MaxValue;
            _Values = new List<int>(initValues);
		}
		
        public HashSet<int> SameRow(int pos)
        {
            int rowStartPos = pos - (pos % MaxValue);
            HashSet<int> sameRow = new HashSet<int>();
            for (int i = 0; i < MaxValue; i++)
            {
                sameRow.Add(Values[rowStartPos + i]);
            }
            return sameRow;
        }

        public HashSet<int> SameCol(int pos)
        {
            int colStartPos = pos % MaxValue;
            HashSet<int> sameCol = new HashSet<int>();
            for (int i = 0; i < MaxValue; i++)
            {
                sameCol.Add(Values[colStartPos + i * MaxValue]);
            }
            return sameCol;
        }
		
        public HashSet<int> SameSec(int pos)
        {
            int colStartPos = (pos % MaxValue) - (pos % SqrtMaxValue);
            int rowStartPos = pos - (pos % SecRowCount);
            HashSet<int> sameSec = new HashSet<int>();
            for (int i = 0; i < SqrtMaxValue; i++)
            {
                for (int j = 0; j < SqrtMaxValue; j++)
                {
                    sameSec.Add(Values[rowStartPos + colStartPos + j + i * MaxValue]);
                }
            }
            return sameSec;
        }
		
		public HashSet<int> ExcludedNumbers(int pos)
		{
            HashSet<int> excludedNums = SameCol(pos);
            excludedNums.UnionWith(SameRow(pos));
            excludedNums.UnionWith(SameSec(pos));
			return excludedNums;
		}
		
		public HashSet<int> AvailableNumbers(int pos)
		{
            HashSet<int> excludedNums = ExcludedNumbers(pos);
            HashSet<int> availableNumbers = new HashSet<int>();
			for (int i = 1; i < (MaxValue + 1); i++)
			{
				if (!excludedNums.Contains(i)) availableNumbers.Add(i);
			}
			return availableNumbers;
		}
		
		public int FindZero()
		{
            return Values.FindIndex(v => v == 0);
		}

        public bool Complete()
        {
            return !Values.Contains(0);
        }
	}
}


using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;

namespace Sudoku
{
    public class MultithreadedStrategy : ISudokuSolverStrategy
    {
        
        private Sudoku Sudoku;
        private List<Thread> ThreadList = new List<Thread>();
        private Object solvedLocker = new Object();
        ManualResetEvent stop = new ManualResetEvent(false);
        private void SetCompleted() { stop.Set(); }
        private int threads;
        private ConcurrentQueue<Node> queue = new ConcurrentQueue<Node>();

        public MultithreadedStrategy(int t)
        {
            threads = t;
        }
        
        public Sudoku Solve(Sudoku sudoku)
        {
            // It seems concevable to me that there may not be
            // a starting point where there is only one option.
            // Therefore we may need to search multiple trees.
            Console.WriteLine("WARNING: This may require a large amount of memory.");
            Sudoku = sudoku;
            
            //Throw nodes on queue
            int firstPos = Sudoku.FindZero();
            foreach (int i in Sudoku.AvailableNumbers(firstPos))
            {
                Sudoku.Values[firstPos] = i;
                queue.Enqueue(new Node(firstPos, i, false, Sudoku));
            }

            //Setup threads
            for (int i = 0; i < threads; i++)
            {
                ThreadList.Add(new Thread(new ThreadStart(ProcessQueue)));
                ThreadList[i].Name = String.Format("Thread {0}", i + 1);
            }

            //Set them running
            foreach (Thread t in ThreadList)
                t.Start();

            //Wait until solution found (optional timeout?)
            foreach (Thread t in ThreadList)
                t.Join();

            return Sudoku;
        }


        public void ProcessQueue()
        {
            Console.WriteLine("{0} running...",Thread.CurrentThread.Name);

            Node currentNode;

            while (!stop.WaitOne(0))
            {
                if (queue.TryDequeue(out currentNode))
                {
                    currentNode.GenerateChildrenAndRecordSudoku();

                    foreach (Node child in currentNode.Children)
                    {
                        queue.Enqueue(child);
                    }

                    // Only 1 thread will have the solution (no?)
                    // so no need to be careful about locking
                    if (currentNode.CurrentSudoku.Complete())
                    {
                        Sudoku = currentNode.CurrentSudoku;
                        SetCompleted();
                    }
                }
            }
        }
    }
}


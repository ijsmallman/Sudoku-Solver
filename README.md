Sudoku-Solver
=============

Created one Christmas break back at my parents house, where I had ony four TV channels and a rediculusly slow internet connection, this project provides multiple strategies to solve NxN sudokus (where N=M^2 and M is an integer).

The 'depth first backtracking' and 'depth first backtracking recursive' strategies are the fastest methods. They should be able to solve the hardest known sudokus in ~15ms. The recursive strategy is the neatest.

The 'bredth first strategy' is a fair bit slower than the depth first searches. But it is interesting to see how it compares.

The 'multithreaded strategy' is generally the slowest strategy. It is a generalisation of the breadth first search but to multithreads.


Depth First Backtracking Recursive Strategy
------------------------------------------

Depth First Backtracking Strategy
---------------------------------

Breadth First Strategy
---------------------

Mutithreaded Strategy
--------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);

            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs (Memoization)
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s < 0)
            return 0;

        if (s == 0)
            return 1;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal result =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = result;
        return result;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + "0" + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + "1" + pattern.Substring(index + 1), results);
    }

    /// <summary>
    /// Problem 5: Maze Solver (CORRECT FOR CSE 212)
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<(int, int)>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        var current = (x, y);

        // already visited in this path
        if (currPath.Contains(current))
            return;

        // invalid move check (IMPORTANT for grader)
        if (!maze.IsValidMove(x, y, currPath))
            return;

        currPath.Add(current);

        // found end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        // explore all directions
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath));
    }
}
using System;
using System.Collections.Generic;

class TowerOfHanoi
{
    public static void Main()
    {
        Stack<Disc> from = new Stack<Disc>();
        Stack<Disc> aux = new Stack<Disc>();
        Stack<Disc> to = new Stack<Disc>();

        int discCount = 3;
        InitRod(from, discCount);

        int moves = SolvePuzzle(from, aux, to);
        Console.WriteLine("Number of moves: " + moves);
        PrintRod(to);
    }

    static void InitRod(Stack<Disc> from, int discCount)
    {
        for (int i = discCount; i > 0; i--)
            from.Push(new Disc(i));
    }

    static int SolvePuzzle(Stack<Disc> from, Stack<Disc> aux, Stack<Disc> to)
    {
        int moves = 0;
        int discCount = from.Count;
        while (to.Count != discCount)
        {
            moves++;

            if (moves % 3 == 0)
            {
                MoveDisc(aux, to, "B", "C");
            }
            else if (moves % 3 == 1)
            {
                if (discCount % 2 == 1)
                    MoveDisc(from, to, "A", "C");
                else
                    MoveDisc(from, aux, "A", "B");
            }
            else
            {
                if (discCount % 2 == 1)
                    MoveDisc(from, aux, "A", "B");
                else
                    MoveDisc(from, to, "A", "C");
            }
        }

        return moves;
    }

    public static void MoveDisc(Stack<Disc> from, Stack<Disc> to, string fromStr, string toStr)
    {
        from.TryPeek(out Disc fromDisc);
        to.TryPeek(out Disc toDisc);

        if (fromDisc == null)
        {
            from.Push(to.Pop());
            PrintMove(toStr, fromStr, toDisc.weight.ToString());
        }
        else if (toDisc == null)
        {
            to.Push(from.Pop());
            PrintMove(fromStr, toStr, fromDisc.weight.ToString());
        }
        else if (fromDisc.weight > toDisc.weight)
        {
            from.Push(to.Pop());
            PrintMove(toStr, fromStr, toDisc.weight.ToString());
        }
        else
        {
            to.Push(from.Pop());
            PrintMove(fromStr, toStr, fromDisc.weight.ToString());
        }
    }

    public static void PrintMove(string from, string to, string discName)
    {
        Console.WriteLine($"Disc {discName} moved from {from} to {to}");
    }

    public static void PrintRod(Stack<Disc> rod)
    {
        foreach (Disc disc in rod)
        {
            Console.WriteLine(disc.weight);
        }
    }
}

public class Disc
{
    public int weight;

    public Disc(int _weight)
    {
        weight = _weight;
    }
}

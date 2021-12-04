using System;
using System.Collections.Generic;
using System.IO;

class Day4
{
    public static void RunPart1()
    {
        // Part 1
        string[] input = File.ReadAllLines(@"../../../inputs/Day4.txt");
        List<int> drawNumbers = ConvertArrStrToArrInt(input[0].Split(','));
        List<int[][]> boards = GetBoards(input);

        int row = 0;
        int column = 0;
        int found = -1;
        int boardNumber = 0;
        foreach (int number in drawNumbers)
        {
            boardNumber = 0;
            foreach (int[][] board in boards)
            {
                found = -1;
                for (int x = 0; x < 5; x++)
                {
                    row = 0;
                    for (int y = 0; y < 5; y++)
                    {
                        if (board[x][y] == number) board[x][y] = -1;
                        row += board[x][y];
                    }
                    if (row == -5) break;
                }
                if (row == -5) break;
                for (int y = 0; y < 5; y++)
                {
                    column = 0;
                    for (int x = 0; x < 5; x++) column += board[x][y];
                    if (column == -5) break;
                }
                if (column == -5) break;
                boardNumber++;
            }
            if (column == -5 || row == -5)
            {
                found = number;
                break;
            }
            
        }

        int[][]  winner = boards.ToArray()[boardNumber];
        int totalNotmarked = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (winner[x][y] > -1) totalNotmarked += winner[x][y];
            }
        }

        Console.WriteLine(found);
        Console.WriteLine(boardNumber);
        Console.WriteLine(totalNotmarked);
        Console.WriteLine(totalNotmarked * found);

    }

    public static void RunPart2()
    {
        // Part 2
        string[] input = File.ReadAllLines(@"../../../inputs/Day4.txt");
        List<int> drawNumbers = ConvertArrStrToArrInt(input[0].Split(','));
        List<int[][]> boards = GetBoards(input);

        int row = 0;
        int column = 0;
        int found = -1;
        int boardNumber = 0;
        int counter = boards.Count;
        foreach (int number in drawNumbers)
        {
            boardNumber = 0;
            foreach (int[][] board in boards)
            {
                if (board[0][0] != -666)
                {
                    found = -1;
                    for (int x = 0; x < 5; x++)
                    {
                        row = 0;
                        for (int y = 0; y < 5; y++)
                        {
                            if (board[x][y] == number) board[x][y] = -1;
                            row += board[x][y];
                        }
                        if (row == -5) break;
                    }
                    if (row == -5) {
                        counter--;
                        if (counter != 0) board[0][0] = -666;
                    } else
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            column = 0;
                            for (int x = 0; x < 5; x++) column += board[x][y];
                            if (column == -5) break;
                        }
                        if (column == -5)
                        {
                            counter--;
                            if (counter != 0) board[0][0] = -666;
                        }

                    }

                    if (counter == 0)
                    {
                        break;
                    }
                }
                boardNumber++;
            }
            if (counter == 0)
            {
                found = number;
                break;
            }

        }

        int[][] winner = boards.ToArray()[boardNumber];
        int totalNotmarked = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (winner[x][y] > -1) totalNotmarked += winner[x][y];
            }
        }

        Console.WriteLine(found);
        Console.WriteLine(boardNumber);
        Console.WriteLine(totalNotmarked);
        Console.WriteLine(totalNotmarked * found);

    }

    public static List<int> ConvertArrStrToArrInt(string[] arrStr)
    {
        List<int> listInt = new();
        foreach (string str in arrStr) listInt.Add(Convert.ToInt32(str));
        return listInt;
    }

    public static List<int[][]> GetBoards(string[] input)
    {
        List<int[][]> boards = new();
        for (int i = 2; i < input.Length; i++)
        {
            string line = input[i];
            if (line.Length > 0)
            {
                int[][] board = new int[5][];
                for (int x = 0; x < 5; x++)
                {
                    board[x] = ConvertArrStrToArrInt(input[i + x]
                        .Trim().Replace("  ", " ").Split(' ')).ToArray();
                }
                i += 4;
                boards.Add(board);
            }
        }
        return boards;
    }
}

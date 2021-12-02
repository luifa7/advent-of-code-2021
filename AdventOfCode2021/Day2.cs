using System;
using System.IO;

class Day2
{
    public static void RunPart1()
    {
        // Part 1
        string[] input = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../inputs/Day2.txt"));
        int position = 0;
        int depth = 0;
        foreach (string line in input)
        {
            string[] subs = line.Split(' ');
            string direction = subs[0];
            int value = Int32.Parse(subs[1]);
            if (direction.Equals("forward")) position += value;
            else if (direction.Equals("down")) depth += value;
            else if (direction.Equals("up")) depth -= value;

        }
        Console.WriteLine(position * depth);
    }

    public static void RunPart2()
    {
        // Part 2
        string[] input = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../inputs/Day2.txt"));
        int position = 0;
        int depth = 0;
        int aim = 0;

        foreach (string line in input)
        {
            string[] subs = line.Split(' ');
            string direction = subs[0];
            int value = Int32.Parse(subs[1]);
            if (direction.Equals("forward"))
            {
                position += value;
                depth += (aim * value);
            }
            else if (direction.Equals("down")) aim += value;
            else if (direction.Equals("up")) aim -= value;

        }
        Console.WriteLine(position * depth);
    }
}
using System;
using System.IO;

class Day1
{
    public static void RunPart1()
    {
        // Part 1
        string[] input = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../inputs/Day1.txt"));
        int counter = 0;
        int previous = Int32.Parse(input[0]);
        foreach (string line in input)
        {
            int parsed = Int32.Parse(line);
            if (parsed > previous) counter++;
            previous = parsed;
        }
        Console.WriteLine(counter);
    }

    public static void RunPart2()
    {
        // Part 2
        string[] input = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../inputs/Day1.txt"));
        int increasesCounter = 0;

        int firstGourpCounter = 0;
        int secondGroupCounter = 0;

        int firstGroup = 0;
        int secondGroup = 0;

        for (int i = 0; i < input.Length; i++)
        {

            int parsed = Int32.Parse(input[i]);
            if (firstGourpCounter < 3)
            {
                firstGroup += parsed;
                firstGourpCounter++;
            }
            if (firstGourpCounter > 1 && secondGroupCounter < 3)
            {
                secondGroup += parsed;
                secondGroupCounter++;
            }
            if (secondGroupCounter == 3)
            {
                Console.WriteLine(firstGroup + ", " + secondGroup);
                if (secondGroup > firstGroup) increasesCounter++;
                secondGroupCounter = 0;
                firstGroup = secondGroup;
                secondGroup = 0;
                i-= 2;
            }
           
        }
        Console.WriteLine(increasesCounter);
    }
}
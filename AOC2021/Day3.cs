using System;
using System.Collections.Generic;
using System.IO;

class Day3
{
    public static void RunPart1()
    {
        // Part 1
        string[] input = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../inputs/Day3.txt"));
        bool[] mostRepeated = GetMostRepeatedArray(input);

        string gammaRate = "";
        string epsilonRate = "";

        foreach (bool value in mostRepeated)
        {
            if (value)
            {
                gammaRate += "1";
                epsilonRate += "0";
            }
            else
            {
                gammaRate += "0";
                epsilonRate += "1";
            }
        }
        int gamma = Convert.ToInt32(gammaRate.ToString(), 2);
        int epsilon = Convert.ToInt32(epsilonRate.ToString(), 2);
        Console.WriteLine(gamma * epsilon);
    }

    public static void RunPart2()
    {
        // Part 2
        string[] input = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../inputs/Day3.txt"));
        string firstValue = CalculateFirstValueRecursively(input, 0)[0];
        string secondValue = CalculateSecondValueRecursively(input, 0)[0];
        int oxygen = Convert.ToInt32(firstValue.ToString(), 2);
        int co2 = Convert.ToInt32(secondValue.ToString(), 2);
        Console.WriteLine("OxygenBin " + firstValue + " X CO2Bin " + secondValue);
        Console.WriteLine("Oxygen " + oxygen + " X CO2 " + co2);
        Console.WriteLine(oxygen * co2);

    }

    public static string[] CalculateFirstValueRecursively(string[] input, int position)
    {
        if (input.Length == 1) return input;

        int[] sum = GetSumPerColumn(input);
        if (sum[position] >= (input.Length / 2.0))
        {
            return CalculateFirstValueRecursively(
                GetNewInputs(input, position, '1'), ++position);
        }
        else
        {
            return CalculateFirstValueRecursively(
                GetNewInputs(input, position, '0'), ++position);
        }
    }

    public static string[] CalculateSecondValueRecursively(string[] input, int position)
    {
        if (input.Length == 1) return input;

        int[] sum = GetSumPerColumn(input);

        if (sum[position] >= (input.Length / 2.0))
        {
            return CalculateSecondValueRecursively(
                GetNewInputs(input, position, '0'), ++position);
        }
        else
        {
            return CalculateSecondValueRecursively(
                GetNewInputs(input, position, '1'), ++position);
        }
    }

    public static bool[] GetMostRepeatedArray(string[] input)
    {
        int[] sum = GetSumPerColumn(input);
        bool[] mostRepeated = new bool[input[0].ToCharArray().Length];
        for (int i = 0; i < sum.Length; i++)
        {
            mostRepeated[i] = (sum[i] >= (input.Length / 2.0));
        }
        return mostRepeated;
    }

    public static int[] GetSumPerColumn(string[] input)
    {
        int[] sum = new int[input[0].ToCharArray().Length];
        foreach (string line in input)
        {
            char[] subs = line.ToCharArray();
            for (int i = 0; i < subs.Length; i++)
            {
                sum[i] += Int32.Parse(subs[i].ToString());
            }
        }
        return sum;
    }

    public static string[] GetNewInputs(string[] input, int position, char valueToFind)
    {
        List<string> newInput = new();
        foreach (string value in input)
        {
            if (value[position] == valueToFind)
            {
                newInput.Add(value);
            }
        }
        return newInput.ToArray();
    }
    }
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // The input data provided in the assignment
        double[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
        
        // Sorting is essential for Median, Quartiles, and Percentiles
        Array.Sort(data);
        int n = data.Length;

        // (i) Mean
        double mean = data.Average();

        // (ii) Mode
        var mode = data.GroupBy(x => x)
                       .OrderByDescending(g => g.Count())
                       .First().Key;

        // (iii) Median (P50 / Second Quartile)
        double median = GetPercentile(data, 50);

        // (iv) Variance
        double variance = data.Select(x => Math.Pow(x - mean, 2)).Sum() / n;

        // (v) P20 (20th Percentile)
        double p20 = GetPercentile(data, 20);

        // (vii, ix) Third Quartile (P75)
        double q3 = GetPercentile(data, 75);

        // (viii) Second Quartile (Same as Median)
        double q2 = median;

        // (x) Range
        double range = data.Max() - data.Min();

        // (xi) Interquartile Range (IQR)
        double q1 = GetPercentile(data, 25);
        double iqr = q3 - q1;

        // (xii) Standard Deviation (Assignment says "Division", likely a typo for Deviation)
        double stdDev = Math.Sqrt(variance);

        // (xiii) Summation of Divisions (Usually refers to sum of absolute deviations or sum of (x - mean))
        double sumOfDeviations = data.Sum(x => x - mean);

        // Output Results
        Console.WriteLine($"Mean: {mean:F2}");
        Console.WriteLine($"Mode: {mode}");
        Console.WriteLine($"Median: {median}");
        Console.WriteLine($"Variance: {variance:F2}");
        Console.WriteLine($"P20: {p20}");
        Console.WriteLine($"Q3 (Third Quartile): {q3}");
        Console.WriteLine($"Range: {range}");
        Console.WriteLine($"Interquartile Range: {iqr}");
        Console.WriteLine($"Standard Deviation: {stdDev:F2}");
        Console.WriteLine($"Sum of Deviations: {sumOfDeviations:F2}");
    }

    // Helper method to calculate Percentiles
    static double GetPercentile(double[] sortedData, double percentile)
    {
        int n = sortedData.Length;
        double index = (percentile / 100.0) * (n - 1);
        int lower = (int)Math.Floor(index);
        int upper = (int)Math.Ceiling(index);
        if (lower == upper) return sortedData[lower];
        return sortedData[lower] + (index - lower) * (sortedData[upper] - sortedData[lower]);
    }
}
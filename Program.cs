
namespace probablitiy 
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Input
                Console.WriteLine("Enter the number of items:");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the values of items:");
                List<double> values = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    double value = double.Parse(Console.ReadLine());
                    values.Add(value);
                }

                // Calculations
                values.Sort();

                double median = CalculateMedian(values);
                Console.WriteLine($"Median: {median}");

                double mode = CalculateMode(values);
                Console.WriteLine($"Mode: {mode}");

                double range = CalculateRange(values);
                Console.WriteLine($"Range: {range}");

                double firstQuartile = CalculateQuartile(values, 0.25);
                Console.WriteLine($"First Quartile: {firstQuartile}");

                double thirdQuartile = CalculateQuartile(values, 0.75);
                Console.WriteLine($"Third Quartile: {thirdQuartile}");

                double p90 = CalculatePercentile(values, 0.9);
                Console.WriteLine($"P90: {p90}");

                double interquartileRange = thirdQuartile - firstQuartile;
                Console.WriteLine($"Interquartile Range: {interquartileRange}");

                double lowerOutlierBoundary = firstQuartile - 1.5 * interquartileRange;
                double upperOutlierBoundary = thirdQuartile + 1.5 * interquartileRange;
                Console.WriteLine($"Outlier Boundaries: ({lowerOutlierBoundary}, {upperOutlierBoundary})");

                Console.WriteLine("Enter a value to check if it is an outlier:");
                double input = double.Parse(Console.ReadLine());
                if (input < lowerOutlierBoundary || input > upperOutlierBoundary)
                {
                    Console.WriteLine($"{input} is an outlier.");
                }
                else
                {
                    Console.WriteLine($"{input} is not an outlier.");
                }
            }

            static double CalculateMedian(List<double> values)
            {
                int middleIndex = values.Count / 2;
                if (values.Count % 2 == 0)
                {
                    return (values[middleIndex - 1] + values[middleIndex]) / 2.0;
                }
                else
                {
                    return values[middleIndex];
                }
            }

            static double CalculateMode(List<double> values)
            {
                Dictionary<double, int> valueCounts = new Dictionary<double, int>();
                foreach (double value in values)
                {
                    if (valueCounts.ContainsKey(value))
                    {
                        valueCounts[value]++;
                    }
                    else
                    {
                        valueCounts[value] = 1;
                    }
                }

                int maxCount = 0;
                double mode = 0;
                foreach (KeyValuePair<double, int> kvp in valueCounts)
                {
                    if (kvp.Value > maxCount)
                    {
                        maxCount = kvp.Value;
                        mode = kvp.Key;
                    }
                }

                return mode;
            }

            static double CalculateRange(List<double> values)
            {
                return values.Last() - values.First();
            }

            static double CalculateQuartile(List<double> values, double percentile)
            {
                int index = (int)Math.Round((values.Count - 1) * percentile);
                int lowerIndex = (int)Math.Floor((values.Count - 1) * percentile);
                double lowerValue = values[lowerIndex];
                double upperValue = values[index];
                double interpolation = (values.Count - 1) * percentile - lowerIndex;
                return lowerValue + interpolation * (upperValue - lowerValue);
            }

            static double CalculatePercentile(List<double> values, double percentile)
            {
                int index = (int)Math.Round((values.Count - 1) * percentile);
                int lowerIndex = (int)Math.Floor((values.Count - 1) * percentile);
                double lowerValue = values[lowerIndex];
                double upperValue = values[index];
                double interpolation = (values.Count - 1) * percentile - lowerIndex;
                return lowerValue + interpolation * (upperValue - lowerValue);
            }
        }
    }



    
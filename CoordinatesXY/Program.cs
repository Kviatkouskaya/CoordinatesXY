using System;
using System.Collections.Generic;

namespace CoordinatesXY
{
    class Program
    {
        public static List<string> coordinatesList;

        public static void ReadingLines()
        {
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                coordinatesList.Add(line);
                line = Console.ReadLine();
            }
        }
        public static string FormatingLine(string line)
        {
            int commaIndex = line.IndexOf(',');
            string coordinateX = line[..commaIndex++];
            string coordinateY = line[commaIndex..];
            line = $"X: {coordinateX} Y: {coordinateY}";
            line = line.Replace('.', ',');
            return line;
        }
        public static void PrintCoordinates()
        {
            foreach (string item in coordinatesList)
            {
                string line = FormatingLine(item);
                Console.WriteLine(line);
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter coordinates:");
            coordinatesList = new List<string>();
            ReadingLines();
            Console.WriteLine("Result:");
            PrintCoordinates();
        }
    }
}

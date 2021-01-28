using System;
using System.Collections.Generic;

namespace CoordinatesXY
{
    public struct CoordinatesXY
    {
        public string X { set; get; }
        public string Y { set; get; }
        public override string ToString()
        {
            string line = $"X: {X} Y: {Y}";
            line = line.Replace('.', ',');
            return line;
        }
        public static CoordinatesXY ParseLine(string line)
        {
            CheckExceptions(line);
            CoordinatesXY coordinates = new CoordinatesXY();
            int commaIndex = line.IndexOf(',');
            coordinates.X = line[..commaIndex++];
            coordinates.Y = line[commaIndex..];
            if (IsDouble(coordinates.X) && IsDouble(coordinates.Y))
            {
                return coordinates;
            }
            return coordinates;
        }
        private static void CheckExceptions(string checkingLine)
        {
            if (checkingLine.IndexOf(',') != checkingLine.LastIndexOf(','))
            {
                throw new FormatException(message: "Entered more than two coordinates at one line");
            }
        }
        private static Boolean IsDouble(string stringNumber)
        {
            try
            {
                double.TryParse(stringNumber, out double x);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
    class Program
    {
        private static IList<string> ReadLineList()
        {
            IList<string> linesList = new List<string>();
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                linesList.Add(line);
                line = Console.ReadLine();
            }
            return linesList;
        }
        private static IList<CoordinatesXY> MapLinesToCoords(IList<string> linesList)
        {
            IList<CoordinatesXY> coordinatesList = new List<CoordinatesXY>();
            foreach (var item in linesList)
            {
                coordinatesList.Add(CoordinatesXY.ParseLine(item));
            }
            return coordinatesList;
        }
        private static void PrintResult(IList<CoordinatesXY> coordinates)
        {
            foreach (var item in coordinates)
            {
                Console.WriteLine(item);
            }
        }
        public static void Main()
        {
            IList<string> linesList = ReadLineList();
            IList<CoordinatesXY> coordinatesList = MapLinesToCoords(linesList);
            PrintResult(coordinatesList);
        }
    }
}

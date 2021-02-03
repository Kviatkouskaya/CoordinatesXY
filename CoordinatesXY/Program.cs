using System;
using System.Collections.Generic;
using System.Globalization;

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
            string[] lineParts = line.Split(',');
            if (lineParts.Length != 2)
            {
                throw new FormatException("Entered more than two coordinates at one line");
            }
            if (!(IsDouble(lineParts[0]) && IsDouble(lineParts[1])))
            {
                throw new FormatException("Expect two double coordinates");
            }

            CoordinatesXY coordinates = new CoordinatesXY
            {
                X = lineParts[0],
                Y = lineParts[1]
            };
            return coordinates;
        }
        private static bool IsDouble(string stringNumber)
        {
            return double.TryParse(stringNumber,
                                     NumberStyles.AllowDecimalPoint,
                                     CultureInfo.InvariantCulture, out _);
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
                try
                {
                    coordinatesList.Add(CoordinatesXY.ParseLine(item));
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
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

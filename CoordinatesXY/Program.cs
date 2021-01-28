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
    }
    class Program
    {
        private static CoordinatesXY ReadingLine(string line)
        {
            CheckExceptions(line);
            CoordinatesXY coordinates = new CoordinatesXY();
            int commaIndex = line.IndexOf(',');
            coordinates.X = line[..commaIndex++];
            coordinates.Y = line[commaIndex..];

            /*
             Boolean isDouble(string stringNumber)
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
            }*/
            return coordinates;
        }
        public static void CheckExceptions(string checkingLine)
        {
            if (checkingLine.IndexOf(',') != checkingLine.LastIndexOf(','))
            {
                throw new FormatException(message: "Please, enter only two coordinates");
            }
        }
        static void Main()
        {
            List<string> linesList = new List<string>();
            FullingLineList(linesList);
            List<CoordinatesXY> coordinatesList = new List<CoordinatesXY>();
            FullingCoordinatesList(coordinatesList, linesList);
            PrintResult(coordinatesList);

            static void FullingLineList(List<string> linesList)
            {
                string line = Console.ReadLine();
                while (line != string.Empty)
                {
                    linesList.Add(line);
                    line = Console.ReadLine();
                }
            }
            static void FullingCoordinatesList(List<CoordinatesXY> coordinateList, List<string> linesList)
            {
                foreach (var item in linesList)
                {
                    coordinateList.Add(ReadingLine(item));
                }
            }

            static void PrintResult(List<CoordinatesXY>coordinates)
            {
                foreach (var item in coordinates)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

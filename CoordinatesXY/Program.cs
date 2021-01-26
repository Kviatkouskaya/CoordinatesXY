using System;

namespace CoordinatesXY
{
    public struct coordinatesXY
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
        private static coordinatesXY ReadingLine(string line)
        {
            coordinatesXY coordinates = new coordinatesXY();
            int commaIndex = line.IndexOf(',');
            coordinates.X = line[..commaIndex++];
            coordinates.Y = line[commaIndex..];
            return coordinates;
        }


        static void Main()
        {
            coordinatesXY xY = ReadingLine(Console.ReadLine());
            PrintResult(xY);

            static void PrintResult(coordinatesXY finalCoordinates)
            {
                Console.WriteLine(finalCoordinates.ToString());
            }
        }
    }
}

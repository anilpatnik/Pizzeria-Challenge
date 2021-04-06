using System;
using System.Collections.Generic;

namespace LOR.Pizzeria
{
    public static class Utility
    {
        public const string NUMERIC_ONLY = "Please enter numeric only...";
        public const string THANK_YOU = "Thank You";

        public static string Box => "Putting pizza into a nice box...";

        public static int IsInputNumeric()
        {
            var input = Console.ReadLine();

            while (!int.TryParse(input, out _))
            {
                Console.WriteLine(NUMERIC_ONLY);

                input = Console.ReadLine();
            }

            return input != null ? int.Parse(input) : 0;
        }

        public static string CommaSeparatedList<T>(IEnumerable<T> items) => string.Join(", ", items);

        public static string Bake(string bakeNotes = "")
        {
            return !string.IsNullOrEmpty(bakeNotes) ? bakeNotes : "Baking pizza for 30 minutes at 200 degrees...";
        }

        public static string Cut(string cutNotes = "")
        {
            return !string.IsNullOrEmpty(cutNotes) ? cutNotes : "Cutting pizza into 8 slices...";
        }
    }
}

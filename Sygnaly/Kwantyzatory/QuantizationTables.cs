using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Kwantyzatory
{
    public static class QuantizationTables
    {
        public static double[] ONE = { 0, 0.5, 1 };
        public static double[] TWO = { 0, 0.25, 0.5, 0.75, 1 };
        public static double[] FOUR = GenerateTable(4);
        public static double[] SIX = GenerateTable(6);
        public static double[] EIGHT = GenerateTable(8);
        public static double[] TWELVE = GenerateTable(12);
        public static double[] SIXTEEN = GenerateTable(16);

        //public QuantizationTables()
        //{
        //    FOUR = GenerateTable(4);
        //    SIX = GenerateTable(6);
        //    EIGHT = GenerateTable(8);
        //    TWELVE = GenerateTable(12);
        //    SIXTEEN = GenerateTable(16);
        //}

    private static double[] GenerateTable(int bits)
    {
        int values = (int)Math.Pow(2, bits);
        double[] result = new double[values + 1];
        for (int i = 1; i <= values; i++)
        {
            result[i] = 1.0 * i / values;
        }
        return result;
    }
}
}

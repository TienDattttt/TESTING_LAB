using System;
using System.Collections.Generic;

namespace RadixApp
{
    public class Radix
    {
        private int number;

        public Radix(int number)
        {
            if (number < 0)
                throw new ArgumentException("Incorrect Value");

            this.number = number;
        }

        public string ConvertDecimalToAnother(int radix = 2)
        {
            if (radix < 2 || radix > 16)
                throw new ArgumentException("Invalid Radix");

            int n = this.number;

            // Trường hợp biên: number = 0
            if (n == 0)
                return "0";

            List<string> result = new List<string>();

            while (n > 0)
            {
                int value = n % radix;
                if (value < 10)
                {
                    result.Add(value.ToString());
                }
                else
                {
                    switch (value)
                    {
                        case 10: result.Add("A"); break;
                        case 11: result.Add("B"); break;
                        case 12: result.Add("C"); break;
                        case 13: result.Add("D"); break;
                        case 14: result.Add("E"); break;
                        case 15: result.Add("F"); break;
                    }
                }
                n /= radix;
            }

            result.Reverse();
            return string.Join("", result);
        }
    }
}

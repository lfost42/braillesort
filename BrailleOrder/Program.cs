﻿using System;
using System.Collections.Generic;

namespace BrailleOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();

            string charOrder = "abcdefghijklmnopqrstuvxyz&=(!)*<%?:$]\\[w1234567890/+#>'-@^_\".;,";

            words.Add("<?");
            words.Add(":w");
            words.Add("?");
            words.Add("<wasde");
            words.Add("<wasdf");

            //test list should sort to: <? <wasde <wasdf ? :w

            words.Sort(delegate (string x, string y)
            {
                int max = (x.Length > y.Length) ? y.Length : x.Length;

                for (int i = 0; i < max; i++)
                {
                    int indexX = charOrder.IndexOf(x[i].ToString(), StringComparison.InvariantCultureIgnoreCase);
                    int indexY = charOrder.IndexOf(y[i].ToString(), StringComparison.InvariantCultureIgnoreCase);
                    if (indexX != indexY) return (indexX - indexY);
                }
                return 0;
            });
            Console.Write(String.Join("\n", words));
        }
    }
}
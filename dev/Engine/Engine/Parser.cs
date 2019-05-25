using System;
using System.Collections.Generic;
using System.IO;

// score:
namespace Parser
{
    public class Parser
    {
        public static string[] Parted(string name)
        {
            try
            {
                string[] results = new string[5];
                int i = 0;
                using (StreamReader sr = new StreamReader(name))
                {
                    string[] linne = new string[1];
                    while (!sr.EndOfStream || i == 4)
                    {
                        string line = sr.ReadLine();
                        linne = line.Split(':');
                        results[i] = linne[0];
                        i++;
                    }
                }
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine("a shit here we go again");
                throw;
            }
        }

        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void Writer(string name, string[] score)
        {
            try
            {

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int.TryParse(score[j], out int f);
                        int.TryParse(score[j + 1], out int h);
                        if (f > h)
                        {
                            Swap<string>(ref score[j], ref score[j + 1];
                        }
                    }
                }

                using (StreamWriter sw = new StreamWriter(name))
                {
                    int x = 0;
                    while (x < 5)
                    {
                        if (score[x] != "0")
                        {
                            sw.WriteLine(score[x]);
                        }
                        else
                        {
                            sw.WriteLine("0");
                        }
                        x++;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("bruh");
                throw;
            }
        }
    }
}
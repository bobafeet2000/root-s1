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

        public void sortlist(string[,] nameoflist, int score)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Int32.TryParse(nameoflist[j,0], out int g);

                    Int32.TryParse(nameoflist[j + 1,0], out int h);
        
                    if (g > h)
                    {
                        Swap<string>(ref nameoflist[j,0], ref nameoflist[j + 1,0]);
                        Swap<string>(ref nameoflist[j, 1], ref nameoflist[j + 1, 1]);
                    }
                }
            }
        }

        public static void Writer(string file_name, string score)
        {
            try
            {

                using (StreamWriter sw = new StreamWriter(file_name))
                {
                    sw.WriteLine(score + ":");
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
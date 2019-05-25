using System;
using System.Collections.Generic;
using System.IO;
using Engine;

// score:
namespace Parser
{
    public class Parser
    {
        public static string Parted(string filename)
        {
            try
            {
                string linne = "";
                using (StreamReader sr = new StreamReader(filename))
                {
                    linne = sr.ReadLine();
                    
                }
                return linne;
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

        public static void sortlist(string[,] nameoflist)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Int32.TryParse(nameoflist[j,0], out int g);

                    Int32.TryParse(nameoflist[j + 1,0], out int h);
        
                    if (g < h)
                    {
                        Swap<string>(ref nameoflist[j+1,0], ref nameoflist[j,0]);
                        Swap<string>(ref nameoflist[j+1, 1], ref nameoflist[j , 1]);
                    }
                }
            }
        }

        public static string[,] Tab_Construct(string file_name, string score, string[,] GAME_SCORE)
        {
            int index = 4;
            for (int i = 0; i < 5; i++)
            {
                if (GAME_SCORE[i, 1] == Constant.STRING_PLAYER)
                {
                    index = i;
                    break;
                }
            }
            Int32.TryParse(GAME_SCORE[index, 0], out int res1);
            Int32.TryParse(score, out int res2);
            if (res1 < res2)
                GAME_SCORE[index, 0] = score;
            try
            {
                using (StreamWriter sw = new StreamWriter(file_name))
                {
                    if (!File.Exists(file_name))
                    {
                        File.Create(file_name);
                    }
                    sw.WriteLine(GAME_SCORE[index, 0]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("bruh");
                throw;
            }
            sortlist(GAME_SCORE);
            return GAME_SCORE;
        }
    }
}
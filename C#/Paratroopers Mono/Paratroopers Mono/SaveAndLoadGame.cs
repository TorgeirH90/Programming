using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using System.IO.IsolatedStorage;

namespace Paratroopers_Mono
{
    class SaveAndLoadGame
    {
        int[] HighScore;
        
        string Fullpath;
        public SaveAndLoadGame()
        {
            HighScore = new int[10];
            DirectoryInfo DI= new DirectoryInfo(Environment.CurrentDirectory);
            Fullpath = DI.FullName + "/Highscore.qq";
        }


        public void SaveGame(int score)
        {
            
            
            int ArrayPosition=HighScore.Length-1;//10-1=9
            int scoreposition = 0;
            if (HighScore[ArrayPosition] < score)
            {
                //Finds the position to the new score
                for (int i = 0; HighScore[i] >= score; i++)
                {
                    //Console.WriteLine(HighScore[i] + ">" + score);

                    scoreposition = i+1;
                }

                //Console.WriteLine("Scoreplace: " + scoreposition);

                for (int i = 9; i >= scoreposition&&i>0; i--)
                {
                    //Console.WriteLine(i + ">" + scoreposition);
                    HighScore[i] = HighScore[i - 1];
                }
                HighScore[scoreposition] = score;
            }
            
            //Writes to file
            using (System.IO.StreamWriter Swriter = new System.IO.StreamWriter(Fullpath))
            {
                for (int i = 0; i != 10; i++)
                {
                    //Console.WriteLine("HS: " + i + " " + HighScore[i].ToString());
                    //Save here?

                    Swriter.WriteLine(HighScore[i].ToString());
                }
            }


            //Console.WriteLine(HighScore);

        }

        public void LoadGame()
        {
            //1. check if file exists

            if (!File.Exists(Fullpath))
            {
                CreateSaveFile();
            }

            string[] lines = System.IO.File.ReadAllLines(Fullpath);

            for (int i = 0; i != 10; i++)
            {
                HighScore[i] = Convert.ToInt32(lines[i]);

            }


            //for (int i = 0; i != 10; i++)
            //{
            //    //Console.WriteLine("HS: " + i + " " + HighScore[i]);
            //}
        }

        private void CreateSaveFile()
        {
            File.Create(Fullpath).Close();
            

            using (System.IO.StreamWriter Swriter = new System.IO.StreamWriter(Fullpath))
            {
                for (int i = 0; i != 10; i++)
                {

                    Swriter.WriteLine(0.ToString());
                }
            }

        }

        //Returns the score in given position
        public string GetScore(int i)
        {
            return HighScore[i].ToString();

            //string[] Tempstring= new string [10];
            //for (int i = 0; i != 10; i++)
            //{
            //    Tempstring[i]=HighScore[i].ToString();
            //}

            //return Tempstring;
        }

    }
}

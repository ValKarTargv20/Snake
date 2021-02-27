using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Snake
{
    public class Score
    {
        Params settings = new Params();
        private static string pathToRecordFile;
        private static string pathToResultsFile;
        private int currentPoints = 0;

        public Score(string _pathToResources)
        {
            pathToRecordFile = _pathToResources + "record.txt";
            pathToResultsFile = _pathToResources + "results.txt";

            WriteText("Счет", 1, 26);

            ShowCurrentPoints();
        }
        public string GetBestResult()
        {
            // Read from file
            StreamReader streamReader = new StreamReader(pathToRecordFile);
            string record = streamReader.ReadToEnd();
            streamReader.Close();
            if (record == "")
            {
                record = "0";
            }

            return record;
        }

        public void WriteBestResult()
        {
            if (currentPoints > Convert.ToInt32(GetBestResult()))
            {
                // Write in file
                StreamWriter streamWriter = new StreamWriter(pathToRecordFile);
                streamWriter.Write(currentPoints);
                streamWriter.Close();

                // Write in file
                StreamWriter streamWriter1 = new StreamWriter(pathToResultsFile, true);
                streamWriter1.WriteLine(currentPoints);
                streamWriter1.Close();
            }
            else
            {
                // Write in file
                StreamWriter streamWriter = new StreamWriter(pathToResultsFile, true);
                streamWriter.WriteLine(currentPoints);
                streamWriter.Close();
            }
        }

        public void UpCurrentPoints()
        {
            currentPoints += 10;
        }
        public void UpPoinS()
        {
            currentPoints += 20;
        }
        public void DownPointB()
        {
            currentPoints -= 5;
        }
        public void ShowCurrentPoints()
        {
            
            if (currentPoints == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(1, 27);
            }
            else if (currentPoints < 50)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1,27);
            }
            else if (currentPoints  < 100)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(1, 27);
            }
            else if (currentPoints < 150)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(1, 27);
            }
            else if (currentPoints > 150)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, 27);
            }

            Console.WriteLine(currentPoints.ToString());
        }
        public int CurrentPoints()
        {
            return currentPoints;
        }

        public void ShowLastFiveResults()
        {
            List<int> res = new List<int>();
            string line;

            // Read file
            StreamReader streamReader = new StreamReader(pathToResultsFile);
            while ((line = streamReader.ReadLine()) != null)
            {
                // Добавить в список все значения
                res.Add(Convert.ToInt32(line));
            }

            streamReader.Close();


            // Вывод последних 5 результатов
            for (int i = res.Count - 1, j = 1; i > res.Count - 6; i--, j++)
            {
                Console.SetCursorPosition(80, 7 + j);
                Console.WriteLine(j + ") " + res[i]);
            }
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}

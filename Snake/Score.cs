using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Snake
{
    public class Score
    {
        private  Params settings = new Params();
        private static string pathToRecordFile;
        private static string pathToResultsFile;
        private int currentPoints = 0;

        public Score(string _pathToResources)
        {
            pathToRecordFile = _pathToResources + "record.txt";
            pathToResultsFile = _pathToResources + "results.txt";
            Console.ForegroundColor = ConsoleColor.DarkGray;

            WriteText("Счет", 1, 26);

            ShowCurrentPoints();

            WriteText("Результаты игр:", 1, 29);

            WriteText(GetBestResult(), 1, 30);

            WriteText("-----------------------------", 1, 28);

            ShowLastFiveResults();
        }
        public string GetBestResult()
        {
            // Read from file
            StreamReader streamReader = new StreamReader("results.txt", true);
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
            StreamWriter streamWriter = new StreamWriter("results.txt", true);
            Console.WriteLine("Введите ваше имя");
            string Name = Console.ReadLine();
            streamWriter.WriteLine(Name+" "+"-"+" "+currentPoints);

            streamWriter.Close();

            /*if (currentPoints > Convert.ToInt32(GetBestResult()))
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
            }*/
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
        public int ShowPoint()
        {
            return currentPoints;
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
            /*for (int i = res.Count - 1, j = 1; i > res.Count - 6; i--, j++)
            {
                Console.SetCursorPosition(80, 7 + j);
                Console.WriteLine(j + ") " + res[i]);
            }*/
        }

        public void WriteGameOver()
        {
            //Sounds.Stop();
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("~~~~~~~~~~~~~~~~~~~~~~", xOffset, yOffset++);
            WriteText("К О Н Е Ц    И Г Р Ы", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор: Валерия Карпова", xOffset, yOffset++);
            WriteText("Домашняя работа", xOffset + 3, yOffset++);
            WriteText("~~~~~~~~~~~~~~~~~~~~~~", xOffset, yOffset++);
            WriteBestResult();
            //WriteText("Новая Игра - Enter", xOffset +2, yOffset++);
            //WriteText("Выйти - Esc", xOffset + 4, yOffset++);
            //ConsoleKeyInfo nupp = new ConsoleKeyInfo();
            //do
            //{
            //    nupp = Console.ReadKey();
            //} while (nupp.Key != ConsoleKey.Enter);

        }


        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}

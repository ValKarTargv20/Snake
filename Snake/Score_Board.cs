using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Snake
{
    class Score_Board
    {
        public Score_Board(int score, string pathToResorces)
        {
            Console.Clear();
            Console.WriteLine("Введите ваше имя:");
            string name = Console.ReadLine();
            StreamWriter file = new StreamWriter(pathToResorces+"result.txt", true);
            file.WriteLine(name + " - " + score + " ");
            file.Close();
        }
    }
}

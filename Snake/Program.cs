using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WMPLib;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(85, 30);

            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$', '@', '#');
            Point food = foodCreator.CreateFood();
            Point Sfood = foodCreator.CreateFoodS();
            Point Bfood = foodCreator.CreateFoodB();
            food.Draw();

            Params settings = new Params();
            Sounds sound = new Sounds(settings.GetResourceFolder());
            sound.Play();
            Score count = new CurrentPoints(0);
            count.ShowCurrentPoints();
            Sounds sound1 = new Sounds(settings.GetResourceFolder());
            Sounds soundS = new Sounds(settings.GetResourceFolder());
            Score score = new Score(settings.GetResourceFolder());

            while (true)
            {
                if (walls.IsHit(snake)|| snake.IsHitTail()) // этот знак || означает "или"
                { //Тема из звездных войн
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(250, 500);
                    Thread.Sleep(50);
                    Console.Beep(350, 250);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    Console.Beep(250, 500);
                    Thread.Sleep(50);
                    Console.Beep(350, 250);
                    Console.Beep(300, 500);
                    Thread.Sleep(50);
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    count.UpCurrentPoints();
                    count.WriteBestResult();
                    sound1.PlayEat();
                    score.UpCurrentPoints();
                    score.ShowCurrentPoints();
                    if (count.CurrentPoints() % 10 == 0)
                    {
                        Sfood = foodCreator.CreateFoodS();
                        Sfood.Draw();
                        Bfood = foodCreator.CreateFoodB();
                        Bfood.Draw();
                    }
                }
                if (snake.Eat(Sfood))
                {
                    count.UpPoinS();
                    count.CurrentPoints();
                    soundS.PlayEatS();
                }
                if (snake.Eat(Bfood))
                {
                    count.DownPointB();
                    count.CurrentPoints();
                    soundS.PlayEatB();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                
            }
            WriteGameOver();
            Console.ReadLine();

        }
        static void WriteGameOver()
        {
            //Sounds.Stop();
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("~~~~~~~~~~~~~~~~~~~~~~", xOffset, yOffset++);
            WriteText("К О Н Е Ц    И Г Р Ы", xOffset+1, yOffset++);
            yOffset++;
            WriteText("Автор: Валерия Карпова", xOffset, yOffset++);
            WriteText("Домашняя работа", xOffset+3, yOffset++);
            WriteText("~~~~~~~~~~~~~~~~~~~~~~", xOffset, yOffset++);
            //WriteText("Новая Игра - Enter", xOffset +2, yOffset++);
            //WriteText("Выйти - Esc", xOffset + 4, yOffset++);
            //ConsoleKeyInfo nupp = new ConsoleKeyInfo();
            //do
            //{
            //    nupp = Console.ReadKey();
            //} while (nupp.Key != ConsoleKey.Enter);
            Params settings = new Params();
        }


        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WMPLib;
using System.IO;


namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(85, 35);

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
            Sounds sound1 = new Sounds(settings.GetResourceFolder());
            Sounds soundS = new Sounds(settings.GetResourceFolder());
            Sounds soundB = new Sounds(settings.GetResourceFolder());
            Score score = new Score(settings.GetResourceFolder());

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail()) // этот знак || означает "или"
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
                    sound1.PlayEat();
                    score.UpCurrentPoints();
                    score.ShowCurrentPoints();
                    if (score.ShowPoint()%50 == 0)
                    {
                        Sfood = foodCreator.CreateFoodS();
                        Sfood.Draw();
                        Bfood = foodCreator.CreateFoodB();
                        Bfood.Draw();
                    }
                }
                if (snake.Eat(Sfood))
                {
                    score.UpPoinS();
                    score.ShowCurrentPoints();
                    soundS.PlayEatS();

                }
                if (snake.Eat(Bfood))
                {
                    score.DownPointB();
                    score.ShowCurrentPoints();
                    soundB.PlayEatB();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(200);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandeKey(key.Key);
                }


            }
            score.WriteGameOver();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace Snake
{
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;
        char Ssym;
        char Bsym;

        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym, char Ssym, char Bsym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
            this.Ssym = Ssym;
            this.Bsym = Bsym;
        }
        public Point CreateFood()
        { 
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
        public Point CreateFoodS()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, Ssym);
        }
        public Point CreateFoodB()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, Bsym);
        }
    }
}

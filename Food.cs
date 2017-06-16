using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace My_snake
{
    class Food
    {
        public Rectangle  foodSnake;
        private SolidBrush brush;
        private int x, y, width, height;
        public Food()
        {
            Random randomFood=new Random();
            brush = new SolidBrush(Color.Black);
            x = randomFood.Next(30, 250);
            y = randomFood.Next(30, 250);
            width = 10;
            height = 10;
            foodSnake = new Rectangle(x, y, width, height);
        }
        public void foodLocation(Random randomFood)
        {
            x = randomFood.Next(30, 250);
            y = randomFood.Next(30, 250);
        }

        public void drawFood(Graphics e)
        {
            foodSnake.X = x;
            foodSnake.Y = y;
            e.FillEllipse(brush, foodSnake);
        }


    }
}

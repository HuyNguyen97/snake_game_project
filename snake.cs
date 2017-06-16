using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace My_snake
{
    class snake
    {
        public Rectangle [] snakeRec;
        private SolidBrush brush;
        private int x, y, width, height;
        public snake()
        {
            snakeRec = new Rectangle[2];
            brush = new SolidBrush(Color.Red);
            x = 20;
            y = 0;
            width = 10;
            height = 10;
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }

        public void drawSnake(Graphics e)
        {
            foreach(Rectangle rec in snakeRec)
            {
                e.FillEllipse(brush, rec);
            }
        }

        public void drawSnakeRun()
        {
            for(int i=snakeRec.Length-1;i>0;i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }

        public void moveUp()
        {
            drawSnakeRun();
            snakeRec[0].Y -= 10;
        }
        
        public void moveDown()
        {
            drawSnakeRun();
            snakeRec[0].Y += 10;
        }

        public void moveRight()
        {
            drawSnakeRun();
            snakeRec[0].X += 10;
        }

        public void moveLeft()
        {
            drawSnakeRun();
            snakeRec[0].X -= 10;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_snake
{
    public partial class Form1 : Form
    {
        Random randomFood = new Random();
        Food food;
        Graphics paper;
        snake snake = new snake();

        bool up = false;
        bool down = false;
        bool right = false;
        bool left = false;
        public Form1()
        {
            InitializeComponent();
            food = new Food();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snake.drawSnake(paper);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Up && down == false)
            {
                up = true;
                down = false;
                right = false;
                left = false;
            }
            
            if (e.KeyData == Keys.Down && up == false)
            {
                up = false;
                down = true;
                right = false;
                left = false;
            }

            if (e.KeyData == Keys.Right && left == false)
            {
                up = false;
                down = false;
                right = true;
                left = false;
            }

            if (e.KeyData == Keys.Left && right == false)
            {
                up = false;
                down = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down == true) { snake.moveDown(); }
            if (up == true) { snake.moveUp(); }
            if (right == true) { snake.moveRight(); }
            if (left == true) { snake.moveLeft(); }
            if (snake.snakeRec[0].IntersectsWith(food.foodSnake))
            {
                snake.growSnake();
                food.foodLocation(randomFood);
                colisionWall();
            }
            this.Invalidate();
        }

        public void colisionWall()
        {
            for(int i=0;i<snake.snakeRec.Length;i++)
            {
                if(snake.snakeRec[0].IntersectsWith(snake.snakeRec[i]))
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Ban da tu an than minh");
                }
            }
            if(snake.snakeRec[0].Y<0 || snake.snakeRec[0].Y>290)
            {
                timer1.Enabled = false;
                MessageBox.Show("Ban da tu dam vao tuong");
            }
            if (snake.snakeRec[0].X < 0 || snake.snakeRec[0].X > 290)
            {
                timer1.Enabled = false;
                MessageBox.Show("Ban da tu dam vao tuong");
            }
        }
    }
}

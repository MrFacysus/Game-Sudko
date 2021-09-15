using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int inputRows = 8;
        int inputHeight = 8;
        object[] buttons = new object[] { };

        private object CreateButton(int row, int height, string text)
        {

            Button button = new Button();
            button.Text = text;
            button.Location = new Point(75 * row, 75 * height);
            button.Size = new Size(75, 75);
            this.Controls.Add(button);

            if (row == 0 || height == 0)
            {

                if (row == 0 && height == 0)
                {

                    button.BackColor = Color.Green;
                    button.Click += new System.EventHandler(this.EndIsClicked);

                }
                else
                {

                    button.BackColor = Color.LightGray;

                }

            }
            else
            {

                button.Click += new System.EventHandler(this.buttonIsClicked);

            }

            return button;
        }

        private void buttonIsClicked(object sender, EventArgs e)
        {

            Button sent = (Button)sender;

            if (sent.BackColor != Color.Black)
            {

                sent.BackColor = Color.Black;

            }
            else
            {

                sent.BackColor = Color.White;

            }

        }

        private List<int> CreateGame(int row, int height)
        {

            Random random = new Random();
            List<int> Game = new List<int> { };
            List<int> Up = new List<int> { };
            List<int> Left = new List<int> { };

            for (int i = 0; i < row - 1; i++)
            {

                Up.Add(0);

                for (int j = 0; j < height - 1; j++)
                { 

                    if (i == 0)
                    {

                        Left.Add(0);

                    }

                    if (random.Next(2) == 1)
                    {

                        Left[j] += 1;
                        Up[Up.Count - 1] += 1;

                    }

                }

            }

            foreach (int num in Up)
            {

                Game.Add(num);

            }

            foreach (int num in Left)
            {

                Game.Add(num);

            }

            return Game;

        }

        private void EndIsClicked(object sender, EventArgs e)
        {

            this.Controls.Clear();
            this.CreateBoard(inputRows, inputHeight);
            this.IsMdiContainer = true;

        }

        private void CreateBoard(int rows, int height)
        {
            string text = "";

            List<int> GameSpecs = CreateGame(rows, height);

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < height; j++)
                {

                    if ((i == 0 || j == 0) && !(i == 0 && j == 0))
                    {

                        if (i == 0)
                        {

                            text = GameSpecs[j + rows - 2].ToString();

                        }
                        else
                        {

                            text = GameSpecs[i - 1].ToString();

                        }

                    }
                    else
                    {

                        text = "";

                    }

                    buttons.Append(CreateButton(i, j, text));

                }

            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {

            CreateBoard(inputRows, inputHeight);

        }
    }
}

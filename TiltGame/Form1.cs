using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;


namespace WindowsFormsApp1
{
    
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        //char[][] board = new char[][]
        //{
        //    new char[] {'.', '#', '.', '.', '.'},
        //    new char[] {'.', '#', '.', '.', '.'},
        //    new char[] {'.', '.', 'o', 'o', '.'},
        //    new char[] {'.', '.', '.', '.', '.'},
        //    new char[] {'.', '.', '#', '.', '.'}
        //};

        //List<char[][]> boards = new List<char[][]>
        //{
        //    new char[][]
        //    {
        //        new char[] {'.', '#', '.', '.', '.'},
        //        new char[] {'.', '#', '.', '.', '.'},
        //        new char[] {'.', '.', 'o', 'o', '.'},
        //        new char[] {'.', '.', '.', '.', '.'},
        //        new char[] {'.', '.', '#', '.', '.'}
        //    },
        //    new char[][]
        //    {
        //        new char[] {'.', '.', 'o', 'o', '.'},
        //        new char[] {'.', '#', '.', '.', '.'},
        //        new char[] {'.', '#', '.', '.', '.'},
        //        new char[] {'.', '.', '#', '.', '.'},
        //        new char[] {'.', '.', '.', '.', '.'}
        //    },
        //     new char[][]
        //    {
        //         new char[] {'.', '#', '.', '.', '.'},
        //        new char[] {'.', '.', '#', '.', '.'},
        //        new char[] {'.', '#', '.', '.', '.'},
        //        new char[] {'.', '.', '.', '.', '.'},
        //        new char[] {'.', '.', 'o', 'o', '.'},

        //    }

        //};
        Tuple<int, int> target = Tuple.Create(3,3);

        int n = 5;  // Size of the grid (n x n)
        int currentBoardIndex = 0; // Index to keep track of the current board

        // int n = 5;  // Size of the grid (n x n)
       
        private void Form1_Load(object sender, EventArgs e)
        {

            // Initialize the form with the initial board
            CreateButtons();
            UpdateButtonText(board);
            previous.Enabled = false;
        }

        private void CreateButtons()
        {
            int buttonSize = 60;  // Size of each button
            int spacing = 0;      // Spacing between buttons

            // Calculate the total size of the grid
            int gridWidth = n * buttonSize + (n - 1) * spacing;
            int gridHeight = n * buttonSize + (n - 1) * spacing;

            // Calculate the starting point to center the grid
            int startX = (ClientSize.Width - gridWidth) / 2;
            int startY = (ClientSize.Height - gridHeight) / 2;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Button b = new Button();
                    b.Size = new Size(buttonSize, buttonSize);
                    b.Location = new Point(startX + col * (buttonSize + spacing), startY + row * (buttonSize + spacing));
                    b.Tag = "DynamicButton";
                    b.Enabled = false;
                    b.FlatStyle = FlatStyle.Flat;
                    b.Name = "Button" + (row * n + col + 1).ToString();
                   
                    Controls.Add(b);
                }
            }
        }

        /* private void UpdateButtonText(char[][] newBoard)
         {
             for (int row = 0; row < n; row++)
             {
                 for (int col = 0; col < n; col++)
                 {
                     string buttonName = "Button" + ((row * n) + col + 1).ToString();
                     Button btn = Controls.Find(buttonName, true).FirstOrDefault() as Button;

                     if (btn != null)
                     {
                         char cellValue = newBoard[row][col];
                         btn.Text = cellValue.ToString();
                     }
                 }
             }
         }*/
        private void UpdateButtonText(char[][] newBoard)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    string buttonName = "Button" + ((row * n) + col + 1).ToString();
                    Button btn = Controls.Find(buttonName, true).FirstOrDefault() as Button;

                    if (btn != null)
                    {
                        char cellValue = newBoard[row][col];
                        btn.Text = cellValue.ToString();

                        // Set button color based on cell value
                        if (cellValue != 'o')
                        {
                            btn.BackgroundImage = null;
                        }
                        if (cellValue == '.')
                        {
                            // btn.BackColor = Color.Black;
                            // btn.Text ="";
                           // btn.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Downloads\7c4077d2c3.jpg");
                           // btn.BackgroundImageLayout = ImageLayout.Stretch; // Stretch image to fit the button size

                        }
                        else if (cellValue == '#')
                        {
                            /* btn.BackColor = Color.Black;
                             btn.Text = "";*/
                           // btn.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Downloads\7b9a5847f6.jpg");

                         //  btn.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Downloads\0ffd6d2c80.jpg");
                           //  btn.BackgroundImageLayout = ImageLayout.Stretch; // Stretch image to fit the button size
                        }
                        else if (cellValue == 'o')
                        {
                            // Load and set image for 'o'
                            //btn.Text = "";
                           // btn.BackColor = Color.White; // Set button color to red

                            //btn.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Downloads\neon.jpg");
                            //btn.BackgroundImageLayout = ImageLayout.Stretch; // Stretch image to fit the button size
                        }
                        if (row == target.Item1 && col == target.Item2)
                        {
                             btn.BackColor = Color.Aqua; // Set button color to red
                           // btn.Text = "";
                           // btn.BackgroundImage = Image.FromFile(@"C:\Users\Dell\Downloads\pngwing.com (43).png");
                           // btn.BackgroundImageLayout = ImageLayout.Stretch; // Stretch image to fit the button size
                        }

                    }
                }
            }
        }


        private void Next_Click(object sender, EventArgs e)
        {
            currentBoardIndex++;
            if (currentBoardIndex == boards.Count - 1)
            {
                Next.Enabled = false;
            }

            UpdateButtonText(boards[currentBoardIndex]);
            previous.Enabled = true;


            /*
            if (currentBoardIndex < boards.Count)
            {
                UpdateButtonText(boards[currentBoardIndex]);
                previous.Enabled = true;

            }
            else
            {

                Next.Enabled = false; // Disable the button if there are no more boards
            }*/
        }

        private void previos_Click(object sender, EventArgs e)
        {
            currentBoardIndex--;
            if (currentBoardIndex ==0)
            {
                previous.Enabled = false;
            }
            UpdateButtonText(boards[currentBoardIndex]);
            Next.Enabled = true;


            /*  if (currentBoardIndex >= 0)
              {
                  UpdateButtonText(boards[currentBoardIndex]);
                  Next.Enabled = true; // Re-enable the Next button
              }
              else
              {
                  // If we're at the first board, disable the Previous button
                  previous.Enabled = false;
              }*/
        }
    }
}

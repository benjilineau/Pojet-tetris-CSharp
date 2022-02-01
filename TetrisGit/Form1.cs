using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        String Status ="play";
        Shape currentShape;
        Shape nextShape;
        Timer timer = new Timer();
        System.Timers.Timer t;
        int h, m, s;

        Dictionary<string, string> command;
        int bestScore;
        int level;
        public Form1(int BestScore, Dictionary<string, string> C)
        {
            InitializeComponent();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(AssetsPath + @"tetris.wav");
            player.PlayLooping();
            loadCanvas();

            command = C;
            bestScore = BestScore;

            currentShape = getRandomShapeWithCenterAligned();
            nextShape = getNextShape();

            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            timer.Start();
            this.KeyDown += Form1_KeyDown;
            label6.Text = "Best score: " + bestScore.ToString();


        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            t.Start();

        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                label4.Text = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                // increase the speed 
                if (s == 0 || s == 30)
                {
                    level += 1;
                    if (timer.Interval - 50 <= 100)
                    {
                        timer.Interval = 100;
                    }
                    else
                    {
                        timer.Interval -= 50;
                    }
                }
            }));
        }
        private string AssetsPath = findAssetsPath();
        private static string findAssetsPath()
        {
            string[] folders = Path.GetDirectoryName(Application.ExecutablePath).Split('\\');
            return String.Join(@"\", folders.Take(folders.Length - 3)) + @"\assets\";
        }
        Bitmap canvasBitmap;
        Graphics canvasGraphics;
        int canvasWidth = 10;
        int canvasHeight = 22;
        int[,] canvasDotArray;
        int dotSize = 22;

        private void loadCanvas()
        {

            // Resize the picture box based on the dotsize and canvas size
            pictureBox1.Width = canvasWidth * dotSize;
            pictureBox1.Height = canvasHeight * dotSize;

            // Create Bitmap with picture box's size
            canvasBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            canvasGraphics = Graphics.FromImage(canvasBitmap);

            canvasGraphics.FillRectangle(Brushes.LightGray, 0, 0, canvasBitmap.Width, canvasBitmap.Height);

            // Load bitmap into picture box
            pictureBox1.Image = canvasBitmap;

            // Initialize canvas dot array. by default all elements are zero
            canvasDotArray = new int[canvasWidth, canvasHeight];
        }


        int currentX;
        int currentY;
        private Shape getRandomShapeWithCenterAligned()
        {
            var shape = ShapesHandler.GetRandomShape();

            // Calculate the x and y values as if the shape lies in the center
            currentX = 5;
            currentY = -2;

            return shape;
        }

        Bitmap workingBitmap;
        Graphics workingGraphics;
        private void Timer_Tick(object sender, EventArgs e)
        {
            var isMoveSuccess = moveShapeIfPossible(moveDown: 1);

            // if shape reached bottom or touched any other shapes
            if (!isMoveSuccess)
            {
                // copy working image into canvas image
                canvasBitmap = new Bitmap(workingBitmap);

                updateCanvasDotArrayWithCurrentShape();

                //// get next shape
                currentShape = nextShape;
                nextShape = getNextShape();

                clearFilledRowsAndUpdateScore();
            }
        }

        private void updateCanvasDotArrayWithCurrentShape()
        {
            bool outOfRange = false;
            if (currentShape.Height + currentY >= Height -1)
            {
                checkIfGameOver();

            }
            else
            {
                for (int i = 0; i < currentShape.Width; i++)
                {
                    for (int j = 0; j < currentShape.Height; j++)
                    {
                        if (currentShape.Dots[j, i] != 0)
                        {
                            if (currentY + j<=0 )
                            {
                                outOfRange = true;
                                checkIfGameOver();
                                break;
                            }
                            else
                            { 
                                canvasDotArray[currentX + i, currentY + j] = currentShape.Dots[j, i];
                            }
                        }
                    }
                    if (outOfRange)
                    {
                        break;
                    }
                }
            }
            
        }

        private void checkIfGameOver()
        {
            if (currentY <= 0 )
            {
                t.Stop();
                timer.Stop(); 
                checkBestScore(score);
                gameOver obj1 = new gameOver(score, bestScore, command);
                checkBestScore(score);
                obj1.Show();
                this.Close();
            }
        }

        private void checkBestScore(int score)
        {
            if (score > bestScore)
            {
                bestScore = score;
            }
        }

        // returns if it reaches the bottom or touches any other blocks
        private bool moveShapeIfPossible(int moveSide = 0, int moveDown = 0)
        {
            if (Status == "pause")
            {
                moveSide = 0;
                moveDown = 0;
            }
            var newX = currentX + moveSide;
            var newY = currentY + moveDown;
            
            // check if it reaches the bottom or side bar
            if (newX < 0 || newX + currentShape.Width > canvasWidth
                || newY + currentShape.Height > canvasHeight)
                return false;

            // check if it touches any other blocks 
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (newY + j > 0 && canvasDotArray[newX + i, newY + j] != 0 && currentShape.Dots[j, i] != 0)
                        return false;
                }
            }

            currentX = newX;
            currentY = newY;

            drawShape();

            return true;
        }
        private void drawShape()
        {
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);
            Brush C = currentShape.Color;
            if (Status == "pause")
            {
                C = Brushes.LightGray;
            }
            for (int i = 0; i < currentShape.Width; i++)
            {
                for (int j = 0; j < currentShape.Height; j++)
                {
                    if (currentShape.Dots[j, i] != 0)
                        workingGraphics.FillRectangle(C, (currentX + i) * dotSize, (currentY + j) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox1.Image = workingBitmap;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var verticalMove = 0;
            var horizontalMove = 0;

            // calculate the vertical and horizontal move values
            // based on the key pressed
            if (Status == "pause")
            {
                if (e.KeyCode == Keys.Escape)
                {
                    haveABreak();
                }
            }
            else
            {
                if (e.KeyCode.ToString() == command["Left"])
                {

                    horizontalMove--;
                }
                if (e.KeyCode.ToString() == command["Right"])
                {

                    horizontalMove++;
                }
                if (e.KeyCode.ToString() == command["Down"])
                {

                    verticalMove++;
                }
                if (e.KeyCode.ToString() == command["TLeft"])
                {

                    currentShape.turn("l", currentX);
                }
                if (e.KeyCode.ToString() == command["TRight"])
                {

                    currentShape.turn("r", currentX);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    haveABreak();
                }
            }
            

            var isMoveSuccess = moveShapeIfPossible(horizontalMove, verticalMove);

            // if the player was trying to rotate the shape, but
            // that move was not possible - rollback the shape
            if (!isMoveSuccess && (e.KeyCode == Keys.A || e.KeyCode == Keys.E))
                currentShape.rollback();
        }

        int score;
        public void clearFilledRowsAndUpdateScore()
        {
            // check through each rows
            int combo = 0;

            for (int i = 0; i < canvasHeight; i++)
            {
                int j;
                for (j = canvasWidth - 1; j >= 0; j--)
                {
                    if (canvasDotArray[j, i] == 0)
                        break;
                }

                if (j == -1)
                {
                    combo++;
                    // update the dot array based on the check
                    for (j = 0; j < canvasWidth; j++)
                    {
                        for (int k = i; k > 0; k--)
                        {
                            canvasDotArray[j, k] = canvasDotArray[j, k - 1];
                        }

                        canvasDotArray[j, 0] = 0;
                    }
                }
            }
            if (combo == 1)
            {
                score += 40;
            }
            else if (combo == 2)
            {
                score += 100;
            }
            else if (combo == 3)
            {
                score += 300;
            }
            else if (combo == 4)
            {
                score += 1000;
            }
            // update score and level values and labels
            label1.Text = "Score: " + score;
            label2.Text = "Level: " + level;
            

            // Draw panel based on the updated array values
            for (int i = 0; i < canvasWidth; i++)
            {
                for (int j = 0; j < canvasHeight; j++)
                {
                    canvasGraphics = Graphics.FromImage(canvasBitmap);
                    var C = Brushes.LightGray;

                    if (canvasDotArray[i, j] == 1)
                    {
                        C = Brushes.Yellow;
                    }
                    else if (canvasDotArray[i, j] == 2)
                    {
                        C = Brushes.Cyan;
                    }
                    else if (canvasDotArray[i, j] == 3)
                    {
                        C = Brushes.Purple;
                    }
                    else if (canvasDotArray[i, j] == 4)
                    {
                        C = Brushes.Orange;
                    }
                    else if (canvasDotArray[i, j] == 5)
                    {
                        C = Brushes.Blue;
                    }
                    else if (canvasDotArray[i, j] == 6)
                    {
                        C = Brushes.Red;
                    }
                    else if (canvasDotArray[i, j] == 7)
                    {
                        C = Brushes.Green;
                    }
                    else
                    {
                        C = Brushes.Black;
                    }

                    canvasGraphics.FillRectangle(
                        canvasDotArray[i, j] != 0 ? C : Brushes.LightGray,
                        i * dotSize, j * dotSize, dotSize, dotSize
                        );

                    
                }
            }

            pictureBox1.Image = canvasBitmap;
        }

        Bitmap nextShapeBitmap;
        Graphics nextShapeGraphics;
        private Shape getNextShape()
        {
            var shape = getRandomShapeWithCenterAligned();

            // Codes to show the next shape in the side panel
            nextShapeBitmap = new Bitmap(6 * dotSize, 6 * dotSize);
            nextShapeGraphics = Graphics.FromImage(nextShapeBitmap);

            nextShapeGraphics.FillRectangle(Brushes.White, 0, 0, nextShapeBitmap.Width, nextShapeBitmap.Height);

            // Find the ideal position for the shape in the side panel
            var startX = (6 - shape.Width) / 2;
            var startY = (6 - shape.Height) / 2;

            for (int i = 0; i < shape.Height; i++)
            {
                for (int j = 0; j < shape.Width; j++)
                {

                    nextShapeGraphics.FillRectangle(
                        shape.Dots[i, j] != 0 ? shape.Color : Brushes.White,
                        (startX + j) * dotSize, (startY + i) * dotSize, dotSize, dotSize);
                }
            }

            pictureBox2.Size = nextShapeBitmap.Size;
            pictureBox2.Image = nextShapeBitmap;

            return shape;
        }

        private void haveABreak()
        {
            if (Status == "play")
            {
                Status = "pause";
                t.Stop();

                for (int i = 0; i < canvasWidth; i++)
                {
                    for (int j = 0; j < canvasHeight; j++)
                    {
                        canvasGraphics = Graphics.FromImage(canvasBitmap);

                        canvasGraphics.FillRectangle(Brushes.LightGray,
                            i * dotSize, j * dotSize, dotSize, dotSize
                            );
                    }
                }
                Pause obj1 = new Pause(command);
                obj1.Show();
            }
            else
            {
                t.Start();
                Status = "play";
                for (int i = 0; i < canvasWidth; i++)
                {
                    for (int j = 0; j < canvasHeight; j++)
                    {
                        canvasGraphics = Graphics.FromImage(canvasBitmap);
                        var C = Brushes.LightGray;

                        if (canvasDotArray[i, j] == 1)
                        {
                            C = Brushes.Yellow;
                        }
                        else if (canvasDotArray[i, j] == 2)
                        {
                            C = Brushes.Cyan;
                        }
                        else if (canvasDotArray[i, j] == 3)
                        {
                            C = Brushes.Purple;
                        }
                        else if (canvasDotArray[i, j] == 4)
                        {
                            C = Brushes.Orange;
                        }
                        else if (canvasDotArray[i, j] == 5)
                        {
                            C = Brushes.Blue;
                        }
                        else if (canvasDotArray[i, j] == 6)
                        {
                            C = Brushes.Red;
                        }
                        else if (canvasDotArray[i, j] == 7)
                        {
                            C = Brushes.Green;
                        }
                        else
                        {
                            C = Brushes.Black;
                        }

                        canvasGraphics.FillRectangle(
                            canvasDotArray[i, j] != 0 ? C : Brushes.LightGray,
                            i * dotSize, j * dotSize, dotSize, dotSize
                            );


                    }
                }
            }


        }
        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

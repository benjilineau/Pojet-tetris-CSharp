using System.Drawing;

namespace Tetris
{
    class Shape
    {
        public int Width;
        public int Height;
        public int[,] Dots;
        public Brush Color;

        private int[,] backupDots;
        public void turn()
        {
            // back the dots values into backup dots
            // so that it can be simply used for rolling back
            backupDots = Dots;

            Dots = new int[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[Height - 1 - j, i];
                }
            }

            var temp = Width;
            Width = Height;
            Height = temp;
        }

        // the rolling back occures when player rotating the shape
        // but it will touch other shapes and needs to be rolled back
        public void rollback()
        {
            Dots = backupDots;

            var temp = Width;
            Width = Height;
            Height = temp;
        }
    }
}

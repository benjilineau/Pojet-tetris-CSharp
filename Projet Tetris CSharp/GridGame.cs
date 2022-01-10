namespace Projet_Tetris_CSharp
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get;  }
        public int Colums { get; }

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r,  c] = value;
        }
        public GameGrid(int rows, int col)
        {
            Rows = rows;
            Colums = col;
            grid = new int[rows, col];
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c <Colums;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r,c) && grid[r,c] == 0;
        }

        public bool RowIsFull(int r)
        {
            for (int c = 0; c<Colums; c++)
            {
                if(grid[r,c] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void ClearRow(int r)
        {
            if (RowIsFull(r))
            {
                for (int c = 0; c < Colums; c++)
                {
                    grid[r,  c]  =  0;
                }
            }
        }

        public void MoveRowDown(int r, int nextR)
        {
            for (int c = 0; c < Colums; c++)
            {
                grid[nextR, c] = grid[r, c];
                grid[r,  c] = 0;
            }
        }

    }
}
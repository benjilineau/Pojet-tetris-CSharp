namespace Projet_Tetris_CSharp
{

    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int ID { get; }

        private int rotateState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }



        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotateState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        public void RotateRight()
        {
            if (rotateState == Tiles.Length - 1)
            {
                rotateState = 0;
            }
            else
            {
                rotateState++;
            }
        }

        public void RotateLeft()
        {
            if (rotateState == 0)
            {
                rotateState = Tiles.Length - 1;
            }
            else
            {
                rotateState--;
            }
        }

        public void Reset()
        {
            rotateState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
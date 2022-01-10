using System;

namespace Projet_Tetris_CSharp
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new ZBlock(),
            new ZBlock(),
        };

        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }
    }
}
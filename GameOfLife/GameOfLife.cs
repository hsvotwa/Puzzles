using System;

namespace GameOfLife
{
    public class GameOfLife
    {
        private int Heigth;
        private int Width;
        private bool[,] Cells;

        public GameOfLife(int heigth, int width)
        {
            Heigth = heigth;
            Width = width;
            Cells = new bool[ heigth, width ];
            GenerateCellContent();
        }

        public void DrawAndGrow()
        {
            DrawBoard();
            Iterate();
        }

        private void Iterate()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int aliveNeighborCount = GetNeighbors(i, j);
                    if (Cells[ i, j ])
                    {
                        if (aliveNeighborCount < 2)
                        {
                            Cells[ i, j ] = false;
                        }
                        if (aliveNeighborCount > 3)
                        {
                            Cells[ i, j ] = false;
                        }
                    }
                    else
                    {
                        if (aliveNeighborCount == 3)
                        {
                            Cells[ i, j ] = true;
                        }
                    }
                }
            }
        }

        private int GetNeighbors(int x, int y)
        {
            int aliveNeighborCount = 0;
            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!(i < 0 || j < 0 || i >= Heigth || j >= Width))
                    {
                        if (Cells[ i, j ] == true) aliveNeighborCount++;
                    }
                }
            }
            return aliveNeighborCount;
        }

        private void DrawBoard()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(Cells[ i, j ] ? "x" : " ");
                    if (j == Width - 1)
                    {
                        Console.WriteLine("\r");
                    }
                }
            }
            Console.SetCursorPosition(0, 50);
        }

        private void GenerateCellContent()
        {
            Random randomGen = new Random();
            int number;
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    number = randomGen.Next(2);
                    Cells[ i, j ] = (number == 0) ? false : true;
                }
            }
        }
    }
}

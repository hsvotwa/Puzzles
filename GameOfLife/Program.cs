using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your desired frame height?");
            int.TryParse(Console.ReadLine(), out int boardHeight);
            Console.WriteLine("What is your desired frame width?");
            int.TryParse(Console.ReadLine(), out int width);
            Console.WriteLine("How many generations do you want the frame to run for?");
            int.TryParse(Console.ReadLine(), out int generationCount);
            int generationsConvered = 0;

            GameOfLife sim = new GameOfLife(boardHeight, width);
            while (generationsConvered++ < generationCount)
            {
                sim.DrawAndGrow();
                //Delay the thread, to make the animations visible
                Thread.Sleep(300);
            }
            Console.ReadLine();
        }
    }
}

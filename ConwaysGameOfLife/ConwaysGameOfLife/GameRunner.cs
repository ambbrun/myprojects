using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ConwaysGameOfLife
{
    public class GameRunner : IGameRunner
    {
        private int WindowWidth { get; set; }
        private int WindowHeight { get; set; }
        private bool Running { get; set; }

        private ILifeAnalyzer _lifeAnalyzer;

        public GameRunner(ILifeAnalyzer lifeAnalyzer)
        {
            _lifeAnalyzer = lifeAnalyzer;
        }
        public void Stop()
        {
            Running = false;
        }

        public void StartGame(int initialPopulation, int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;
            Running = true;

            FillDefaultArray(initialPopulation);
            PrintLifeGameView();
            do
            {
                AnalizeLifeOrDeath();
                PrintLifeGameView();
            }
            while (true);

        }

        private void FillDefaultArray(int initialPopulation)
        {
            _lifeAnalyzer.InitializeLifeArray(WindowWidth, WindowHeight);
            var rnd = new Random();
            for (int i = 0; i <= initialPopulation; i++)
            {
                int randomX = rnd.Next(1, WindowWidth);
                int randomY = rnd.Next(1, WindowHeight);
                _lifeAnalyzer.LifeArray[randomX, randomY] = true;
            }
        }

        private void PrintLifeGameView()
        {
            for (int x = 0; x < WindowWidth; x++)
            {
                for (int y = 0; y < WindowHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(_lifeAnalyzer.GetHasLife(x, y) ? "X" : " ");
                }
            }
        }

        private void AnalizeLifeOrDeath()
        {
            for (int coordX = 0; coordX < WindowWidth; coordX++)
            {
                for (int coordY = 0; coordY < WindowHeight; coordY++)
                {
                    _lifeAnalyzer.SetDeathOrAlive(coordX, coordY);
                }
            }
        }
    }
}

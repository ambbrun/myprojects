using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public class LifeAnalyzer : ILifeAnalyzer
    {
        private int WindowWidth { get; set; }
        private int WindowHeight { get; set; }
        public bool[,] LifeArray { get; private set; }

        public bool[,] InitializeLifeArray(int width, int height)
        {
            if (LifeArray == null)
            {
                WindowWidth = width;
                WindowHeight = height;
                LifeArray = new bool[width, height];
            }
            return LifeArray;
        }
        public bool GetHasLife(int x, int y) =>  LifeArray[x, y];

        public void SetDeathOrAlive(int cX, int cY)
        {
            var numberOfNeighbors = GetNumberOfNeighbors(cX, cY);

            if (numberOfNeighbors <= 1)
            {
                LifeArray[cX, cY] = false;
            }
            else if (numberOfNeighbors >= 4)
            {
                LifeArray[cX, cY] = false;
            }
            else if (numberOfNeighbors == 3)
            {
                LifeArray[cX, cY] = true;
            }
            else
            {
                LifeArray[cX, cY] = LifeArray[cX, cY];
            }
        }

        private int GetNumberOfNeighbors(int x, int y)
        {
            int numberOfNeighbors = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 || j < 0)
                        continue;

                    if (i == x && j == y)
                        continue;

                    if (i + 1 > WindowWidth || j + 1 > WindowHeight)
                        continue;

                    numberOfNeighbors = (GetHasLife(i, j)) ? numberOfNeighbors + 1 : numberOfNeighbors;
                }
            }
            return numberOfNeighbors;
        }
    }
}

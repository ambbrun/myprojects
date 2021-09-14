using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public interface ILifeAnalyzer
    {
        bool[,] LifeArray { get; }

        bool[,] InitializeLifeArray(int width, int height);

        bool GetHasLife(int x, int y);

        void SetDeathOrAlive(int cX, int cY);
    }
}

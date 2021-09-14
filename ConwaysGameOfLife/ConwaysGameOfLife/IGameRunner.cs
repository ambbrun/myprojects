using System;
using System.Collections.Generic;
using System.Text;

namespace ConwaysGameOfLife
{
    public interface IGameRunner
    {
        void Stop();

        void StartGame(int initialPopulation, int width, int height);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConwaysGameOfLife
{
    public class Application : IApplication
    {
        private const int INITIAL_POPULATION = 500;

        IGameRunner _gameRunner;

        public Application(IGameRunner gameRunner)
        {
            _gameRunner = gameRunner;
        }
        public void Run()
        {
            ThreadPool.QueueUserWorkItem(
                (obj) => {
                    _gameRunner.StartGame(INITIAL_POPULATION, Console.WindowWidth, Console.WindowHeight);
                }
            );
            Console.ReadKey();
            _gameRunner.Stop();
            Console.Clear();
        }
    }
}

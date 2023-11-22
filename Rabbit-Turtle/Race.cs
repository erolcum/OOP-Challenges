using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Race
    {
        private Path path;
        private bool raceOver;
        public Race() 
        { 
            path = new Path();
            new Turtle(0, 0, "Turtle");
            new Rabbit(0, 1, "Rabbit");
            raceOver = false;
        }

        private void SetupRace()
        { 
            foreach (var runner in Runner.Runners) 
            {
                path.RunnerPosition(runner);
            }
            Console.WriteLine("Press any Enter key to continue");
        }

        public void GetPlace() 
        {
            foreach (var runner in Runner.Runners)
            {
                if (runner.CurrentPosition == Path.PathLength)
                    Console.WriteLine("Winner is " + runner.Name);
            }
        }

        public void Racing() 
        { 
            SetupRace();

            do 
            {
                Console.ReadLine();
                Console.Clear();
                path.DisplayRacePath();

                foreach (var runner in Runner.Runners) 
                {
                    Console.WriteLine(runner.MoveDescription);
                    runner.CalculateMove();
                    path.RunnerPosition(runner);

                    if (runner.isWinner(runner))
                        raceOver = true;
                }
            } while (!raceOver);

            Console.Clear() ;
            path.DisplayRacePath();
            GetPlace();
        }
    }
}

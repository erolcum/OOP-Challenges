using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_Queens
{
    public class Program
    {
        static void Main(string[] args)
        {
            Run run = new Run();
            run.placeQueens();
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    public class Program
    {
        static void Main(string[] args)
        {
            ParkingLot lot = new ParkingLot();
            Random rand = new Random();
            Vehicle v = null;
            while (v == null || lot.parkVehicle(v))
            {
                lot.print();
                int r = rand.Next(0,10);
                if (r < 2)
                {
                    v = new Bus();
                }
                else if (r < 4)
                {
                    v = new Motorcycle();
                }
                else
                {
                    v = new Car();
                }
                Console.Write("\nParking a ");
                v.print();
                Console.WriteLine(""); 
            }
            Console.WriteLine("Parking Failed. Final state: ");
            lot.print();
            Console.ReadLine();
        }
    }
}

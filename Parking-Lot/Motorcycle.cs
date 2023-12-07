using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle()
        {
            spotsNeeded = 1;
            size = VehicleSize.Motorcycle;
        }
        public override bool canFitInSpot(ParkingSpot spot)
        {
            return true;
        }

        public override void print()
        {
            Console.Write("M");
        }
    }
}

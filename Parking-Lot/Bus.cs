using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    public class Bus : Vehicle
    {
        public Bus()
        {
            spotsNeeded = 5;
            size = VehicleSize.Large;
        }
        public override bool canFitInSpot(ParkingSpot spot)
        {
            return (spot.getSize() == VehicleSize.Large);
        }

        public override void print()
        {
            Console.Write("B");
        }
    }
}

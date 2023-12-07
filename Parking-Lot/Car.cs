using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    public class Car : Vehicle
    {
        public Car()
        {
            spotsNeeded = 1;
            size = VehicleSize.Compact;
        }
        public override bool canFitInSpot(ParkingSpot spot)
        {
            return spot.getSize() == VehicleSize.Large || spot.getSize() == VehicleSize.Compact;
        }

        public override void print()
        {
            Console.Write("C");
        }
    }
}

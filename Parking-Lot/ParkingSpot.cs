using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    public class ParkingSpot
    {
        private Vehicle vehicle;
        private VehicleSize spotSize;
        private int row;
        private int spotNumber;
        private Level level;

        public ParkingSpot(Level lvl, int r, int n, VehicleSize sz)
        {
            level = lvl;
            row = r;
            spotNumber = n;
            spotSize = sz;
        }

        public bool isAvailable()
        {
            return vehicle == null;
        }

        /* Checks if the spot is big enough for the vehicle (and is available). This compares
         * the SIZE only. It does not check if it has enough spots. */
        public bool canFitVehicle(Vehicle vehicle)
        {
            return isAvailable() && vehicle.canFitInSpot(this);
        }

        /* Park vehicle in this spot. */
        public bool park(Vehicle v)
        {
            if (!canFitVehicle(v))
            {
                return false;
            }
            vehicle = v;
            vehicle.parkInSpot(this);
            return true;
        }

        public int getRow()
        {
            return row;
        }

        public int getSpotNumber()
        {
            return spotNumber;
        }

        public VehicleSize getSize()
        {
            return spotSize;
        }

        /* Remove vehicle from spot, and notify level that a new spot is available */
        public void removeVehicle()
        {
            level.spotFreed();
            vehicle = null;
        }

        public void print()
        {
            if (vehicle == null)
            {
                if (spotSize == VehicleSize.Compact)
                {
                    Console.Write("c");
                }
                else if (spotSize == VehicleSize.Large)
                {
                    Console.Write("l");
                }
                else if (spotSize == VehicleSize.Motorcycle)
                {
                    Console.Write("m");
                }
            }
            else
            {
                vehicle.print();
            }
        }
    }
}

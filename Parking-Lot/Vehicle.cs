using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    public enum VehicleSize
    {
        Motorcycle,
        Compact,
        Large,
    }
    public abstract class Vehicle
    {
        protected List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
        protected String licensePlate;
        public int spotsNeeded;
        protected VehicleSize size;

        public int getSpotsNeeded()
        {
            return spotsNeeded;
        }

        public VehicleSize getSize()
        {
            return size;
        }

        /* Park vehicle in this spot (among others, potentially) */
        public void parkInSpot(ParkingSpot spot)
        {
            parkingSpots.Add(spot);
        }

        /* Remove car from spot, and notify spot that it's gone */
        public void clearSpots()
        {
            for (int i = 0; i < parkingSpots.Count; i++)
            {
                parkingSpots[i].removeVehicle();
            }
            parkingSpots.Clear();
        }

        public abstract bool canFitInSpot(ParkingSpot spot);
        public abstract void print();
    }
}

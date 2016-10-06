using System;

namespace BoatClub.Model
{
    public class Boat
    {
        private double _boatLength;

        public BoatType BoatType { get; set; }

        public double BoatLength
        {
            get { return _boatLength; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length of boat must be over 0 m and a numeric value.");
                } 
                _boatLength = value;
            }
        }

        public Boat()
        {
            
        }

        public Boat(BoatType boatType, double lengthInMeters) : this()
        {
            BoatType = boatType;
            BoatLength = lengthInMeters;
        }
    }
}

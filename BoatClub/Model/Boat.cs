
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
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _boatLength = value;
            }
        }

        public Boat()
        {
            
        }

        public Boat(BoatType boatType, double length) : this()
        {
            BoatType = boatType;
            BoatLength = length;
        }

        public override string ToString() => string.Format($"{BoatType}, {BoatLength} cm");

    }
}

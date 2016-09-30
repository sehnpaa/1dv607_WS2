
namespace BoatClub.Model
{
    public class Boat
    {
        public double BoatLength { get; set; }

        public BoatType BoatType { get; set; }

        public Boat(BoatType boatType)
        {
            BoatType = boatType;
        }

        public override string ToString() => string.Format($"{(char) BoatType}");
    }
}

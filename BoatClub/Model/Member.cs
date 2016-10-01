using System;
using System.Collections.Generic;

namespace BoatClub.Model
{
    public class Member
    {
        private static int _id = 0; // TODO check

        private string _name;
        private string _personalNumber;
       
        public List<Boat> Boats = new List<Boat>();

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _name = value;
            }
        }

        public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _personalNumber = value;
            }
        }

        internal Boat Boat // TODO
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

        public string MemberId { get; }


        public Member()
        {

        }

        public Member(string name, string pNumber) : this()
        {
            _id++; // Todo check
            Name = name;
            PersonalNumber = pNumber;
            MemberId = _id.ToString(); // Todo check
        }

        public override string ToString() => string.Format($"{MemberId}, {Name}, {PersonalNumber}");
    }
}
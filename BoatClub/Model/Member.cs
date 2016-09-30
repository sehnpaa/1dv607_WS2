using System;
using System.Collections.Generic;

namespace BoatClub.Model
{
    public class Member
    {
        private string _name;
        private string _personalNumber;
        public string MemberId;
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
            }
        }

        public Member()
        {
            
        }

        public Member(string name, string pNumber)
        {
            Name = name;
            PersonalNumber = pNumber;
        }

        public override string ToString() => string.Format($"{MemberId}, {Name}, {PersonalNumber}");
    }
}

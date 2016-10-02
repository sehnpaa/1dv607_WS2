using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;

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

        public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                if (IsPersonalNumberValid(value) == false)
                {
                    throw new ArgumentException(nameof(value));
                }
                _personalNumber = value;
            }
        }

        public Member()
        {

        }

        public Member(string name, string pNumber) : this()
        {
            // TODO implement correct ID:
            _id++; // Todo check
            MemberId = _id.ToString();

            Name = name;
            PersonalNumber = pNumber;
            
        }

        internal void AddBoat(Boat boat)
        {
            Boats.Add(boat);
        }

       private static bool IsPersonalNumberValid(string number)
        {
            Regex regEx = new Regex(@"^(\d{1})(\d{5})\-(\d{4})$");
            Match matchInNumber = regEx.Match(number);

            return matchInNumber.Success;
        }
    
        public override string ToString() => string.Format(
            $"{MemberId}, " +
            $"{Name}, " +
            $"{PersonalNumber}, " +
            $" {string.Join(", ", Boats)}");
    }
}
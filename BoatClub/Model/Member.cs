using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BoatClub.Model
{
    public class Member
    {
        private string _name;
        private string _personalNumber;
        private DateTime _dateOfBirth;

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
                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    throw new ArgumentException("Invalid characters in member name. Only letters allowed!");
                }
                _name = value;
            }
        }

        public string MemberId { get; set; }

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
                    throw new ArgumentException("Please enter a valid personal number: YYYYMMDD-XXXX");
                }
                if (GetMemberAge() < 18)
                {
                    throw new Exception("You must be of age 18 to become a member.");
                }
                _personalNumber = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public Member()
        {
        }

        public Member(string name, string personalNumber, string id) : this()
        {
            Name = name;
            PersonalNumber = personalNumber;
            MemberId = id;
        }

        internal void AddBoat(Boat boat)
        {
            Boats.Add(boat);
        }

        private bool IsPersonalNumberValid(string number)
        {
            const string regEx = @"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$";
            var date = Regex.Match(number, regEx).Groups["date"].Value;

            return DateTime.TryParseExact(date, new[] {"yyyyMMdd"},
                new CultureInfo("sv-SE"), DateTimeStyles.None, out _dateOfBirth);
        }

        public int GetMemberAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age))
                age--;
            return age;
        }
    }
}
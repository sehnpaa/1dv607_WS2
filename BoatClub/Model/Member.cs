using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BoatClub.Model
{
    public class Member
    {
        private static int _id; // TODO check
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
            _id++;
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
            const string regEx = @"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$";
            var date = Regex.Match(number, regEx).Groups["date"].Value;
            DateTime dateTime;

            if (DateTime.TryParseExact(date, new[] {"yyMMdd", "yyyyMMdd"},
                new CultureInfo("sv-SE"), DateTimeStyles.None, out dateTime))
            {
                //Console.WriteLine(IsOfLegalAge(dateTime));
                return true;
            }

            return false;
        }

        public static bool IsOfLegalAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            //Console.WriteLine(age);
            if (birthdate > today.AddYears(-age))
                age--;
            return age >= 18;
        }

        public override string ToString()
        {
            return ToString("CL");
        }

        public string ToString(string format)
        {
            string output = "";

            if (format == "CL")
            {
                output = string.Format($"\nMember: {Name} " + $"\nID: {MemberId} " + $"\nNumber of Boats: {Boats.Count}");
            }

            if (format == "VL")
            {
                output = string.Format($"\nMember: {Name} " +
                                       $"\nPersonalNumber: {PersonalNumber} " +
                                       $"\nID: {MemberId} " +
                                       $"\nBoats: \n{string.Join("| ", Boats)}\n");
            }
            return output;
        }
    }
}
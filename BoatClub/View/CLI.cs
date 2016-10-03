using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BoatClub.Model;

namespace BoatClub.View
{
    class CLI
    {
        private MemberRegistry model;

        public CLI(MemberRegistry model)
        {
            // TODO: Complete member initialization
            this.model = model;
            DisplayApplicationHeader();
        }
        public void Display(string output)
        {
            Console.WriteLine(output);
        }

        public void DisplayMemberListVerbose(List<Member> memberList)
        {
            foreach (var m in memberList)
            {
                Console.WriteLine("Name: ", m.Name);
                Console.WriteLine("Member ID: ", m.MemberId);
                Console.WriteLine("Personal number: ", m.PersonalNumber);
                Console.WriteLine("Boats: ", m.Boats.Count);    // TODO: List boat details instead
            }
        }

        private void DisplayApplicationHeader()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Boat Club Version[1.0.0]");
            Console.WriteLine("2016 C. Trosell, P. Andersson, U. Skarin\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("Examples of valid commands:");
            Console.WriteLine("create_member Sven 550101-0000");
            Console.WriteLine("list_members_VL");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

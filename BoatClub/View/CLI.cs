using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using BoatClub.Model;

namespace BoatClub.View
{
    class CLI
    {
        const string SingleLine = "-----------------------------------";
        const string DoubleLine = "==========================================";
        private MemberRegistry model;

        public CLI(MemberRegistry model)
        {
            this.model = model;
            DisplayApplicationHeader();
        }
        public void DisplayMember(Member member)
        {
            DisplayMemberVerbose(member);
        }

        public void DisplayMemberListVerbose(List<Member> memberList)
        {
            foreach (var m in memberList)
            {
                DisplayMemberVerbose(m);
            }
        }

        public void DisplayMemberListCompact(List<Member> memberList)
        {
            foreach (var m in memberList)
            {
                DisplayMemberCompact(m);
            }
        }

        public void DisplayListOfCommands(Dictionary<string, int> commands)
        {
            Console.WriteLine("");
            foreach (var command in commands)
            {
                Console.WriteLine($"{command.Key}");
            }
            Console.WriteLine("");
        }

        public void Display(string s)
        {
            Console.WriteLine(s);
        }

        private void DisplayMemberCompact(Member m)
        {
            Console.WriteLine(
                string.Format($"\nMember: {m.Name} \nID: {m.MemberId} \nNumber of Boats: {m.Boats.Count}\n{SingleLine}"));
        }

        private void DisplayMemberVerbose(Member m)
        {
            Console.WriteLine($"\nName: {m.Name} \nMember ID: {m.MemberId} \nPersonal number: {m.PersonalNumber}" );
            Console.WriteLine(SingleLine);

            foreach (var b in m.Boats)
            {
                DisplayBoat(b);
            }
        }

        private void DisplayBoat(Boat b)
        {
            Console.WriteLine($"\tBoat type: {b.BoatType} \tBoat length: {b.BoatLength}");
        }

        private void DisplayApplicationHeader()
        {
            Console.Title = "Boat Club";
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Boat Club Version[1.0.0]");
            Console.WriteLine($"2016 C. Trosell, P. Andersson, U. Skarin\n{DoubleLine}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine($"Examples of valid commands:\n{SingleLine}");
            Console.WriteLine("create_member Sven 19550101-0000");
            Console.WriteLine("update_member 5 Sven 19550101-0000");
            Console.WriteLine("delete_member 5");
            Console.WriteLine("info_member 7");
            Console.WriteLine("list_members_VL");
            Console.WriteLine("list_members_CL");
            Console.WriteLine("add_boat 5 SailBoat 12.5");
            Console.WriteLine("update_boat 5 3 Other 11.5");
            Console.WriteLine("remove_boat 5 3");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

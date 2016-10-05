using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using BoatClub.Model;

namespace BoatClub.View
{
    internal class CLI
    {
        public static string SingleLine = new string('-', 50);
        public static string DoubleLine = new string('=', 50);

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

        public void Display(string s)
        {
            Console.WriteLine(s);
        }

        public void DisplayMemberCompact(Member m)
        {
            Console.WriteLine(
                string.Format($"\nMember: {m.Name} \nID: {m.MemberId} \nNumber of Boats: {m.Boats.Count}\n{SingleLine}"));
        }

        public void DisplayMemberVerbose(Member m)
        {
            Console.WriteLine($"\nName: {m.Name} \nMember ID: {m.MemberId} \nPersonal number: {m.PersonalNumber}" );
            Console.WriteLine(SingleLine);

            int i = 1;
            foreach (var b in m.Boats)
            {
                Console.Write($"\t{i}. ");
                DisplayBoat(b);
                i++;
            }
        }

        public void DisplayBoat(Boat b)
        {
            Console.WriteLine($"Boat type: {b.BoatType} \tBoat length: {b.BoatLength}");
        }

        public void DisplayValidCommands()
        {
            Console.ResetColor();
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
            Console.WriteLine("help");
            Console.WriteLine();
        }

        private void DisplayApplicationHeader()
        {
            Console.Title = "Boat Club";
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Boat Club Version[1.0.0]");
            Console.WriteLine($"2016 C. Trosell, P. Andersson, U. Skarin\n{DoubleLine}");

            DisplayValidCommands();
        }
    }
}

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

            if (m.Boats.Count > 0) {
                Console.WriteLine("Boats:");

                int i = 1;
                foreach (var b in m.Boats)
                {
                    Console.Write($"\t{i}. ");
                    DisplayBoat(b);
                    i++;
                }
            } else
            {
                Display("Boats: This member has no boats yet.");
            }


        }

        public void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        public void DisplayBoat(Boat b)
        {
            Console.WriteLine($"{b.BoatType} {b.BoatLength}m");
        }

        public void DisplayValidCommands()
        {
            Console.WriteLine();
            Console.WriteLine($"Commands:\n{SingleLine}");
            Console.WriteLine("add-member <name> <YYYYMMDD-XXXX>");
            Console.WriteLine("update-member <id> <name> <YYYYMMDD-XXXX>");
            Console.WriteLine("delete-member <id>");
            Console.WriteLine("list-member <id>");
            Console.WriteLine("list-members-vl");
            Console.WriteLine("list-members-cl");
            Console.WriteLine("add-boat <id> <boatType> <lengthInMeters>");
            Console.WriteLine("update-boat <id> <boat-id> <boatType> <lengthInMeters>");
            Console.WriteLine("remove-boat <id> <boat-id>");
            Console.WriteLine("clear");
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
            Console.ResetColor();
            Console.WriteLine("\nWrite help to get a list of commands.");
        }

        public void ClearConsole()
        {
            Console.Clear();
            DisplayApplicationHeader();
        }
    }
}

﻿using System;
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

        public void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
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
            Console.WriteLine("add-member <name> <YYYYMMDD-XXXX>");
            Console.WriteLine("update-member <id> <name> <YYYYMMDD-XXXX>");
            Console.WriteLine("delete-member <id>");
            Console.WriteLine("list-member <id>");
            Console.WriteLine("list-members-VL");
            Console.WriteLine("list-members-CL");
            Console.WriteLine("add-boat <id> <boatType> <lengthInMeters>");
            Console.WriteLine("update-boat <id> <boat-id> <boatType> <lengthInMeters>");
            Console.WriteLine("remove-boat <id> <boat-id>");
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

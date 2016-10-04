﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using BoatClub.Model;

namespace BoatClub.View
{
    class CLI
    {
        private MemberRegistry model;

        public CLI(MemberRegistry model)
        {
            this.model = model;
            DisplayApplicationHeader();
        }
        public void DisplayMember(Member member)
        {
            DisplayMemberCompact(member);
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

        private void DisplayMemberCompact(Member m)
        {
            Console.WriteLine(
                string.Format($"\nMember: {m.Name} " + $"\nID: {m.MemberId} " + $"\nNumber of Boats: {m.Boats.Count}"));
        }

        private void DisplayMemberVerbose(Member m)
        {
            Console.WriteLine("Name: " + m.Name);
            Console.WriteLine("Member ID: " + m.MemberId);
            Console.WriteLine("Personal number: " + m.PersonalNumber);
            foreach (var b in m.Boats)
            {
                DisplayBoat(b);
            }
        }

        private void DisplayBoat(Boat b)
        {
            Console.WriteLine("\tBoat type: " + b.BoatType);
            Console.WriteLine("\tBoat length: " + b.BoatLength);
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
            Console.WriteLine("update_member 5 Shven 560101-0000");
            Console.WriteLine("info_member 7");
            Console.WriteLine("list_members_VL");
            Console.WriteLine("list_members_CL");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

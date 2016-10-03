using System;
using System.Collections.Generic;

namespace BoatClub.Model
{
    class MemberRegistry
    {

        public List<MemberListVerboseItem> GetMemberListVerbose()
        {
            List<Member> memberList = XML.GetMemberListFromXMLFile();
            List<MemberListVerboseItem> memberListVerbose = new List<MemberListVerboseItem>();
            
            memberList.ForEach(delegate(Member member)
            {
                MemberListVerboseItem memberListVerboseItem = new MemberListVerboseItem()
                {
                    Name = member.Name,
                    MemberID = member.MemberId,
                    PersonalNumber = member.PersonalNumber,
                    Boats = member.Boats
                };

                memberListVerbose.Add(memberListVerboseItem);
            });


            return memberListVerbose;
        }

        public List<MemberListCompactItem> GetMemberListCompact() 
        {
            List<Member> memberList = XML.GetMemberListFromXMLFile();
            List<MemberListCompactItem> memberListCompact = new List<MemberListCompactItem>();

            memberList.ForEach(delegate (Member member)
            {
                MemberListCompactItem memberListVerboseItem = new MemberListCompactItem()
                {
                    Name = member.Name,
                    MemberID = member.MemberId,
                    NumberOfBoats = member.Boats.Count
                };

                memberListCompact.Add(memberListVerboseItem);
            });


            return memberListCompact;
        }

        public List<Member> GetMemberList()
        {
            try
            {
                List<Member> memberList = XML.GetMemberListFromXMLFile();
                return memberList;
            } catch(Exception e)
            {
                Console.WriteLine("Det fanns ingen membersList fil att hämta, därför returneras en ny lista. MemberRegistry:60");
                return new List<Member>();
            }

        } 

        public void SaveMemberList(List<Member> memberList)
        {
            XML.SaveMemberListToXMLFile(memberList);
        }

        public void SaveMember(Member member)
        {
            List<Member> memberList = GetMemberList();
            memberList.Add(member);
            SaveMemberList(memberList);
        }

        [Obsolete("Please use MemberRegistry.SaveMember instead")]
        public void Register(String name)
        {

        }

        [Obsolete("Please use MemberRegistry.GetMemberListVerbose instead")]
        public String GetMembersVl()
        {
            return XML.load();
        }

        public String GetNextMemberId()
        {
            return "5";
        }

    }
}

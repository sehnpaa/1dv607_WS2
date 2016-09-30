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
            List<Member> memberList = XML.GetMemberListFromXMLFile();
            return memberList;
        } 


        public void Register(String name)
        {

        }
        public String GetMembersVl()
        {
            return XML.load();
        }

    }
}

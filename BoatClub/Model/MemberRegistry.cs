using System;
using System.Collections.Generic;

namespace BoatClub.Model
{
    class MemberRegistry
    {
        public List<Member> GetMemberList()
        {
            List<Member> memberList = XML.GetMemberListFromXMLFile();
            return memberList;

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

        public String GetNextMemberId()
        {
            return "5";
        }

    }
}

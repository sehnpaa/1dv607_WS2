using System;
using System.Collections.Generic;

namespace BoatClub.Model
{
    class MemberRegistry
    {
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

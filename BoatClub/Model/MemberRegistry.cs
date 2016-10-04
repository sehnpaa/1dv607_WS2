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
            int id;
            List<Member> memberList = GetMemberList();

            if (memberList.Count == 0) return "1";
            var lastId = memberList[memberList.Count - 1].MemberId;
            int.TryParse(lastId, out id);
            id++;

            return id.ToString();
        }

        public Member GetMemberById(string id)
        {
            return new Member("Dummy member in MemberRegistry", "101010-0101", "9");  // TODO: Get actual member
        }

        public void UpdateMember(string memberId, string newName, string newPersonalNumber)
        {

        }
    }
}

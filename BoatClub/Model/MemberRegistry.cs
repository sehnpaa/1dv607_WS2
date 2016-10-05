using System;
using System.Collections.Generic;

namespace BoatClub.Model
{
    internal class MemberRegistry
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

        public string GetNextMemberId()
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
            Member memberToGet = null;
            List<Member> memberList = GetMemberList();
            foreach(Member member in memberList)
            {
                if (member.MemberId == id)
                {
                    memberToGet = member;
                    break;
                }
            }

            if (memberToGet == null)
            {
                throw new Exception($"Member with id {id} does not exist.");
            }

            return memberToGet;
        }

        public Member DeleteMemberById(string id)
        {
            List<Member> memberList = GetMemberList();
            Member deletedMember = null;
            List<Member> updatedMemberList = new List<Member>();

            foreach (Member member in memberList)
            {
                if (member.MemberId == id)
                {
                    deletedMember = member;
                    continue;
                }

                updatedMemberList.Add(member);
            }

            if (deletedMember == null)
            {
                throw new Exception($"Member with id {id} could not be deleted. Not found.");
            }

            SaveMemberList(updatedMemberList);

            return deletedMember;
        }

        public void UpdateMember(string memberId, string newName, string newPersonalNumber)
        {
            List<Member> memberList = GetMemberList();

            foreach(Member member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    member.Name = newName;
                    member.PersonalNumber = newPersonalNumber;
                    break;
                }
            }

            SaveMemberList(memberList);
        }

        public string DeleteMember(string memberId)
        {
            return "Member was deleted.";
        }

        public void AddBoat(string memberId, Boat boat)
        {
            List<Member> memberList = GetMemberList();
            bool found = false;

            foreach (Member member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    member.Boats.Add(boat);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                throw new Exception("No member with that id.");
            }

            SaveMemberList(memberList);
        }

        public void UpdateBoat(string memberId, int boatIndex, string boatTypeInput, float length)
        {
            List<Member> memberList = GetMemberList();

            foreach(Member member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    Boat boat = member.Boats[boatIndex - 1];
                    BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), boatTypeInput);
                    boat.BoatType = boatType;
                    boat.BoatLength = length;
                }
            }

            SaveMemberList(memberList);
        }

        public void RemoveBoat(string memberId, string boatId)
        {
            List<Member> memberList = GetMemberList();
            Member memberToBeFound = null;
            int index;

            int.TryParse(boatId, out index);

            foreach(Member member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    memberToBeFound = member;

                    if (index < 1 || index > member.Boats.Count)
                    {
                        throw new Exception($"Boat index {index} is out of range.");
                    }
                    member.Boats.RemoveAt(index - 1);
                }
            }

            if (memberToBeFound == null)
            {
                throw new Exception($"Could not remove boat. Member with id {memberId} was not found.");
            }

            SaveMemberList(memberList);
        }
    }
}
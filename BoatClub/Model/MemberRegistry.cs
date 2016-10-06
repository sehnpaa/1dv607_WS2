using System;
using System.Collections.Generic;

namespace BoatClub.Model
{
    internal class MemberRegistry
    {
        public List<Member> GetMemberList()
        {
            var memberList = XML.GetMemberListFromXMLFile();
            return memberList;
        }

        public void SaveMemberList(List<Member> memberList)
        {
            XML.SaveMemberListToXMLFile(memberList);
        }

        public void SaveMember(Member member)
        {
            var memberList = GetMemberList();
            memberList.Add(member);
            SaveMemberList(memberList);
        }

        public string GetNextMemberId()
        {
            int id;
            var memberList = GetMemberList();

            if (memberList.Count == 0) return "1";
            var lastId = memberList[memberList.Count - 1].MemberId;
            int.TryParse(lastId, out id);
            id++;

            return id.ToString();
        }

        public Member GetMemberById(string id)
        {
            Member memberToGet = null;
            var memberList = GetMemberList();
            foreach (var member in memberList)
            {
                if (member.MemberId == id)
                {
                    memberToGet = member;
                    break;
                }
            }

            if (memberToGet == null)
            {
                throw new Exception($"Member with id: {id} does not exist.");
            }

            return memberToGet;
        }

        public Member DeleteMemberById(string id)
        {
            var memberList = GetMemberList();
            Member deletedMember = null;
            var updatedMemberList = new List<Member>();

            foreach (var member in memberList)
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
            var memberList = GetMemberList();
            Member memberToBeFound = null;

            foreach (var member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    memberToBeFound = member;
                    member.Name = newName;
                    member.PersonalNumber = newPersonalNumber;
                    break;
                }
            }

            if (memberToBeFound == null)
            {
                throw new Exception($"Member with id {memberId} does not exist.");
            }

            SaveMemberList(memberList);
        }

        public string DeleteMember(string memberId)
        {
            return $"Successfully deleted member with id: {memberId}";
        }

        public void AddBoat(string memberId, Boat boat)
        {
            var memberList = GetMemberList();
            var found = false;

            foreach (var member in memberList)
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
            var memberList = GetMemberList();

            foreach (var member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    var boat = member.Boats[boatIndex - 1];

                    var boatType = (BoatType) Enum.Parse(typeof(BoatType), boatTypeInput);
                    boat.BoatType = boatType;
                    boat.BoatLength = length;
                }
            }

            SaveMemberList(memberList);
        }

        public void DeleteBoat(string memberId, int boatIndex)
        {
            var memberList = GetMemberList();
            Member memberToBeFound = null;

            foreach (var member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    memberToBeFound = member;

                    if (boatIndex < 1 || boatIndex > member.Boats.Count)
                    {
                        throw new Exception($"Boat index {boatIndex} is out of range.");
                    }
                    member.Boats.RemoveAt(boatIndex - 1);
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
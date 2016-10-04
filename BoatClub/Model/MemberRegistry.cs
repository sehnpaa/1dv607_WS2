﻿using System;
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

        //TODO: Test if MemberRegistry.DeleteMemberById is working
        public void DeleteMemberById(string id)
        {
            List<Member> updatedMemberList = new List<Member>();
            List<Member> memberList = GetMemberList();
            
            foreach(Member member in memberList)
            {
                if (member.MemberId == id)
                {
                    continue;
                }

                updatedMemberList.Add(member);
            }

            SaveMemberList(updatedMemberList);
        }

        public void UpdateMember(string memberId, string newName, string newPersonalNumber)
        {
            Member member = GetMemberById(memberId);
            member.Name = newName;
            member.PersonalNumber = newPersonalNumber;

            DeleteMemberById(memberId);

            List<Member> memberList = GetMemberList();

            memberList.Add(member);

            SaveMemberList(memberList);
        }

        public string DeleteMember(string memberId)
        {
            return "Member was deleted.";
        }

        public void AddBoat(string memberId, string boatType, float length)
        {

        }
    }
}
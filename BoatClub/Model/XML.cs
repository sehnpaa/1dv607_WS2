using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BoatClub.Model
{
    class XML
    {
        private static string MemberListXMLPath = "../../Storage/membersList.xml";

        public static void SaveMemberListToXMLFile(List<Member> memberList)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Member>));
            FileStream file = File.Create(MemberListXMLPath);
            writer.Serialize(file, memberList);
            file.Close();
        }

        public static List<Member> GetMemberListFromXMLFile()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Member>));
            StreamReader file = new StreamReader(MemberListXMLPath);
            List<Member> memberList = (List<Member>)reader.Deserialize(file);
            file.Close();

            return memberList;
        }

        public static String load()
        {
            // Load data
            return "dummy data";
        }
    }
}

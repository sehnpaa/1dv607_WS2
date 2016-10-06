using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BoatClub.Model
{
    internal class XML
    {
        private static string MemberListXMLPath = "./memberList.xml";

        public static void SaveMemberListToXMLFile(List<Member> memberList)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Member>));
            FileStream file = File.Create(MemberListXMLPath);
            writer.Serialize(file, memberList);
            file.Close();
        }

        public static List<Member> GetMemberListFromXMLFile()
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(MemberListXMLPath);
                List<Member> memberList = (List<Member>)reader.Deserialize(file);
                file.Close();

                return memberList;
            } catch(FileNotFoundException)
            {
                return new List<Member>();
            } catch (Exception e)
            {
                throw e;
            }

        }

        [Obsolete("Please use GetMemberListFromXMLFile instead.")]
        public static string load()
        {
            // Load data
            return "dummy data";
        }
    }
}

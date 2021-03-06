﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BoatClub.Model
{
    internal class XML
    {
        private static string _memberListXmlPath = "./memberList.xml";

        public static void SaveMemberListToXMLFile(List<Member> memberList)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Member>));
            FileStream file = File.Create(_memberListXmlPath);
            writer.Serialize(file, memberList);
            file.Close();
        }

        public static List<Member> GetMemberListFromXMLFile()
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(_memberListXmlPath);
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
    }
}

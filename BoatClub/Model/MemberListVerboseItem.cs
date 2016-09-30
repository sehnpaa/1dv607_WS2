using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatClub.Model
{
    class MemberListVerboseItem //Name, personal number, member id, boats with information
    {
        public string Name;
        public string MemberID;
        public string PersonalNumber;
        public List<Boat> Boats;
    }
}

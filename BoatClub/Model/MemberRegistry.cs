using System;

namespace BoatClub.Model
{
    class MemberRegistry
    {
        public void Register(String name)
        {
            XML.save(name);
        }
        public String GetMembersVl()
        {
            return XML.load();
        }

    }
}

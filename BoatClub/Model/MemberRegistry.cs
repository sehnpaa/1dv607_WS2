using System;
using BoatClub.Storage;

namespace BoatClub.Model
{
    class MemberRegistry
    {
        public void register(String name)
        {
            XML.save(name);
        }
        public String getMembersVL()
        {
            return XML.load();
        }

    }
}

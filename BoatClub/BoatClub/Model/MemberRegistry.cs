using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

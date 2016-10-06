using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MemberUpdater : Interface1
    {
        public MemberUpdater()
        {
        }

        public void RecieveFromM(List<string> args, MemberRegistry registry)
        {
            var id = args[0];
            var name = args[1];
            var personalNumber = args[2];
            registry.UpdateMember(id, name, personalNumber);
        }

        public void SendToV(CLI cli)
        {

        }
    }
}
using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MemberUpdater : ICommandHandler
    {
        private Member _member;

        public MemberUpdater()
        {
        }

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            string id = args[0];
            string name = args[1];
            string personalNumber = args[2];
            registry.UpdateMember(id, name, personalNumber);
            _member = registry.GetMemberById(id);
        }

        public void SendToView(CLI cli)
        {
            cli.Display("Successfully updated member.");
            cli.DisplayMember(_member);
        }
    }
}
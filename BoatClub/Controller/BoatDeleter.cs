using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class BoatDeleter : ICommandHandler
    {
        private Member _member;

        public BoatDeleter()
        {
        }

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            string memberId = args[0];
            int boatIndex = int.Parse(args[1]);

            registry.DeleteBoat(memberId, boatIndex);
            _member = registry.GetMemberById(memberId);
        }

        public void SendToView(CLI cli)
        {
            cli.Display($"Successfully deleted boat.");
            cli.DisplayMemberVerbose(_member);
        }
    }
}
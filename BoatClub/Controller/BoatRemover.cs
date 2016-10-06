using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class BoatRemover : ICommandHandler
    {
        public BoatRemover()
        {
        }

        public void RecieveFromM(List<string> args, MemberRegistry registry)
        {
            var memberId = args[0];
            var boatIndex = int.Parse(args[1]);

            registry.RemoveBoat(memberId, boatIndex);
        }

        public void SendToV(CLI cli)
        {

        }
    }
}
using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class Helper : ICommandHandler
    {
        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {

        }

        public void SendToView(CLI cli)
        {
            cli.DisplayValidCommands();
        }
    }
}
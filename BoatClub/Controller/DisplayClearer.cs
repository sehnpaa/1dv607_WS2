using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class DisplayClearer : Interface1
    {
        public void RecieveFromM(List<string> args, MemberRegistry registry)
        {

        }

        public void SendToV(CLI cli)
        {
            cli.ClearConsole();
        }
    }
}
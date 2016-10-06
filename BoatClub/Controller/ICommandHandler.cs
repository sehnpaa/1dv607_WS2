using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    interface ICommandHandler
    {
        void RecieveFromModel(List<string> args, MemberRegistry registry);
        void SendToView(CLI cli);
    }
}

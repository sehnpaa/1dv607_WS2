using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    interface Interface1
    {
        void RecieveFromM(List<string> args, MemberRegistry registry);
        void SendToV(CLI cli);
    }
}

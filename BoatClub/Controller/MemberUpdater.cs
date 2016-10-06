﻿using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MemberUpdater : ICommandHandler
    {
        public MemberUpdater()
        {
        }

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            var id = args[0];
            var name = args[1];
            var personalNumber = args[2];
            registry.UpdateMember(id, name, personalNumber);
        }

        public void SendToView(CLI cli)
        {

        }
    }
}
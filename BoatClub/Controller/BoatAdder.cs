using System;
using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class BoatAdder : ICommandHandler
    {
        private Member _member;

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            var memberId = args[0];
            var boatTypeInput = args[1];
            var lengthInMetresInput = args[2];

            registry.AddBoat(memberId, boatTypeInput, lengthInMetresInput);
            _member = registry.GetMemberById(memberId);
        }

        public void SendToView(CLI cli)
        {
            cli.Display("Successfully added boat.");
            cli.DisplayMember(_member);
        }
    }
}
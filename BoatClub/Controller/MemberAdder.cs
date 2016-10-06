using System;
using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MemberAdder : ICommandHandler
    {
        private Member _member;

        public MemberAdder()
        {
        }

        public void RecieveFromM(List<string> args, MemberRegistry registry)
        {
            var name = args[0];
            var personalNumber = args[1];
            _member = new Member(name, personalNumber, registry.GetNextMemberId());
            registry.SaveMember(_member);
        }

        public void SendToV(CLI cli)
        {
            cli.Display("Successfully added member.");
            cli.DisplayMember(_member);
        }

    }
}
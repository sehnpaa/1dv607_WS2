using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MemberLister : ICommandHandler
    {
        private Member _member;
        public MemberLister()
        {
        }

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            string id = args[0];
            _member = registry.GetMemberById(id);
        }

        public void SendToView(CLI cli)
        {
            cli.DisplayMember(_member);
        }
    }
}
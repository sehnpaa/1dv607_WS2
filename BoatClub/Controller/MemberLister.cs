using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MemberLister : Interface1
    {
        private Member _member;
        public MemberLister()
        {
        }

        public void RecieveFromM(List<string> args, MemberRegistry registry)
        {
            var id = args[0];
            _member = registry.GetMemberById(id);
        }

        public void SendToV(CLI cli)
        {
            cli.DisplayMember(_member);
        }
    }
}
using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MembersListerVerbose : ICommandHandler
    {
        private List<Member> _memberList;
        public MembersListerVerbose()
        {
        }

        public void RecieveFromM(List<string> args, MemberRegistry registry)
        {
            _memberList = registry.GetMemberList();
        }

        public void SendToV(CLI cli)
        {
            if (_memberList.Count < 1)
            {
                cli.DisplayErrorMessage("Could not display verbose member list. No members found.");
            }
            else
            {
                cli.DisplayMemberListVerbose(_memberList);
            }
        }
    }
}
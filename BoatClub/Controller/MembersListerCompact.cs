using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MembersListerCompact : ICommandHandler
    {
        private List<Member>_memberList;
        public MembersListerCompact()
        {
        }

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            _memberList = registry.GetMemberList();
        }

        public void SendToView(CLI cli)
        {
            if (_memberList.Count < 1)
            {
                cli.DisplayErrorMessage("Could not display compact member list. No members found.");
                return;
            }
            cli.DisplayMemberListCompact(_memberList);
        }
    }
}
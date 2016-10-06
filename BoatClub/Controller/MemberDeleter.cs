using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class MemberDeleter : ICommandHandler
    {
        private Member _deletedMember;
        public MemberDeleter()
        {
        }

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            var memberId = args[0];
            _deletedMember = registry.DeleteMemberById(memberId);
        }

        public void SendToView(CLI cli)
        {
            cli.Display($"Member was successfully deleted.");
            cli.DisplayMemberVerbose(_deletedMember);
        }
    }
}
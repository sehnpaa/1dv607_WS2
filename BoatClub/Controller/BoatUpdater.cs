using System;
using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class BoatUpdater : ICommandHandler
    {
        private Member _member;
        public BoatUpdater()
        {
        }

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            string memberId = args[0];
            int boatIndex = int.Parse(args[1]);
            string boatType = args[2];

            if (boatIndex > _member.Boats.Count || boatIndex < 1)
            {
                throw new Exception($"Member {_member.Name} does not own a bot with id: {boatIndex}.");
            }

            if (Enum.IsDefined(typeof(BoatType), boatType))
            {
                float length = float.Parse(args[3]);
                registry.UpdateBoat(memberId, boatIndex, boatType, length);
                _member = registry.GetMemberById(memberId);
            }
            else
            {
                throw new Exception("You have entered an invalid type of boat.");
            }

            
        }

        public void SendToView(CLI cli)
        {
            cli.Display("Successfully updated boat.");
            cli.DisplayMember(_member);
        }
    }
}
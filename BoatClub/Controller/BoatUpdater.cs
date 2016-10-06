﻿using System;
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
            var memberId = args[0];
            var boatIndex = int.Parse(args[1]);
            var boatType = args[2];

            if (Enum.IsDefined(typeof(BoatType), boatType))
            {
                var length = float.Parse(args[3]);
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
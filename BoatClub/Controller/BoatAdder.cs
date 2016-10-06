using System;
using System.Collections.Generic;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class BoatAdder : ICommandHandler
    {
        private Member _member;
        public BoatAdder()
        {
        }

        public void RecieveFromM(List<string> args, MemberRegistry registry)
        {
            var memberId = args[0];
            var boatTypeInput = args[1];
            var lengthInMetresInput = args[2];
            var boat = CreateBoat(boatTypeInput, lengthInMetresInput);

            registry.AddBoat(memberId, boat);
            _member = registry.GetMemberById(memberId);

        }

        public void SendToV(CLI cli)
        {
            cli.Display("Successfully added boat.");
            cli.DisplayMember(_member);
        }

        private Boat CreateBoat(string boatTypeInput, string lengthInMetresInput)
        {
            if (Enum.IsDefined(typeof(BoatType), boatTypeInput))
            {
                double lengthInMetres;
                var boatType = (BoatType)Enum.Parse(typeof(BoatType), boatTypeInput);
                double.TryParse(lengthInMetresInput, out lengthInMetres);
                var boat = new Boat(boatType, lengthInMetres);

                return boat;
            }
            else
            {
                throw new Exception("You have entered an invalid type of boat."); // TODO showing path to exception.
            }

        }
    }
}
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
            var boat = CreateBoat(boatTypeInput, lengthInMetresInput);

            registry.AddBoat(memberId, boat);
            _member = registry.GetMemberById(memberId);
        }

        public void SendToView(CLI cli)
        {
            cli.Display("Successfully added boat.");
            cli.DisplayMember(_member);
        }

        private Boat CreateBoat(string boatTypeInput, string lengthInMetresInput)
        {
            if (Enum.IsDefined(typeof(BoatType), boatTypeInput))
            {
                double lengthInMetres;
                var boatType = (BoatType) Enum.Parse(typeof(BoatType), boatTypeInput);
                double.TryParse(lengthInMetresInput, out lengthInMetres);
                var boat = new Boat(boatType, lengthInMetres);

                return boat;
            }
            var listOfValidBoatTypes = "";
            var boatTypes = Enum.GetNames(typeof(BoatType));

            for (int i = 0; i < boatTypes.Length; i++)
            {
                listOfValidBoatTypes += boatTypes[i];

                if (i < boatTypes.Length - 1)
                {
                    listOfValidBoatTypes += ", ";
                }
            }
            throw new Exception($"You have entered an invalid type of boat. \nVaild boat types: {listOfValidBoatTypes}");
        }
    }
}
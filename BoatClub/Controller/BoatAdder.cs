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

        public void RecieveFromModel(List<string> args, MemberRegistry registry)
        {
            string memberId = args[0];
            string boatTypeInput = args[1];
            string lengthInMetresInput = args[2];
            Boat boat = CreateBoat(boatTypeInput, lengthInMetresInput);

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
                BoatType boatType = (BoatType)Enum.Parse(typeof(BoatType), boatTypeInput);
                double.TryParse(lengthInMetresInput, out lengthInMetres);
                Boat boat = new Boat(boatType, lengthInMetres);

                return boat;
            }
            else
            {
                string listOfValidBoatTypes = "";
                string[] boatTypes = Enum.GetNames(typeof(BoatType));

                for (int i = 0; i < boatTypes.Length; i++)
                {
                    listOfValidBoatTypes += boatTypes[i];

                    if (i < boatTypes.Length - 1)
                    {
                        listOfValidBoatTypes += ", ";
                    }
                }



                throw new Exception($"You have entered an invalid type of boat. \nVaild boat types: {listOfValidBoatTypes}"); // TODO showing path to exception.
            }

        }
    }
}
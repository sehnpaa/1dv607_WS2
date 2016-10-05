<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class Action
    {
        private readonly MemberRegistry _registry;
        private readonly CLI _cli;

        private string _command;
        private List<string> _args;

        private readonly Dictionary<string, int> _validNumberOfArgs = new Dictionary<string, int>
        {
            {"add-member", 2},
            {"update-member", 3},
            {"delete-member", 1},
            {"list-member", 1},
            {"list-members-VL", 0},
            {"list-members-CL", 0},
            {"add-boat", 3},
            {"update-boat", 4},
            {"remove-boat", 2},
            {"help", 0}
        };

        public Action(string input, MemberRegistry registry, CLI cli)
        {
            _registry = registry;
            _cli = cli;
            SetCommand(input);
            SetArgs(input);
        }

        public void Call()
        {
            try
            {
                if (_validNumberOfArgs[_command] != _args.Count)
                {
                    _cli.Display("Incorrect number of arguments");
                    return;
                }
                switch (_command)
                {
                    case "add-member":
                        AddMember();
                        break;
                    case "update-member":
                        UpdateMember();
                        break;
                    case "delete_member":
                        DeleteMember();
                        break;
                    case "list-member":
                        ListMember();
                        break;
                    case "add-boat":
                        AddBoat();
                        break;
                    case "update-boat":
                        UpdateBoat();
                        break;
                    case "remove-boat":
                        RemoveBoat();
                        break;
                    case "list-members-VL":
                        _cli.DisplayMemberListVerbose(_registry.GetMemberList());
                        break;
                    case "list-members-CL":
                        _cli.DisplayMemberListCompact(_registry.GetMemberList());
                        break;
                    case "help":
                        _cli.DisplayValidCommands();
                        break;
                    default:
                        break;
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Command is not supported. Write <help> to get list of commands.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddMember()
        {
            var name = _args[0];
            var personalNumber = _args[1];
            var member = new Member(name, personalNumber, _registry.GetNextMemberId());

            if (member.GetMemberAge() < 18)
            {
                Console.WriteLine("You must be of age 18 to become a member.");
            }
            else
            {
                _registry.SaveMember(member);
                _cli.DisplayMember(member);
            }
        }

        private void UpdateMember()
        {
            _registry.UpdateMember(_args[0], _args[1], _args[2]);
            _cli.DisplayMember(_registry.GetMemberById(_args[0]));
        }

        private void RemoveBoat()
        {
            var memberId = _args[0];
            var boatId = _args[1];
            _registry.RemoveBoat(memberId, boatId);
        }

        private void ListMember()
        {
            try
            {
                var id = _args[0];
                _cli.DisplayMember(_registry.GetMemberById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void DeleteMember()
        {
            try
            {
                string memberId = _args[0];
                Member deletedMember = _registry.DeleteMemberById(memberId);
                _cli.Display($"Member was successfully deleted.");
                _cli.DisplayMemberVerbose(deletedMember);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void AddBoat()
        {
            try
            {
                var boat = CreateBoat();
                var memberId = _args[0];
                _registry.AddBoat(memberId, boat);
                _cli.DisplayBoat(boat);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void UpdateBoat()
        {
            try
            {
                var memberId = _args[0];
                var boatIndex = int.Parse(_args[1]);
                var boatType = _args[2];
                var length = float.Parse(_args[3]);
                _registry.UpdateBoat(memberId, boatIndex, boatType, length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private Boat CreateBoat()
        {
            // TODO: Handle dots and comma input!
            //try
            //{
            var boatTypeInput = _args[1];
            var lengthInMetresInput = _args[2];
            double lengthInMetres;

            var boatType = (BoatType) Enum.Parse(typeof(BoatType), boatTypeInput);
            double.TryParse(lengthInMetresInput, out lengthInMetres);

            var boat = new Boat(boatType, lengthInMetres);

            return boat;
            //} catch (ArgumentException)
            //{
            //    throw new Exception($"Boat type '{_args[1]}' does not exist.");
            //}
        }

        private void SetCommand(string s)
        {
            _command = s.Trim().Split(' ').First();
        }

        private void SetArgs(string s)
        {
            _args = s.Trim().Split(' ').Skip(1).ToList();
        }
    }
}
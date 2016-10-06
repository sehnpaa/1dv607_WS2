using System;
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
            {"list-members-vl", 0},
            {"list-members-cl", 0},
            {"add-boat", 3},
            {"update-boat", 4},
            {"remove-boat", 2},
            {"clear", 0},
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
                    case "delete-member":
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
                    case "delete-boat":
                        Console.WriteLine("here in delete-boat");
                        DeleteBoat();
                        break;
                    case "list-members-vl":
                        ListMembersVL();
                        break;
                    case "list-members-cl":
                        ListMembersCL();
                        break;
                    case "help":
                        _cli.DisplayValidCommands();
                        break;
                    case "clear":
                        _cli.ClearConsole();
                        break;
                    default:
                        _cli.DisplayValidCommands();
                        break;
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Command is not supported. Write <help> to get list of commands.");
            }
            catch (ArgumentException e)
            {
                _cli.DisplayErrorMessage(e.Message);
            }
            catch (Exception e)
            {
                _cli.DisplayErrorMessage(e.Message);
            }
        }

        private void AddMember()
        {
            var name = _args[0];
            var personalNumber = _args[1];
            var member = new Member(name, personalNumber, _registry.GetNextMemberId());

            _registry.SaveMember(member);
            _cli.Display("Successfully added member.");
            _cli.DisplayMember(member);
        }

        private void ListMembersVL()
        {
            List<Member> memberList = _registry.GetMemberList();

            if (memberList.Count < 1)
            {
                _cli.DisplayErrorMessage("Could not display verbose member list. No members found.");
                return;
            }

            _cli.DisplayMemberListVerbose(memberList);
        }

        private void ListMembersCL()
        {
            List<Member> memberList = _registry.GetMemberList();

            if (memberList.Count < 1)
            {
                _cli.DisplayErrorMessage("Could not display compact member list. No members found.");
                return;
            }
            _cli.DisplayMemberListCompact(memberList);
        }


        private void UpdateMember()
        {
            _registry.UpdateMember(_args[0], _args[1], _args[2]);
            _cli.Display("Successfully updated member.");
            _cli.DisplayMember(_registry.GetMemberById(_args[0]));
        }

        private void DeleteBoat()
        {
            var memberId = _args[0];
            var boatIndex = int.Parse(_args[1]);

            _registry.DeleteBoat(memberId, boatIndex);
        }

        private void ListMember()
        {
            var id = _args[0];
            _cli.DisplayMember(_registry.GetMemberById(id));
        }

        private void DeleteMember()
        {
            var memberId = _args[0];
            var deletedMember = _registry.DeleteMemberById(memberId);
            _cli.Display($"Member was successfully deleted.");
            _cli.DisplayMemberVerbose(deletedMember);
        }

        private void AddBoat()
        {
            var boat = CreateBoat();
            var memberId = _args[0];
            _registry.AddBoat(memberId, boat);
            Member member = _registry.GetMemberById(memberId);
            _cli.Display("Successfully added boat.");
            _cli.DisplayMember(member);
        }

        private void UpdateBoat()
        {
            var memberId = _args[0];
            var boatIndex = int.Parse(_args[1]);
            var boatType = _args[2];

            if (Enum.IsDefined(typeof(BoatType), boatType))
            {
                var length = float.Parse(_args[3]);
                _registry.UpdateBoat(memberId, boatIndex, boatType, length);
            }
            else
            {
                throw new Exception("You have entered an invalid type of boat.");
            }
        }

        private Boat CreateBoat()
        {
            var boatTypeInput = _args[1];
            var lengthInMetresInput = _args[2];

            if (Enum.IsDefined(typeof(BoatType), boatTypeInput))
            {
                double lengthInMetres;
                var boatType = (BoatType) Enum.Parse(typeof(BoatType), boatTypeInput);
                double.TryParse(lengthInMetresInput, out lengthInMetres);
                var boat = new Boat(boatType, lengthInMetres);

                return boat;
            }
            else
            {
                throw new Exception("You have entered an invalid type of boat."); // TODO showing path to exception.
            }

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
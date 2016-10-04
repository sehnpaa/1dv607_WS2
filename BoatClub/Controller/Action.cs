using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    class Action
    {
        private readonly MemberRegistry _registry;
        private readonly CLI _cli;

        private string _command;
        private List<String> _args;

        private readonly Dictionary<string, int> _validNumberOfArgs = new Dictionary<string, int>()
        {
            {"create_member", 2},
            {"update_member", 3},
            {"delete_member", 1},
            {"info_member", 1},
            {"list_members_VL", 0},
            {"list_members_CL", 0},
            {"add_boat", 3},
            {"update_boat", 4},
            {"remove_boat", 2},
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
                    return;
                }
                switch (_command)
                {
                    case "create_member":
                        CreateMember();
                        break;
                    case "update_member":
                        _registry.UpdateMember(_args[0], _args[1], _args[2]);
                        _cli.DisplayMember(_registry.GetMemberById(_args[0]));
                        break;
                    case "delete_member":
                        _cli.Display(_registry.DeleteMemberById(_args[0]));
                        break;
                    case "list_members_VL":
                        _cli.DisplayMemberListVerbose(_registry.GetMemberList());
                        break;
                    case "list_members_CL":
                        _cli.DisplayMemberListCompact(_registry.GetMemberList());
                        break;
                    case "info_member":
                        string id = _args[0];
                        _cli.DisplayMember(_registry.GetMemberById(id));
                        break;
                    case "add_boat":
                        try
                        {
                            string memberId = _args[0];
                            string boatType = _args[1];
                            float length = float.Parse(_args[2]);
                            _registry.AddBoat(memberId, boatType, length);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case "update_boat":
                        try
                        {
                            string memberId = _args[0];
                            string boatId = _args[1];
                            string boatType = _args[2];
                            float length = float.Parse(_args[3]);
                            _registry.UpdateBoat(memberId, boatId, boatType, length);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case "remove_boat":
                        {
                            string memberId = _args[0];
                            string boatId = _args[1];
                            _registry.RemoveBoat(memberId, boatId);
                        }
                        break;
                    case "help":
                        _cli.DisplayListOfCommands(_validNumberOfArgs);
                        break;
                    default:
                        break;
                }
            } catch (KeyNotFoundException)
            {
                Console.WriteLine("Command is not supported. Write help to get list of commands.");
            } catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateMember()
        {
            try
            {
                string name = _args[0];
                string personalNumber = _args[1];

                Member member = new Member(name, personalNumber, _registry.GetNextMemberId());

                _registry.SaveMember(member);
                _cli.DisplayMember(member);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SetCommand(String s)
        {
            _command = s.Trim().Split(' ').First();
        }

        private void SetArgs(String s)
        {
            _args = s.Trim().Split(' ').Skip(1).ToList();
        }
    }
}
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
                ICommandHandler t;
                switch (_command)
                {
                    case "add-member":
                        t = new MemberAdder();
                        break;
                    case "update-member":
                        t = new MemberUpdater();
                        break;
                    case "delete-member":
                        t = new MemberDeleter();
                        break;
                    case "list-member":
                        t = new MemberLister();
                        break;
                    case "add-boat":
                        t = new BoatAdder();
                        break;
                    case "update-boat":
                        t = new BoatUpdater();
                        break;
                    case "remove-boat":
                        t = new BoatRemover();
                        break;
                    case "list-members-vl":
                        t = new MembersListerVerbose();
                        break;
                    case "list-members-cl":
                        t = new MembersListerCompact();
                        break;
                    case "help":
                        t = new Helper();
                        break;
                    case "clear":
                        t = new DisplayClearer();
                        break;
                    default:
                        t = new Helper();
                        break;
                }
                t.RecieveFromM(_args, _registry);
                t.SendToV(_cli);
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
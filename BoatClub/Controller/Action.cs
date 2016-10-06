using System;
using System.Collections.Generic;
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
            {"delete-boat", 2},
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
                ICommandHandler commandHandler;
                switch (_command)
                {
                    case "add-member":
                        commandHandler = new MemberAdder();
                        break;
                    case "update-member":
                        commandHandler = new MemberUpdater();
                        break;
                    case "delete-member":
                        commandHandler = new MemberDeleter();
                        break;
                    case "list-member":
                        commandHandler = new MemberLister();
                        break;
                    case "add-boat":
                        commandHandler = new BoatAdder();
                        break;
                    case "update-boat":
                        commandHandler = new BoatUpdater();
                        break;
                    case "delete-boat":
                        commandHandler = new BoatDeleter();
                        break;
                    case "list-members-vl":
                        commandHandler = new MembersListerVerbose();
                        break;
                    case "list-members-cl":
                        commandHandler = new MembersListerCompact();
                        break;
                    case "help":
                        commandHandler = new Helper();
                        break;
                    case "clear":
                        commandHandler = new DisplayClearer();
                        break;
                    default:
                        commandHandler = new Helper();
                        break;
                }
                commandHandler.RecieveFromModel(_args, _registry);
                commandHandler.SendToView(_cli);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Command '{_command}' is not supported. Write <help> to get list of valid commands.");
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
            var words = s.Trim().Split(' ');
            _command = words[0];
        }

        private void SetArgs(string s)
        {
            var words = s.Trim().Split(' ');
            var arguments = new List<string>();

            for (var i = 1; i < words.Length; i++)
            {
                arguments.Add(words[i]);
            }

            _args = arguments;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoatClub.Model;

namespace BoatClub.Controller
{
    class Action
    {
        private readonly MemberRegistry _registry;

        private string _command;
        private List<String> _args;

        private readonly Dictionary<string, int> _validNumberOfArgs = new Dictionary<string, int>()
        {
            {"create_member", 1}
        };

        public Action(string input, MemberRegistry registry)
        {
            _registry = registry;
            SetCommand(input);
            SetArgs(input);
        }

        public void Call()
        {
            switch (_command)
            {
                case "create_member":
                    if (_validNumberOfArgs[_command] == _args.Count)
                    {
                        _registry.Register(_args[0]);
                    }
                    break;
                default:
                    break;
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

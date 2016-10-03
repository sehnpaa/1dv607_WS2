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
            {"create_member", 2}
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
            if (_validNumberOfArgs[_command] != _args.Count)
            {
                return;
            }
            switch (_command)
            {
                case "create_member":
                    try
                    {
                        string name = _args[0];
                        string personalNumber = _args[1];

                        // TODO get ID and send in argument to new member!
                        Member member = new Member(name, personalNumber, _registry.GetNextMemberId());

                        _registry.SaveMember(member);

                        _cli.update(member.ToString());
                    } catch (Exception e)
                    {
                        Console.WriteLine(e);
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

﻿using System;
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
            {"info_member", 1},
            {"list_members_VL", 0},
            {"list_members_CL", 0}
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

                        Member member = new Member(name, personalNumber, _registry.GetNextMemberId());

                        _registry.SaveMember(member);

                        _cli.DisplayMember(member);
                    } catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
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

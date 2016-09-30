using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoatClub.Model;

namespace BoatClub.Controller
{
    class Action
    {
        private readonly string _input;
        private readonly MemberRegistry _registry;

        public Action(string input, MemberRegistry registry)
        {
            _input = input;
            _registry = registry;
        }

        public void Call()
        {
            _registry.Register(_input);
        }
    }
}

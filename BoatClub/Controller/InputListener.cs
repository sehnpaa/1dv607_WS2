using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    class InputListener
    {
        private readonly CLI _cli;
        private readonly MemberRegistry _registry;

        public InputListener(MemberRegistry registry, CLI cli)
        {
            this._registry = registry;
            this._cli = cli;
        }

        public void TakeInput()
        {
            while (true)
            {
                Console.WriteLine("Gör ditt val: ");
                var input = Console.ReadLine();
                var action = new Action(input, _registry);
                action.Call();
                _cli.update();
            }
        }
    }
}

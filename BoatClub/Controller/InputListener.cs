using System;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub.Controller
{
    internal class InputListener
    {
        private readonly CLI _cli;
        private readonly MemberRegistry _registry;

        public InputListener(MemberRegistry registry, CLI cli)
        {
            _registry = registry;
            _cli = cli;
        }

        public void TakeInput()
        {
            while (true)
            {
                Console.Write("\n>> ");
                string input = Console.ReadLine();
                Action action = new Action(input, _registry, _cli);
                action.Call();
            }
        }
    }
}

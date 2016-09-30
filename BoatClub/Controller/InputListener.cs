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
        private CLI cli;
        private MemberRegistry registry;

        public InputListener(MemberRegistry registry, CLI cli)
        {
            this.registry = registry;
            this.cli = cli;
        }

        public void takeInput()
        {
            String input;
            while (true)
            {
                Console.WriteLine("Gör ditt val: ");
                input = Console.ReadLine();
                registry.Register(input);
                cli.update();
            }
        }
    }
}

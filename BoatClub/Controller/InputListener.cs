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
        public static void takeInput(MemberRegistry model, CLI view)
        {
            String input;
            while (true)
            {
                Console.WriteLine("Gör ditt val: ");
                input = Console.ReadLine();
                model.register(input);
                view.update();
            }
        }
    }
}

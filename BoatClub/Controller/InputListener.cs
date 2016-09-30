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
            var input = System.Console.ReadLine();
            view.update();
            
            
        }
    }
}

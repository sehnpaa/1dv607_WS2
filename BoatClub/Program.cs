using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BoatClub.Controller;
using BoatClub.Model;

using BoatClub.View;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            //var member = new Member("Test", "1234567890");
            //Console.WriteLine(member.ToString());

            var registry = new MemberRegistry();
            var cli = new CLI(registry);
            var inputListener = new InputListener(registry, cli);
            inputListener.TakeInput();
        }
    }
}

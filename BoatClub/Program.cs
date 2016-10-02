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
            // TODO: Get rid of when live. Testing purposes.
            //try
            //{
            //    // PersonalNumber of format: yyMMdd" or "yyyyMMdd:
            //    var testMember = new Member("Ulrica Skarin", "19720623-0000");
            //    testMember.AddBoat(new Boat(BoatType.KayakOrCanoe, 1500));
            //    testMember.AddBoat(new Boat(BoatType.MotorSailer, 2500));
            //    Console.WriteLine(testMember.ToString());
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            var registry = new MemberRegistry();
            var cli = new CLI(registry);
            var inputListener = new InputListener(registry, cli);
            inputListener.TakeInput();
        }
    }
}

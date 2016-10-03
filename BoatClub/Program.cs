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
            try
            {
                var registry = new MemberRegistry();
                var cli = new CLI(registry);
                var inputListener = new InputListener(registry, cli);
                inputListener.TakeInput();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sorry! An error occurred: {e}");
            }
        }
    }
}
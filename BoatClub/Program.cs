using System;
using BoatClub.Controller;
using BoatClub.Model;
using BoatClub.View;

namespace BoatClub
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                MemberRegistry registry = new MemberRegistry();
                CLI cli = new CLI();
                InputListener inputListener = new InputListener(registry, cli);
                inputListener.TakeInput();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sorry! An error occurred: {e}");
            }
        }
    }
}
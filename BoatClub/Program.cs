﻿using System;
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
                var registry = new MemberRegistry();
                var cli = new CLI();
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
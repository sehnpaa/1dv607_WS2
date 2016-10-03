using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BoatClub.Model;

namespace BoatClub.View
{
    class CLI
    {
        private MemberRegistry model;

        public CLI(MemberRegistry model)
        {
            // TODO: Complete member initialization
            this.model = model;
            DisplayApplicationHeader();
        }
        public void update()
        {
            Console.WriteLine("vy uppdatering: " + model.GetMembersVl());
        }

        private void DisplayApplicationHeader()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Boat Club Version[1.0.0]");
            Console.WriteLine("2016 C. Trosell, P. Andersson, U. Skarin\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("Examples of valid commands:");
            Console.WriteLine("create_member Sven 550101-0000");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

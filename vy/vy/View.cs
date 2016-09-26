using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vy
{
    class View
    {
        private Model model;
        private Action action;

        public View(Model model)
        {
            this.model = model;
            this.action = new Action();
        }
        public void Loop()
        {
            while (true) {
                Console.WriteLine("Gör ditt val:");
                var input = Console.ReadLine();
                if (this.action.IsValid(input))
                {
                    this.action.Call(this.model);
                }
                else
                {
                    Console.WriteLine("Invalid!");
                }
            }
        }
    }
}

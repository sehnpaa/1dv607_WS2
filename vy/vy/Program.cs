using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vy
{
    class Program
    {

        static void Main(string[] args)
        {
            var model = new Model();
            var view = new View(model);
            view.Loop();
        }
    }
}

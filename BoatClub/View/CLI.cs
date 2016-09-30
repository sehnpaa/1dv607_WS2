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
        }
        public void update()
        {
            Console.WriteLine("vy uppdatering: " + model.GetMembersVl());
        }
    }
}

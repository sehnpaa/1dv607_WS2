using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vy
{
    class Validator
    {
        public Boolean isValid(String input)
        {
            return true;
        }

        public bool create_member(Array args)
        {
            return args.Length == 2;
        }

        public bool list_member_cl(Array args)
        {
            return args.Length == 0;
        }

        public bool list_member_vl(Array args)
        {
            return args.Length == 0;
        }

        public bool delete_member(Array args)
        {
            return args.Length == 1;
        }
    }
}

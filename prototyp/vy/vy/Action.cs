using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vy
{
    class Action
    {
        private Validator validator;
        private string command;
        private Array args;

        public Action()
        {
            this.validator = new Validator();
        }
        public bool IsValid(String input)
        {
            this.command = GetCommand(input);
            this.args = GetArgs(input);
            switch (this.command)
            {
                case "create_member":
                    return this.validator.create_member(args);
                case "list_member_cl":
                    return this.validator.list_member_cl(args);
                case "list_member_vl":
                    return this.validator.list_member_vl(args);
                case "delete_member":
                    return this.validator.delete_member(args);
                default:
                    return false;
            }
        }

        public void Call(Model model)
        {
            switch (this.command)
            {
                case "create_member":
                    model.CreateMember();
                    break;
                case "list_member_cl":
                    model.ListMembersCL();
                    break;
                case "list_member_vl":
                    model.ListMembersVL();
                    break;
                case "delete_member":
                    model.DeleteMember();
                    break;
            }
        }
        private String GetCommand(String s)
        {
            return s.Trim().Split(' ').First();
        }
        private Array GetArgs(String s)
        {
            return s.Trim().Split(' ').Skip(1).ToArray();
        }
    }
}

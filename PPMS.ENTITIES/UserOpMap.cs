using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMS.ENTITIES
{
    public class UserOpMap
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string UserID { get; set; }
        public string UserRoleName { get; set; }
        public List<Operations> OperationsList { get; set; }

    }
    public class Operations
    {
        public string OperationName { get; set; }
    }
}

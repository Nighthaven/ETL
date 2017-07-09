using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessObjects
{
    public class AuthentificationToken : IAuthentificationToken
    {
        public string Value { get; set; }
        public int FleetOwnerID { get; set; }
    }
}

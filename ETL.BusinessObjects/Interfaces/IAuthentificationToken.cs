using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.BusinessObjects
{
    public interface IAuthentificationToken
    {
        string Value { get; set; }
        int FleetOwnerID { get; set; }
    }
}

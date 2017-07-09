using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessObjects;

namespace ETL.ServicesWeb.Services.Interfaces
{
    public interface IAuthentificationService
    {
        IAuthentificationToken Login(string pUsername, string pPassword);
    }
}

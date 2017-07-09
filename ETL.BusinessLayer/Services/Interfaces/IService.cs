using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessLayer.Events;

namespace ETL.BusinessLayer.Services.Interfaces
{
    public interface IService : IDisposable
    {
        event ErrorEventHandler ErrorOccured;
    }
}

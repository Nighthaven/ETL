using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessLayer.Events;
using ETL.BusinessLayer.Services.Interfaces;

namespace ETL.BusinessLayer.Services
{
    public abstract class Service : IService
    {
        protected bool _disposed;
        public event ErrorEventHandler ErrorOccured;

        public abstract void Dispose();

        protected bool CheckIsDisposed()
        {
            if (!_disposed) return false;

            if (ErrorOccured != null)
                ErrorOccured(this, new ErrorEventArgs() { Message = "Service est disposé." });

            return true;
        }

        protected void UnsubscribeEvents()
        {
            if (ErrorOccured != null)
                foreach (var d in ErrorOccured.GetInvocationList())
                    ErrorOccured -= (d as ErrorEventHandler);
        }
    }
}

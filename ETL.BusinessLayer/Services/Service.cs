using ETL.BusinessLayer.Events;
using ETL.BusinessLayer.Services.Interfaces;

namespace ETL.BusinessLayer.Services
{
    public abstract class Service : IService
    {
        #region Events

        #region Implemented

        public event ErrorEventHandler ErrorOccured;

        #endregion

        #endregion

        #region Fields

        protected bool _disposed;

        #endregion

        #region Methods

        #region Implemented
        
        public abstract void Dispose();

        #endregion
        
        protected bool CheckIsDisposed()
        {
            if (!_disposed) return false;

            if (ErrorOccured != null)
                ErrorOccured(this, new ErrorEventArgs() { Message = "Service est disposé." });

            return true;
        }

        protected void SendError(string pMessage)
        {
            if (ErrorOccured != null)
                ErrorOccured(this, new ErrorEventArgs() { Message = pMessage });
        }

        protected void UnsubscribeEvents()
        {
            if (ErrorOccured != null)
            {
                foreach (var delegateMethod in ErrorOccured.GetInvocationList())
                {
                    ErrorOccured -= (delegateMethod as ErrorEventHandler);
                }
            }
        }

        #endregion
    }
}

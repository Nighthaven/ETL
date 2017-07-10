using System;
using ETL.BusinessLayer.Events;

namespace ETL.BusinessLayer.Services.Interfaces
{
    public interface IService : IDisposable
    {
        #region Events

        event ErrorEventHandler ErrorOccured;

        #endregion
    }
}

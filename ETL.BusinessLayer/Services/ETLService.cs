using System;
using System.Collections.Generic;
using System.Linq;
using ETL.BusinessLayer.Services.Interfaces;
using ETL.BusinessObjects;
using ETL.ServicesWeb.Services.Interfaces;

namespace ETL.BusinessLayer.Services
{
    internal class ETLService : Service, IETLService
    {
        #region Fields

        private IAuthentificationService _authentificationService;
        private IStaticService _staticService;
        private IEventService _eventService;

        #endregion

        #region Constructors

        internal ETLService(IAuthentificationService pAuthentificationService, IStaticService pStaticService, IEventService pEventService)
        {
            if (pAuthentificationService == null) throw new ArgumentNullException("pAuthentificationService");
            if (pStaticService == null) throw new ArgumentNullException("pStaticService");
            if (pEventService == null) throw new ArgumentNullException("pEventService");

            _authentificationService = pAuthentificationService;
            _staticService = pStaticService;
            _eventService = pEventService;
        }

        #endregion

        #region Methods

        #region Implemented

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IAuthentificationToken Login(string pUsername, string pPassword)
        {
            if (CheckIsDisposed()) return null;

            try
            {
                return _authentificationService.Login(pUsername, pPassword);
            }
            catch (Exception exception)
            {
                SendError(exception.Message);
                return null;
            }
        }

        public IEnumerable<IPosition> GetPositions(IAuthentificationToken pToken, IVehicule pVehicule)
        {
            if (CheckIsDisposed()) return null;

            try
            {
                return _eventService.GetPositionsForToday(pToken, pVehicule);
            }
            catch (Exception exception)
            {
                SendError(exception.Message);
                return Enumerable.Empty<IPosition>();
            }
        }

        public IEnumerable<IVehicule> GetVehicules(IAuthentificationToken pToken)
        {
            if (CheckIsDisposed()) return null;

            try
            {
                return _staticService.GetVehicules(pToken);
            }
            catch (Exception exception)
            {
                SendError(exception.Message);
                return Enumerable.Empty<IVehicule>();
            }
        }

        public void CloseSession(IAuthentificationToken pToken)
        {
            if (pToken == null) throw new ArgumentNullException("pToken");
            if (CheckIsDisposed()) return;

            try
            {
                _authentificationService.Close(pToken);
            }
            catch (Exception exception)
            {
                SendError(exception.Message);
            }
        }

        #endregion

        private void Dispose(bool pDispose)
        {
            if (_disposed) return;

            if (pDispose)
            {
                _authentificationService = null;
                _staticService = null;
                UnsubscribeEvents();
            }

            _disposed = true;
        }

        #endregion
    }
}

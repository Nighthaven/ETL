using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL.BusinessLayer.Events;
using ETL.BusinessLayer.Services.Interfaces;
using ETL.BusinessObjects;
using ETL.ServicesWeb.Services.Interfaces;

namespace ETL.BusinessLayer.Services
{
    internal class ETLService : Service, IETLService
    {
        private IAuthentificationService _authentificationService;

        internal ETLService(IAuthentificationService pAuthentificationService)
        {
            if (pAuthentificationService == null) throw new ArgumentNullException("pAuthentificationService");

            _authentificationService = pAuthentificationService;
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool pDispose)
        {
            if (_disposed)
                return;

            if (pDispose)
            {
                _authentificationService = null;
                UnsubscribeEvents();
            }
            
            _disposed = true;
        }
        
        public IAuthentificationToken Login(string pUsername, string pPassword)
        {
            if (CheckIsDisposed()) return null;

            return _authentificationService.Login(pUsername, pPassword);
        }
    }
}

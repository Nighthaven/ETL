using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ETL.BusinessObjects;
using ETL.BusinessLayer;
using ETL.BusinessLayer.Events;
using ETL.Prototype.Utilitaires;

namespace ETL.Prototype.ViewModels
{
    public class VehiculePositionViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event ErrorEventHandler ErrorOccured;

        private IAuthentificationToken _token;

        public VehiculePositionViewViewModel()
        {
            var username = ConfigUtils.ReadSetting(Configs.CourrielETL);
            var password = ConfigUtils.ReadSetting(Configs.PasswordETL);

            using (var service = ServiceFactories.CreateETLService())
            {
                service.ErrorOccured += OnErrorOccured;
                _token = service.Login(username, password);
            }
        }
        
        public void OnErrorOccured(object sender, ErrorEventArgs eventArgs)
        {
            if (ErrorOccured != null)
                ErrorOccured(sender, eventArgs);
        }
    }
}

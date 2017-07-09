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
using System.Windows.Input;

namespace ETL.Prototype.ViewModels
{
    public class VehiculePositionViewViewModel : ViewModelBase
    {
        public event ErrorEventHandler ErrorOccured;

        private string _username;
        private string _password;
        private IAuthentificationToken _token;

        public string Username
        {
            get { return _username; }
            set { SetField(ref _username, value); }
        }

        public bool IsConnected
        {
            get { return Token != null; }
        }

        public string Password
        {
            get { return _password; }
            set { SetField(ref _password, value); }
        }
        
        public IAuthentificationToken Token
        {
            get { return _token; }
            set
            {
                SetField(ref _token, value);
                TokenChanged();
            }
        }

        public void Closing()
        {
            if (Token == null) return;
            
            using (var service = ServiceFactories.CreateETLService())
            {
                service.ErrorOccured += OnErrorOccured;
                service.CloseSession(Token);
            }
        }

        public VehiculePositionViewViewModel()
        {
            Username = ConfigUtils.ReadSetting(Configs.CourrielETL);
            Password = ConfigUtils.ReadSetting(Configs.PasswordETL);

            PrepareCommands();
            FillViewModel();
        }

        private void PrepareCommands()
        {
            ConnectCommand = new RelayCommand<Action>(ConnectCommandMethod);
        }

        private void ConnectCommandMethod(object sender)
        {
            LoginToETL();
        }

        private void TokenChanged()
        {
            NotifyPropertyChanged(GetPropertyName(() => IsConnected));                 
        }

        private void FillViewModel()
        {
            LoginToETL();
        }

        private void LoginToETL()
        {
            using (var service = ServiceFactories.CreateETLService())
            {
                service.ErrorOccured += OnErrorOccured;
                Token = service.Login(Username, Password);
            }
        }
        
        public void OnErrorOccured(object sender, ErrorEventArgs eventArgs)
        {
            if (ErrorOccured != null)
                ErrorOccured(sender, eventArgs);
        }

        public ICommand ConnectCommand { get; set; }
    }
}

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
using System.Collections.ObjectModel;
using ETL.Prototype.Events;

namespace ETL.Prototype.ViewModels
{
    public class VehiculePositionViewViewModel : ViewModelBase
    {
        public event ErrorEventHandler ErrorOccured;
        public event NavigateEventHandler NavigateRequested;
        public event EventHandler ClearLocationRequested;

        private string _username;
        private string _password;
        private IAuthentificationToken _token;

        private ObservableCollection<VehiculeViewModel> _vehicules;
        public ObservableCollection<VehiculeViewModel> Vehicules
        {
            get { return _vehicules; }
            private set { SetField(ref _vehicules, value); }
        }
                
        private VehiculeViewModel _selectedVehicule;
        public VehiculeViewModel SelectedVehicule
        {
            get { return _selectedVehicule; }
            set
            {
                SetField(ref _selectedVehicule, value);
                SelectedVehiculeChanged();
            }
        }

        private ObservableCollection<PositionViewModel> _positions;
        public ObservableCollection<PositionViewModel> Positions
        {
            get { return _positions; }
            private set { SetField(ref _positions, value); }
        }

        private PositionViewModel _selectedPosition;
        public PositionViewModel SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                SetField(ref _selectedPosition, value);
                SelectedPositionChanged();
            }
        }

        public string Username
        {
            get { return _username; }
            set { SetField(ref _username, value); }
        }

        public bool CanRefresh
        {
            get { return IsConnected; }
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
            Vehicules = new ObservableCollection<VehiculeViewModel>();
            Positions = new ObservableCollection<PositionViewModel>();
            Username = ConfigUtils.ReadSetting(Configs.CourrielETL);
            Password = ConfigUtils.ReadSetting(Configs.PasswordETL);

            PrepareCommands();
            FillViewModel();
        }

        private void SelectedPositionChanged()
        {
            if (SelectedPosition == null)
            {
                if (ClearLocationRequested != null)
                    ClearLocationRequested(this, EventArgs.Empty);
            }
            else
            { 
                if (NavigateRequested != null)
                    NavigateRequested(SelectedPosition.Latitude, SelectedPosition.Longitude);
            }
        }

        private void SelectedVehiculeChanged()
        {
            FillPositions();
        }

        private void FillPositions()
        {
            SelectedPosition = null;
            Positions.Clear();

            if (!IsConnected || SelectedVehicule == null) return;

            var positions = Enumerable.Empty<IPosition>();
            using (var service = ServiceFactories.CreateETLService())
            {
                service.ErrorOccured += OnErrorOccured;
                positions = service.GetPositions(Token, SelectedVehicule.Data);
            }

            if (positions == null) return;
            foreach (var position in positions)
            {
                Positions.Add(new PositionViewModel(position));
            }
        }

        private void PrepareCommands()
        {
            ConnectCommand = new RelayCommand(ConnectCommandMethod);
            RefreshCommand = new RelayCommand(RefreshCommandMethod, param => CanRefresh);
        }

        private void RefreshCommandMethod(object sender)
        {
            var vehiculeID = SelectedVehicule == null ? (int?)null : SelectedVehicule.ID;
            

            FillVehicules();

            if (vehiculeID.HasValue)
                SelectedVehicule = Vehicules.FirstOrDefault(x => x.ID == vehiculeID.Value) ?? Vehicules.FirstOrDefault();
        }

        private void FillVehicules()
        {
            SelectedVehicule = null;
            Vehicules.Clear();

            if (!IsConnected) return;

            var vehicules = Enumerable.Empty<IVehicule>();
            using (var service = ServiceFactories.CreateETLService())
            {
                service.ErrorOccured += OnErrorOccured;
                vehicules = service.GetVehicules(Token);
            }

            if (vehicules == null) return;
            foreach(var vehicule in vehicules)
            {
                Vehicules.Add(new VehiculeViewModel(vehicule));
            }
        }

        private void ConnectCommandMethod(object sender)
        {
            Closing();
            LoginToETL();
        }

        private void TokenChanged()
        {
            NotifyPropertyChanged(GetPropertyName(() => IsConnected));
            NotifyPropertyChanged(GetPropertyName(() => CanRefresh));
            RefreshCommand.Execute(this);
        }

        private void FillViewModel()
        {
            LoginToETL();
            FillVehicules();

            SelectedVehicule = Vehicules.FirstOrDefault();
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
        public ICommand RefreshCommand { get; set; }
    }
}

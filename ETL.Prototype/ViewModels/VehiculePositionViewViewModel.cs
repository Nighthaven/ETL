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

namespace ETL.Prototype.ViewModels
{
    public class VehiculePositionViewViewModel : ViewModelBase
    {
        public event ErrorEventHandler ErrorOccured;

        private string _username;
        private string _password;
        private IAuthentificationToken _token;
        private readonly List<PositionVehiculeViewModel> _allPositions;

        private ObservableCollection<VehiculeViewModel> _vehicules;
        public ObservableCollection<VehiculeViewModel> Vehicules
        {
            get { return _vehicules; }
            private set { SetField(ref _vehicules, value); }
        }

        private ObservableCollection<PositionVehiculeViewModel> _positions;
        public ObservableCollection<PositionVehiculeViewModel> Positions
        {
            get { return _positions; }
            private set { SetField(ref _positions, value); }
        }

        private PositionVehiculeViewModel _selectedPosition;
        public PositionVehiculeViewModel SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                SetField(ref _selectedPosition, value);
                SelectedPositionChanged();
            } 
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
            _allPositions = new List<PositionVehiculeViewModel>();
            Positions = new ObservableCollection<PositionVehiculeViewModel>();
            Vehicules = new ObservableCollection<VehiculeViewModel>();
            Username = ConfigUtils.ReadSetting(Configs.CourrielETL);
            Password = ConfigUtils.ReadSetting(Configs.PasswordETL);

            PrepareCommands();
            FillViewModel();
        }

        private void PrepareCommands()
        {
            ConnectCommand = new RelayCommand(ConnectCommandMethod);
            RefreshCommand = new RelayCommand(RefreshCommandMethod, param => CanRefresh);
        }

        private void RefreshCommandMethod(object sender)
        {
            GetPositions();
        }

        private void SelectedPositionChanged()
        {
        }

        private void SelectedVehiculeChanged()
        {
            FillPositions();
        }

        private void FillVehicules()
        {
            SelectedVehicule = null;
            Vehicules.Clear();

            if (!_allPositions.Any()) return;

            var vehiculesIDs = _allPositions.Select(x => x.VehiculeID).Distinct().ToList();

            foreach(var vehiculeID in vehiculesIDs)
            {
                if (Vehicules.Any(x => x.ID == vehiculeID)) continue;
                var firstVehiculeWithSameID = _allPositions.FirstOrDefault(x => x.VehiculeID == vehiculeID);
                if (firstVehiculeWithSameID == null) continue;

                Vehicules.Add(firstVehiculeWithSameID.Vehicule);
            }
        }

        private void ConnectCommandMethod(object sender)
        {
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
            GetPositions();
        }

        private void GetPositions()
        {
            var positionEventID = SelectedPosition == null ? (long?)null : SelectedPosition.EventID;
            var vehiculeID = SelectedVehicule == null ? (int?)null : SelectedVehicule.ID;

            _allPositions.Clear();

            if (!IsConnected) return;

            var positions = Enumerable.Empty<IPositionVehicule>();
            using (var service = ServiceFactories.CreateETLService())
            {
                service.ErrorOccured += OnErrorOccured;
                positions = service.GetPositions(Token);
            }

            _allPositions.AddRange(positions.Select(x => new PositionVehiculeViewModel(x)));
            FillVehicules();
            FillPositions();

            if (vehiculeID.HasValue)
                SelectedVehicule = Vehicules.FirstOrDefault(x => x.ID == vehiculeID.Value);

            if (positionEventID.HasValue)
                SelectedPosition = Positions.FirstOrDefault(x => x.EventID == positionEventID.Value);
        }

        private void FillPositions()
        {
            SelectedPosition = null;
            Positions.Clear();
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

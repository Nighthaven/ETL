using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ETL.Prototype.ViewModels;

namespace ETL.Prototype.Views
{
    /// <summary>
    /// Logique d'interaction pour VehiculesPositionView.xaml
    /// </summary>
    public partial class VehiculesPositionView : Window
    {
        private VehiculePositionViewViewModel ViewModel { get; set; }

        public VehiculesPositionView()
        {
            InitializeComponent();

            ViewModel = new VehiculePositionViewViewModel();

            BindViewModel();

            DataContext = ViewModel;
        }

        private void BindViewModel()
        {
            ViewModel.ErrorOccured += ViewModel_ErrorOccured;
        }

        private void ViewModel_ErrorOccured(object sender, BusinessLayer.Events.ErrorEventArgs pEventArgs)
        {
            MessageBox.Show(this, pEventArgs.Message, "Erreur!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.Closing();
        }
    }
}

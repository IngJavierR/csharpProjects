using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace MvvmLigthTestWpf.ViewModel
{
    class CaptureViewModel : ViewModelBase
    {
        public CaptureViewModel()
        {

        }

        #region Command

        private RelayCommand showMessageCommand;
        public RelayCommand ShowMessageCommand
        {
            get { return showMessageCommand ?? (showMessageCommand = new RelayCommand(ShowMessage, () => true)); }
        }
        
        #endregion

        #region Methods
        private void ShowMessage()
        {
            MessageBox.Show("Prueba2");
        }
        #endregion Methods
    }
}

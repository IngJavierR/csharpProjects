using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;
using MvvmLigthTestWpf.View;

namespace MvvmLigthTestWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private IDialogService dialogService;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        #region Command

        private RelayCommand nextCommand;
        public RelayCommand NextCommand
        {
            get { return nextCommand ?? (nextCommand = new RelayCommand(CallNext, () => true)); }
        }

        #endregion Command

        #region Methods
        private void CallNext()
        {
            CaptureViewModel captureViewModel = new CaptureViewModel();
            CaptureView view = new CaptureView();
            view.DataContext = captureViewModel;
            view.Show();

        }

        #endregion

    }
}
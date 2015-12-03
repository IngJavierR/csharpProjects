using MahApps.Metro.Controls;
using MvcWpfPractice.Controllers;
using MvcWpfPractice.Model;

namespace MvcWpfPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //Controller
        WindowController _windowController;
        public MainWindow()
        {
            InitializeComponent();

            GetEmployees employees = GetEmployees.LoadEmployees();

            _windowController = new WindowController(this, employees);

            base.DataContext = employees;
        }
    }
}

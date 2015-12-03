using System;
using System.ComponentModel;
using System.Windows.Data;
using MvcWpfPractice.Model;

namespace MvcWpfPractice.Controllers
{
    class WindowController
    {
        private ICollectionView _collectionView;
        private MainWindow _mainWindow;

        public WindowController(MainWindow mainWindow, GetEmployees employees)
        {
            if (mainWindow == null)
                throw new ArgumentNullException(nameof(mainWindow));
            if (employees == null)
                throw new ArgumentNullException(nameof(employees));

            _mainWindow = mainWindow;

            //View And model
            _collectionView = CollectionViewSource.GetDefaultView(employees);

        }
    }
}

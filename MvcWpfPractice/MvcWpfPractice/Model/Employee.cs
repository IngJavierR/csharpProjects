using System;
using System.ComponentModel;

namespace MvcWpfPractice.Model
{
    public class Employee : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Inscripcion{ get; set; }
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System.Windows.Input;

namespace MvcWpfPractice
{
    public static class Command
    {
        public static readonly RoutedUICommand ShowSelectedEmployee;

        static Command()
        {
            ShowSelectedEmployee = new RoutedUICommand()
        }
    }
}

using System;
using System.Reflection;
using Ninject;

namespace NinjectPractice
{
    class Program
    {
        static void Main()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IMailSender mailSender = kernel.Get<IMailSender>();

            FormHandler form = new FormHandler(mailSender);
            form.Handle("hazeapd@gmail.com");

            Console.Read();
        }
    }
}

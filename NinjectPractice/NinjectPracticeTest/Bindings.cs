using Ninject.Modules;
using NinjectPractice;

namespace NinjectPracticeTest
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMailSender>().To<MockMailSender>();
        }
    }
}

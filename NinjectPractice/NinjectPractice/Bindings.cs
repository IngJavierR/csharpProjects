using Ninject.Modules;

namespace NinjectPractice
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMailSender>().To<MailSender>();
        }
    }
}

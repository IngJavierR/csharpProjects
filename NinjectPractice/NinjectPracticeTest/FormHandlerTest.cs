using System.Reflection;
using Ninject;
using NinjectPractice;
using NUnit.Framework;

namespace NinjectPracticeTest
{
    [TestFixture]
    public class FormHandlerTest
    {
        private IKernel _kernel;
        private IMailSender _mailSender;

        [SetUp]
        public void SetUp()
        {
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            _mailSender = _kernel.Get<IMailSender>();
        }

        [Test]
        public void EnviaMail()
        {
            FormHandler form = new FormHandler(_mailSender);
            form.Handle("hazelapd@gmail.com");
        }
    }
}

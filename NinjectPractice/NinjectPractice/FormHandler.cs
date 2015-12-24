namespace NinjectPractice
{
    public class FormHandler
    {
        private readonly IMailSender _mailSender;

        public FormHandler(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public void Handle(string toAddress)
        {
            _mailSender.Send(toAddress, "This is Non-Inject");
        }
    }
}

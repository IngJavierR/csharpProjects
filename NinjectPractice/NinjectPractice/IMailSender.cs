namespace NinjectPractice
{
    public interface IMailSender
    {
        void Send(string toAddress, string subject);
    }
}

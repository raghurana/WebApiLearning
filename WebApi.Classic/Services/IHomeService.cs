namespace WebApi.Classic.Services
{
    public interface IHomeService
    {
        string Greetings();
    }

    public class HelloWorldHomeService : IHomeService
    {
        public string Greetings()
        {
            return "Hello World";
        }
    }
}
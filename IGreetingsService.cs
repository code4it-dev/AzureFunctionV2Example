namespace AzureFunctionV2Example
{
    public interface IGreetingsService
    {
        string SayHi(string name);
    }

    public class GreetingsService : IGreetingsService
    {
        public string SayHi(string name)
        {
            return $"Hi, {name}! Pleased to meet you!";
        }
    }

}

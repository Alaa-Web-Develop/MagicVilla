namespace MagicVillaApi.Logging
{
    public class LoggerMyOwn : ILoggerMyOwn
    {
        public void Log(string Message, string Type)
        {
           if(Type == "error")
            {
                Console.WriteLine("Error _ "+Message);
            }
            else
            {
                Console.WriteLine(Message);

            }
        }
    }
}

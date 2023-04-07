namespace BotTry
{
    public static class Program
    {
        public static void Main()
        {
            try
            {

                var bot = new BasicBot(Constants.AccessToken);
                bot.GetBotGreeting();
                bot.ReceiveMessage();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
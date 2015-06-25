
namespace _01Logger
{
    using _01Logger.Appenders;
    using _01Logger.Formatters;

    class LoggerTest
    {
        static void Main(string[] args)
        {
            var simpleFormatter = new SimpleFormatter();
            var xmlFormatter = new XmlFormatter();
            var jsonFormatter = new JSONFormatter();
            var consoleAppender = new ConsoleAppender(xmlFormatter);
            var fileAppender = new FileAppender(xmlFormatter,"log.txt");
            Logger logger = new Logger(consoleAppender,fileAppender);

            logger.Critical("Out of memory!");
            logger.Info("Unused local variable 'name'");

            fileAppender.Close();
        }
    }
}

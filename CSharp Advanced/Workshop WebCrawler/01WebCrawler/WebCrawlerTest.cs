using System;

namespace WebCrawler
{
    using System.Threading.Tasks;

    class Program
    {
        private static Crawler crawler;

        public static void Main(string[] args)
        {
            crawler = new Crawler();
            while (true)
            {
                string url = Console.ReadLine();
                RunCrawl(url);
            }
        }

        private static async void RunCrawl(string url)
        {
            await Task.Run(
                () =>
                {
                    crawler.Crawl(url, 0, 0);
                });
            Console.WriteLine("{0} has been crawled!", url);
        }
    }
}

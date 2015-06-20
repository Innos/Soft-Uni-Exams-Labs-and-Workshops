namespace WebCrawler
{
    #region

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    #endregion

    public class Crawler
    {
        private const string DownloadDirectory = "Pics";

        private readonly ConcurrentBag<string> downloadedImages;

        private readonly ConcurrentBag<string> visitedSites;

        private readonly HtmlParser htmlParser;

        public Crawler()
        {
            this.htmlParser = new HtmlParser();
            this.downloadedImages = new ConcurrentBag<string>();
            this.visitedSites = new ConcurrentBag<string>();
        }

        public void Crawl(string url, int currentLevel, int maxLevel)
        {
            //Creating folder "Pics"
            if (!Directory.Exists(DownloadDirectory))
            {
                Directory.CreateDirectory(DownloadDirectory);
            }
            // Adding the visited site to the concurent bag
            this.visitedSites.Add(url);

            string html = string.Empty;
            using (var client = new WebClient())
            {
                try
                {
                    html = client.DownloadString(url);
                }
                catch (WebException wex)
                {
                    Console.WriteLine(wex.Message);
                }
            }

            // Get all img urls
            List<string> imgUrls = this.htmlParser.ParseHtml(html);

            // Download images from the parsed tags
            this.DownloadImages(url, imgUrls);

            // Revursively call itself for the anchored tags
            if (currentLevel <= maxLevel)
            {
                List<string> anchorUrls = this.htmlParser.ParseAnchors(html);
                foreach (var anchorUrl in anchorUrls)
                {
                    string adress = GetRightAdress(url, anchorUrl);
                    if (!this.visitedSites.Contains(anchorUrl))
                    {
                        this.Crawl(adress, currentLevel + 1, maxLevel);
                    }
                }
            }
        }

        private static string GetRightAdress(string domainUrl, string subUrl)
        {
            if (subUrl.StartsWith("http"))
            {
                return subUrl;
            }

            return string.Format("{0}/{1}", domainUrl, subUrl);
        }

        private static string GetImageName(string imgUrl)
        {
            int lastIndexOfSeperator = imgUrl.LastIndexOf("/");

            return imgUrl.Substring(lastIndexOfSeperator + 1);
        }

        private void DownloadImages(string url, List<string> imgUrls)
        {
            Parallel.ForEach(
                imgUrls, 
                imgUrl =>
                    {
                        using (var client = new WebClient())
                        {
                            string fileName = string.Format("{0}-{1}",Task.CurrentId, GetImageName(imgUrl));
                            string adress = GetRightAdress(url, imgUrl);

                            if (!this.downloadedImages.Contains(adress))
                            {
                                try
                                {
                                    client.DownloadFile(adress, Path.Combine(DownloadDirectory, fileName));
                                    this.downloadedImages.Add(adress);
                                }
                                catch (WebException)
                                {
                                }
                            }
                        }
                    });
        }
    }
}
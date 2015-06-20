using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebCrawler
{
    public class HtmlParser
    {
        private const string ImagePattern = "<img.+?src=\"(.*?)\".*?>";
        private const string AnchorPattern = "<a.+?href=\"(.*?)\".*?>";

        private readonly Regex imageRegex;
        private readonly Regex anchorRegex;

        public HtmlParser()
        {
            this.imageRegex = new Regex(ImagePattern);
            this.anchorRegex = new Regex(AnchorPattern);
        }

        public List<string> ParseHtml(string html)
        {
            MatchCollection matches = imageRegex.Matches(html);
            
            return matches.Cast<Match>().Select(match => match.Groups[1].Value).Where(url=>url != string.Empty).ToList();
        }

        public List<string> ParseAnchors(string html)
        {
            MatchCollection matches = anchorRegex.Matches(html);

            return matches.Cast<Match>().Select(match => match.Groups[1].Value).Where(anchortag => anchortag != string.Empty).ToList();
        }
    }
}

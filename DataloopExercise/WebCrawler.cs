using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace DataloopExercise
{
    class WebCrawler
    {
        readonly string[] imageTypes = { "jpg", "jpeg", "bmp", "png" };
        private List<Result> results;

        public async void Crawl(string url, int depth)
        {
            var client = new HttpClient();
            var htmlDoc = new HtmlDocument();

            var html = await client.GetStringAsync(url);
            htmlDoc.LoadHtml(html);

            var root = htmlDoc.DocumentNode;
            foreach (var node in root.ChildNodes)
            {
                CheckNode(node);
            }
        }

        private void CheckNode(HtmlNode node)
        {
            foreach (var n in node.ChildNodes)
            {
                if (n.HasAttributes)
                {
                    foreach (var attr in n.Attributes)
                    {
                        if (IsImage(attr.Value))
                        {
                            results.Add(new Result())
                        }
                    }
                }
                if (n.HasChildNodes)
                {
                    CheckNode(n);
                }
            }
        }

        private bool IsImage(string suspect)
        {
            foreach (var imageType in imageTypes)
            {
                string pattern = $"^(http.*{imageType})$";
                var match = Regex.Match(suspect, pattern);
                return match.Success;
            }

            return false;
        }
    }
}

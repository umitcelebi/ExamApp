using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Concrete
{
    public class DataExtraction
    {
        public static List<Topic> getTopic()
        {
            List<Topic> topics = new List<Topic>();
            try
            {
                string body = "";
                string url = "https://www.wired.com/";
                WebClient client = new WebClient();
                string html = client.DownloadString(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                string[] href = new string[5];

                for (int i = 0; i < 5; i++)
                {
                    href[i] = "https://www.wired.com" + doc.DocumentNode
                        .SelectSingleNode("/html/body/div[3]/div/div[3]/div/div/div[2]/div[3]/div[1]/div[1]/div/ul/li[" + (i + 1) + "]/a").Attributes["href"].Value;
                }

                for (int i = 0; i < 5; i++)
                {
                    url = href[i];
                    html = client.DownloadString(url);
                    doc.LoadHtml(html);

                    string title = doc.DocumentNode.SelectSingleNode("html/body/div[1]/div/main/article/div[1]/header/div/div[1]/h1").InnerHtml;
                    body = "";
                    HtmlNodeCollection div = doc.DocumentNode.SelectNodes("//div[contains(@class, 'grid--item body body__container article__body grid-layout__content')]");

                    foreach (var item in div)
                    {
                        body += item.InnerText;
                    }
                    
                    Topic topic = new Topic()
                    {
                        Title = title,
                        Body = body
                    };
                    topics.Add(topic);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return topics;
        }
    }
}
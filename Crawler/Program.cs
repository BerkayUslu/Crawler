using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace crawler

{
    class MainClass
    {
        static List<string> LessonName = new List<string>();

        public static void Main(string[] args)
        {
            StartCrawlerAsync();
            Console.ReadLine();
        }

        private static async void StartCrawlerAsync()
        {
            var url = "https://online.yildiz.edu.tr/?transaction=LMS.EDU.LessonProgram.ViewOnlineLessonProgramForStudent/19332";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);


            var divs = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                    .Equals("col-sm-8 grid8")).ToList();

            foreach (var div in divs)
            {
                LessonName.Add(div.InnerText);
            }
        }
    }
}

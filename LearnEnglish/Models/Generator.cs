using System;
using Domain;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace LearnEnglish.Models
{
    public static class Generator
    {
        public static Word Generate(string title)
        {
            var url = "http://dictionary.cambridge.org/dictionary/english/" + title.ToLower();
            var resolt = Parsing(url);

            return new Word(title, resolt[0], resolt[1], resolt[2], resolt[3], "");
        }

        private static string[] Parsing(string url)
        {
            var result = new string[4];

            try
            {
                HttpClient http = new HttpClient();
                //var response = await http.GetByteArrayAsync(url);
                byte[] response = http.GetByteArrayAsync(url).Result;
                string source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                source = WebUtility.HtmlDecode(source);
                HtmlDocument resultat = new HtmlDocument();
                resultat.LoadHtml(source);


                HtmlNode ukHtmlNode = resultat.DocumentNode.Descendants()
                    .FirstOrDefault(x =>
                            x.Name == "span" &&
                            x.Attributes["class"] != null &&
                            x.Attributes["pron-region"].Value.Contains("UK") &&
                            x.Attributes["class"].Value.Contains("pron-info"));

                HtmlNode usHtmlNode = resultat.DocumentNode.Descendants()
                    .FirstOrDefault(x =>
                            x.Name == "span" &&
                            x.Attributes["class"] != null &&
                            x.Attributes["pron-region"].Value.Contains("US") &&
                            x.Attributes["class"].Value.Contains("pron-info"));

                result[0] = resultat.DocumentNode.Descendants()
                    .FirstOrDefault(x => x.Name == "span" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("circle circle-btn sound audio_play_button uk"))?
                    .Attributes["data-src-mp3"].Value ?? "";

                result[1] = ukHtmlNode?.Descendants()
                    .FirstOrDefault(x =>
                            x.Name == "span" &&
                            x.Attributes["class"] != null &&
                            x.Attributes["class"].Value.Contains("ipa"))?
                    .ToString() ?? "";

                result[2] = resultat.DocumentNode.Descendants()
                    .FirstOrDefault(x => x.Name == "span" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("circle circle-btn sound audio_play_button us"))?
                    .Attributes["data-src-mp3"].Value ?? "";

                result[3] = usHtmlNode?.Descendants()
                    .FirstOrDefault(x =>
                            x.Name == "span" &&
                            x.Attributes["class"] != null &&
                            x.Attributes["class"].Value.Contains("ipa"))?
                    .ToString() ?? "";

                return result;

            }
            catch (Exception)
            {
                //   Tratarea exceptiei  !!!!!!!!!!!!!!!!!!!!
                return null;
            }


        }
    }
}

// circle circle-btn sound audio_play_button uk
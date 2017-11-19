using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace AltcoinExpert.Util
{
    public static class Requests
    {
        public static string getRequest(String url)
        {
            string html = string.Empty;
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }


        }
    }
}

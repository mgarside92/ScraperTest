using ScraperExample090121.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScraperExample090121.Domain
{
    public class SearchEngineURLProvider : ISearchEngineURLProvider
    {
        public string Provide(string terms, string searchEnginePreference = "google")
        {
            switch (searchEnginePreference)
            {
                case "google":
                    return $"https://www.google.co.uk/search?num=100&q={terms}";

                case "bing":
                    return $"https://www.bing.com/search?count=100&q={terms}";

                case "yahoo":
                    return $"https://uk.search.yahoo.com/search?p={terms}&n=100";

                default:
                    return $"https://www.google.co.uk/search?num=100&q={terms}";
            }
        }
    }
}

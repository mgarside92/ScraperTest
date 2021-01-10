using System;
using System.Collections.Generic;
using System.Text;

namespace ScraperExample090121.Domain.Interfaces
{
    public interface ISearchEngineURLProvider
    {
        string Provide(string terms, string searchEnginePreference);
    }
}

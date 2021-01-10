using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScraperExample090121.Repositories.ClientWrapper.Interfaces
{
    public interface IHttpClientWrapper
    {
        Task<string> GetStringAsync(string url);
    }
}

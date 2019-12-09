using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProxyApiService.Domain;

namespace ProxyApiService.Services
{
    public interface IProxyService
    {
        Task<List<Proxy>> GetProxiesAsync();
        Task<Proxy> GetProxyByIdAsync(string proxyAddress);
        Task<bool> CreateProxyAsync(Proxy proxy);
        Task<bool> UpdateProxyAsync(Proxy proxyToUpdate);
        Task<bool> DeleteProxyAsync(string proxyAddress);
    }
}
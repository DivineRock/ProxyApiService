
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProxyApiService.Data;
using ProxyApiService.Domain;

namespace ProxyApiService.Services
{
    public class ProxyService : IProxyService
    {
        private readonly DataContext _dataContext;

        public ProxyService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Proxy>> GetProxiesAsync()
        {
            return await _dataContext.Proxies.ToListAsync();
        }

        public async Task<Proxy> GetProxyByIdAsync(string proxyAddress)
        {
            return await _dataContext.Proxies.SingleOrDefaultAsync(x => x.Address == proxyAddress);
        }

        public async Task<bool> CreateProxyAsync(Proxy proxy)
        {
            await _dataContext.Proxies.AddAsync(proxy);
            var created= await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateProxyAsync(Proxy proxyToUpdate)
        {
            _dataContext.Proxies.Update(proxyToUpdate);
            var updated= await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteProxyAsync(string proxyAddress)
        {
            var proxy = await GetProxyByIdAsync(proxyAddress);

            if (proxy == null)
                return false;

            _dataContext.Proxies.Remove(proxy);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
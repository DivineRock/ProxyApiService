using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxyApiService.Contracts.V1;
using ProxyApiService.Contracts.V1.Requests;
using ProxyApiService.Contracts.V1.Responses;
using ProxyApiService.Domain;
using ProxyApiService.Services;

namespace ProxyApiService.Controllers.V1
{
    public class ProxiesController : Controller
    {
        private readonly IProxyService _proxyService;

        public ProxiesController(IProxyService proxyService)
        {
            _proxyService = proxyService;
        }

        [HttpGet(ApiRoutes.Proxies.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _proxyService.GetProxiesAsync());
        }

        [HttpGet(ApiRoutes.Proxies.Get)]
        public async Task<IActionResult> Get([FromRoute]string proxyAddress)
        {
            var proxy = await _proxyService.GetProxyByIdAsync(proxyAddress);

            if (proxy == null)
                return NotFound();

            return Ok(_proxyService.GetProxyByIdAsync(proxyAddress));
        }

        [HttpPost(ApiRoutes.Proxies.Create)]
        public async Task<IActionResult> Create([FromBody] CreateProxyRequest proxyRequest)
        {
            var proxy = new Proxy
            {
                Address = $"{proxyRequest.Host}:{proxyRequest.Port}",
                Host = proxyRequest.Host,
                Port = proxyRequest.Port,
                Country = proxyRequest.Country,
                User = proxyRequest.User,
                Password = proxyRequest.Password,
                Type = proxyRequest.Type,
                Status = proxyRequest.Status ?? 0,
            };

            await _proxyService.CreateProxyAsync(proxy);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = $"{baseUrl}/{ApiRoutes.Proxies.Get.Replace("{proxyAddress}", proxy.Address)}";

            var response = new ProxyResponse {Address = proxy.Address};
            return Created(locationUrl, response);
        }

        [HttpPut(ApiRoutes.Proxies.Update)]
        public async Task<IActionResult> Update([FromRoute]string proxyAddress, [FromBody]UpdateProxyRequest request)
        {
            var oldProxy = _proxyService.GetProxyByIdAsync(proxyAddress).Result;

            var proxy = new Proxy
            {
                Address = proxyAddress,
                Host = request.Host,
                Port = request.Port,
                Country = request.Country ?? oldProxy.Country,
                User = request.User ?? oldProxy.User,
                Password = request.Password ?? oldProxy.Password,
                Type = request.Type ?? oldProxy.Type,
                Status = request.Status ?? oldProxy.Status,
            };
            var updated = await _proxyService.UpdateProxyAsync(proxy);
            if (updated)
                return Ok(_proxyService.GetProxyByIdAsync(proxyAddress));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Proxies.Delete)]
        public async Task<IActionResult> Delete([FromRoute]string proxyAddress)
        {
            var deleted = await _proxyService.DeleteProxyAsync(proxyAddress);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}
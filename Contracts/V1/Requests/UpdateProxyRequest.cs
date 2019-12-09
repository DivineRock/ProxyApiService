namespace ProxyApiService.Contracts.V1.Requests
{
    public class UpdateProxyRequest
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }

        public string Type { get; set; }

        public int? Status { get; set; }
    }
}
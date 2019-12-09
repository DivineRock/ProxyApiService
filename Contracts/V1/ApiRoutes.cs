namespace ProxyApiService.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Version = "v1";
        private const string Root = "api";
        private const string Base = Root + "/" +Version;

        public static class Proxies
        {
            public const string GetAll = Base + "/proxies";
            public const string Get = Base + "/proxy/{proxyAddress}";
            public const string Update = Base + "/proxies/{proxyAddress}";
            public const string Delete = Base + "/proxies/{proxyAddress}";
            public const string Create = Base + "/proxies";
        }
    }
}
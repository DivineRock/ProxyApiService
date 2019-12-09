using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProxyApiService.Domain
{
    public class Proxy
    {
        [Key]
        public string Address { get; set; }

        public string Host { get; set; }

        public string Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }

        public string Type { get; set; }

        public int Status { get; set; }
    }
}
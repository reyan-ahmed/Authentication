using System;
namespace Identity.Models
{
    public class JWTToken
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Expiry { get; set; }
    }
}

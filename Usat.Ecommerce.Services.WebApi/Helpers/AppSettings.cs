﻿namespace Usat.Ecommerce.Services.WebApi.Helpers
{
    public class AppSettings
    {
        public string OriginCors { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TimeTrackingFrontEnd.Models
{
    public static class GlobalModels
    {
        public static HttpClient client_http { get; set; }
    }
}

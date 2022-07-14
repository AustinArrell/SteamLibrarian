using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models
{
    class WebRequestHandler
    {
        public WebRequestHandler() 
        {
            
        }
        
        WebClient client = new WebClient();

        public string GetWebRequestResponse(string requestURL) 
        {
            return client.DownloadString(requestURL);
        }
    }
}

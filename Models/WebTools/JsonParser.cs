using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace apiDev.Models
{
    class JsonParser
    {
        public JObject deserializedJson { get; set; }

        public void DeserializeString(string jsonStringToDeserialize) 
        {
            deserializedJson = JObject.Parse(jsonStringToDeserialize);
        }
        
    }
}

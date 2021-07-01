using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ZdravaHranaNinaEntities
{
    public class ProductData
    {
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ZdravaHranaNinaEntities
{
    public class CategoryData
    {
        [JsonPropertyName("products")]
        public List<Category> Categories { get; set; }
    }
}

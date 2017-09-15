using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TheForum
{
    public class JsonString
    {
        public static JsonString CreateUserFromJson(string json)
        {
            JsonString afterJson = JsonConvert.DeserializeObject<JsonString>(json);
            return afterJson;
        }

        public string ToJsonString(Items i)
        {
            return JsonConvert.SerializeObject(i);
        }

        public List<Items> ConvertToList(string i)
        {
            List<Items> items = JsonConvert.DeserializeObject<List<Items>>(i);
            return items;
        }

        public string ConvertToJson(List<Items> i)
        {
            string items = JsonConvert.SerializeObject(i);
            return items;
        }
    }
}


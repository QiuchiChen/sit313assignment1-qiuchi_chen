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

        public string ToJsonString(Items item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public List<Items> ConvertToList(string item)
        {
            List<Items> items = JsonConvert.DeserializeObject<List<Items>>(item);
            return items;
        }

        public string ConvertToJson(List<Items> item)
        {
            string items = JsonConvert.SerializeObject(item);
            return items;
        }
    }
}


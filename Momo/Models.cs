using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momo
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TikTokFollow
    {
        public string id { get; set; }
        public string real_id { get; set; }
        public string link { get; set; }
        public string uniqueID { get; set; }
        public string type { get; set; }
    }

    public class Data
    {
        public int cache { get; set; }
        public List<TikTokFollow> tiktok_follow { get; set; }
    }

}

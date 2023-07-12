using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momo
{
    public class ConfigService
    {
        public string CurrentUrl { get; set; } = "https://traodoisub.com/api";
        public string Token { get; set; } = "TDS0nI0IXZ2V2ciojIyVmdlNnIsIyNwEjMtFGawdmbvV3YiojIyV2c1Jye";
    }
    public class ConfigChrome
    {
        public string BinaryLocation { get; set; } = "";
        public string UserDataDir { get; set; } = "";
        public string Extension { get; set; } = "";
        public string[] Arguments { get; set; } 
    }
    public class ConfigTikTok
    {
        public string ButtonFollowTiktok { get; set; } = "/html/body/div[1]/div[2]/div[2]/div/div[1]/div[1]/div[2]/div/div[1]/button";
    }
   
}

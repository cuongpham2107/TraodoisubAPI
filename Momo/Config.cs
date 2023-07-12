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
        public string BinaryLocation { get; set; } = @"D:\Gologin\Browser\orbita-browser-113\chrome.exe";
        public string UserDataDir { get; set; } = @"--user-data-dir=D:\Gologin\Profiles\{id}";
        public string Extension { get; set; } = @"--load-extension=D:\Gologin\Extensions\cookies-ext\{id},D:\Gologin\Extensions\passwords-ext\{id}";
        public string[] Arguments { get; set; } = new[] { "--font-masking-mode=2", "--profile-directory=Default", "--disable-encryption", "--donut-pie=undefined", "--lang=en-US", "--flag-switches-begin", "--flag-switches-end" };
    }
    public class ConfigTikTok
    {
        public string ButtonFollowTiktok { get; set; } = "/html/body/div[1]/div[2]/div[2]/div/div[1]/div[1]/div[2]/div/div[1]/button";
    }
   
}

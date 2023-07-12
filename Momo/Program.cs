using Common;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Momo
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            
            ConfigChrome _config = ConfigManager<ConfigChrome>.Instance.Config;
            Services _services = ConfigManager<Services>.Instance.Config;
            //api

            Data data = await _services.GetList<Data>("tiktok_follow");
            Console.WriteLine(data.data[0]);
            string profileID = "64a3d2cd6bc6bb5b9f013500";
            ChromeOptions options = new();
            options.BinaryLocation = _config.BinaryLocation;
            options.AddArgument(_config.UserDataDir.Replace("{id}", profileID));
            options.AddArgument(_config.Extension.Replace("{id}", profileID));
            options.AddArguments("--disable-default-apps", "--disable-extensions");
            options.AddArguments(_config.Arguments);
            IWebDriver driver = new ChromeDriver(options);


            //driver.Navigate().GoToUrl(data.data[0].link);

            //foreach (var item in data.data)
            //{
            //    Console.WriteLine(item);
            //}


            //TODO: 
            //0. Lay danh sach nhiem vu
            //1. Follow 
            //2. Duyet nhiem vu
            //3. Nhan xu



        }
    }
    
}

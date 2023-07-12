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
            string profileID = "64ae90b1ce66032a15d7710b";
            ChromeOptions options = new();
            options.BinaryLocation = "/Users/phamcuong/.gologin/browser/orbita-browser-113/Orbita-Browser.app/Contents/MacOS/Orbita";
            options.AddArgument($"--user-data-dir=/private/tmp/gologin_074247d264/profiles/{profileID}");
            options.AddArgument($"--load-extension=/Users/phamcuong/.gologin/extensions/cookies-ext/{profileID}");
            options.AddArguments("--disable-default-apps", "--disable-extensions");
            //options.setExperimentalOption("useAutomationExtension", false);
            options.AddArguments(new[] { "--font-masking-mode=2", "--profile-directory=Default", "--disable-encryption", "--donut-pie=undefined", "--lang=en-US", "--flag-switches-begin", "--flag-switches-end" });
            IWebDriver driver = new ChromeDriver(options);
            while (true)
            {
                //TODO: 
                //0. Lay danh sach nhiem vu
                Data data = await _services.GetList<Data>("tiktok_follow");
                //1. Follow 
                TiktokSelenium tiktok= new TiktokSelenium(driver);
                int dem = 0;
               
                foreach(TikTokFollow item in data.tiktok_follow){
                    dem++;
                    tiktok.GotoUrl(item.link);
                    tiktok.ClickFollowTiktok();
                    Thread.Sleep(1000);
                    //2. Duyet nhiem vu
                    await _services.SubmitTask("TIKTOK_FOLLOW_CACHE", item.id);

                    // Lưu trữ session id của tab trước đó
                    string previousTab = driver.CurrentWindowHandle;

                    // Chuyển đến tab mới
                    ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    // Thực hiện các thao tác trên tab mới
                    // Đóng tab hiện tại
                    driver.Close();
                    // Chuyển về tab trước đó
                    driver.SwitchTo().Window(previousTab);
                    if(dem >=8 && dem <= 15){
                        dem = 0;
                        //3. Nhan xu
                        await _services.GetCoins("TIKTOK_FOLLOW");
                        break;
                    }
                    
                }    
            }
            
        }
        //Lay danh sach nhien vu
    } 
}

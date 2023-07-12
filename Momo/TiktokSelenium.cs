using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momo
{
    public class TiktokSelenium : DriverHelper
    {
        public TiktokSelenium(IWebDriver driver)
        {
            this.driver = driver;
        }
        static ConfigTikTok _config = ConfigManager<ConfigTikTok>.Instance.Config;
        private Actions Actions => new Actions(driver);
        private WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        private By elementButtonFollowTiktok => By.XPath(_config.ButtonFollowTiktok);
        public void GotoUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void ClickFollowTiktok()
        {
            try
            {
                IWebElement buttonFollow = wait.Until(driver => driver.FindElement(elementButtonFollowTiktok));
                Actions.MoveToElement(buttonFollow).Click().Perform();
                Extensions.WriteLine("Follow thành công", ConsoleColor.Green);
            }
            catch (Exception e)
            {
                Extensions.WriteLine("Lỗi: " + e, ConsoleColor.Red);
            }
           
        }
    }
}

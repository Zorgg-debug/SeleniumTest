using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Data.SQLite;
using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;

namespace SeleniumTest
{
    class Program
    {
        static public IWebDriver driver;
        static void Main(string[] args)
        {
            string prof = @"C:\Firefox\Profile1";
            FirefoxOptions options = new FirefoxOptions();
            FirefoxProfile profile = new FirefoxProfile(prof);
            HtmlParser parser = new HtmlParser();
            ParceHtml pars;
            options.BrowserExecutableLocation = (@"C:\Firefox\Firefox\Firefox.exe");
            options.Profile = profile;
            driver = new FirefoxDriver(options);
            driver.Url = @"https:";
            Console.WriteLine("Нажми кнопку после авторизации на сайте");
            Console.ReadKey();
            driver.SwitchTo().Frame((driver.FindElement(By.XPath("//html/body/div[1]/div/main/article/main/div/div/div[2]/div/iframe"))));
            var elem = driver.FindElements(By.XPath("//*[@class='payouts-block']"));
            while (true)
            {
                var ElemEndGame = (new WebDriverWait(driver, System.TimeSpan.FromSeconds(150))).Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@class='after-end-wrapper after-end-wrapper-lg ng-star-inserted']")));
                pars = new ParceHtml(parser.ParseDocument(driver.PageSource));
                var StartGame = (new WebDriverWait(driver, System.TimeSpan.FromSeconds(150))).Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@class = 'payout-coefficient-wrapper ng-star-inserted']")));
            }
        }
    }
}

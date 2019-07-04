using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace easyeftthc
{
    public class FNB
    {
        static IWebDriver driver;
        public static string fail;
        public static string stat;

        public static void FNBLog(String email, String password)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("--headless", "--disable-gpu", "--window-size=1200,900");
            driver = new ChromeDriver(option);

            driver.Navigate().GoToUrl("https://www.fnb.co.za/ways-to-bank/online-banking.html");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'user']"))).SendKeys(email);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'pass']"))).SendKeys(password);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'OBSubmit']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class = 'iconImage ui-icon ui-icon_reservedPayments']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() = 'Once Off']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class = 'dropdown-trigger threeTier-trigger']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[@class = 'dropdown-item clearfix']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'accountRecipientName']"))).SendKeys("Traverse");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'branchSearchButton']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() = 'Select Bank']/..//div[@class = 'dropdown-trigger singleTier-trigger']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class = 'dropdown-content-wrapper dropdown-expanded']//div[text() = 'Standard Bank']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'accountNumber']"))).SendKeys("270657282");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'accountHowMuch']"))).SendKeys("1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'accountTheirReference']"))).SendKeys("test");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'accountMyReference']"))).SendKeys("test");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'methodContactInput0']"))).SendKeys("traversek@gmail.com");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'addresseeInput0']"))).SendKeys("Traverse King");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id = 'mainBtnHref']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Confirm']"))).Click();
        }

        public static void loginOTP(String otp)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'otpValue']"))).SendKeys(otp);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class = 'otpInputWrapperRight']//div[@id= 'submitBtn']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='currentSubtab']/div[1]/div/div[3]/p[1]")));

            stat = driver.FindElement(By.XPath("//*[@id='currentSubtab']/div[1]/div/div[3]/p[1]")).Text;

            if (stat.Contains("successfully paid"))
            {

            }
            else
            {

            }

            driver.Quit();
        }
    }
}

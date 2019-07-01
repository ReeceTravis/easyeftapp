using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace easyeftthc
{
    public class Nedbank
    {
        static IWebDriver driver;
        public static string fail;
        public static string stat;

        public static void NedbankLog(String email, String pin, String password)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("--headless", "--disable-gpu", "--window-size=1200,900");
            driver = new ChromeDriver(/*option*/);

            driver.Navigate().GoToUrl("https://netbank.nedsecure.co.za/default.aspx");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame[@name = 'frameMain']"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ProfileId']"))).SendKeys(email);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'PinNo']"))).SendKeys(pin);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'Password']"))).SendKeys(password);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@id = 'LoginPagelet_LogonID']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@title= 'Close']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//font[text() = 'Payments']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//font[text() = 'Pay']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='PageBody']/div[4]")));
        }

        public static void conCap(/*string rec*/)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id='PageBody']/div[4]")));

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame[@name = 'frameMain']"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_cmbAccountType']//option[text() = 'Account with another bank']"))).Click();

            /*driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));
            */
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_cmdAnotherBank']//option[text() = 'STANDARD BANK OF SOUTH AFRICA']"))).Click();
            /*
            
            */
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_txtAccountNumber']"))).SendKeys("270657282");
            /*
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));
            */
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_txtMyStatementDescription']"))).SendKeys("Traverse");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_txtBeneficiaryStatementDescription']"))).SendKeys("test");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_cmbPaymentNotificationType']//option[text() = 'EMAIL']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_txtPaymentNotificationDetail']"))).SendKeys("traversek@gmail.com");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ctl00_ctpPageContent_OnceOffPaymentsAddTransaction_txtAmount']"))).SendKeys("1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ctl00_ctpPageContent_btnMakeSinglePayment']"))).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame[@name = 'frameMain']"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'ctl00_ctpPageContent_btnConfirmPayments']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='PageBody']/div[4]")));
        }

        public static void conPay1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class= 'ui-dialog ui-widget ui-widget-content ui-corner-all  ui-draggable']")));

           /* driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this beneficiary']"))).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'amount']"))).SendKeys("1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this amount now (Money will be available within 48 hours)']"))).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this amount now (Money will be available within 48 hours)']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[4]")));*/
        }

        public static void confirmPay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//*[@id='PageBody']/div[4]")));

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame[@name = 'frameMain']"))));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ctl00_ctpPageContent_PageTitle1']/table/tbody/tr/td/table/tbody/tr/td/span")));

            stat = driver.FindElement(By.XPath("//*[@id='ctl00_ctpPageContent_PageTitle1']/table/tbody/tr/td/table/tbody/tr/td/span")).Text;

            if (stat.Equals("Pay - complete"))
            {

            }
            else
            {

            }


        }

        public static void conPay2()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//html/body/div[4]")));

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Make another payment']"))).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@name = 'selectedBeneficiary']//option[contains(text(), 'Traverse')]"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Remove the selected beneficiary']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Yes']"))).Click();

            driver.Quit();
        }
    }
}

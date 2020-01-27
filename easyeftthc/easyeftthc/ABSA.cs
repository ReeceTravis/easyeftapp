using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace easyeftthc
{
    public class ABSA
    {
        static IWebDriver driver;
        public static string fail;
        public static string stat;
        public static string cphrase1;
        public static string cphrase2;
        public static string cphrase3;
        public static string tphrase1;
        public static string tphrase2;


        //Method to be called after clicking login button
        public static void ABSALog(String email, String pin, String password)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("--headless", "--disable-gpu", "--window-size=1200,900");
            driver = new ChromeDriver(option);

            driver.Navigate().GoToUrl("https://ib.absa.co.za/absa-online/login.jsp");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));


            //Credentials to be called from the front end
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'j_username']"))).SendKeys(email);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'j_pin']"))).SendKeys(pin);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() = 'Next']/.."))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id= 'landingpage2']//option[text() = 'Make a payment']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff1']")));


            //Finds which fields ae requested for the password phrase
            cphrase1 = driver.FindElement(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff1']")).GetAttribute("num");
            cphrase2 = driver.FindElement(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff2']")).GetAttribute("num");
            cphrase3 = driver.FindElement(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff3']")).GetAttribute("num");

            
        }


        //After logging in navigates to payment screen, user will have to confirm on banking app
        public static void payNav()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'ui-button-left']//div[text() = 'Logon']/..")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class = 'ui-button-left']//div[text() = 'Logon']/.."))).Click();

            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id]//span[text() = 'Pay']")));

            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id]//span[text() = 'Pay']"))).Click();

            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class = 'icon-pay-once-off']/..")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class = 'icon-pay-once-off']/.."))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text() = 'Seconds remaining']")));
        }


        //Method should be called after user has conirmed payment method on banking app
        public static void makepay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[text() = 'Seconds remaining']")));

           // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'addBeneficiary-externalAccount']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'fullName']"))).SendKeys("Traverse");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder= 'Capture and select bank name']"))).SendKeys("STANDARD BANK SA LTD");

           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = 'STANDARD BANK SA LTD']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder= 'Capture and select bank name']"))).SendKeys(Keys.ArrowDown);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder= 'Capture and select bank name']"))).SendKeys(Keys.Enter);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder= 'Capture and select the Branch name or Branch code']"))).SendKeys("051001");

            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = '051001']")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder= 'Capture and select the Branch name or Branch code']"))).SendKeys(Keys.ArrowDown);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder= 'Capture and select the Branch name or Branch code']"))).SendKeys(Keys.Enter);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'accountNumber']"))).SendKeys("270657282");
			
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id= 'accountType']"))).Click();
			
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Cheque Account']"))).Click();
			
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'amount']"))).SendKeys("1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'myReference']"))).SendKeys("MyRef1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'beneficiaryReference']"))).SendKeys("BenRef1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text() = 'Next']"))).Click();
			
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h1[text() = ' This beneficiary already exists']/../..//span[@class = 'radio-control__indicator']"))).Click();
			
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text() = ' Use existing beneficiary ']"))).Click();
			
			wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text() = 'Confirm']"))).Click();

          /*  wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id = 'paymentNotification-notBenType']//option[text() = 'E-mail']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'paymentNotification-notBenEmail']"))).SendKeys("rtzyster@gmail.com");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'paymentNotification-notBenName']"))).SendKeys("Reece");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='ui-wizard-body1']/div/form/div[3]/div[5]/div/button[3]/div/div/div"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class = 'ui-button-left']//div[text() = 'Add']/.."))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'ui-button-left']//div[text() = 'Pay this beneficiary']/.."))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'paySingle-amount']"))).SendKeys("1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='ui-wizard-body1']/div/form/div[2]/div[4]/div/button[3]/div/div/div"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class = 'ui-button-left']//div[text() = 'Pay']/.."))).Click();*/

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text() = 'Seconds remaining']")));
        }

     /*   public static void DeleteBen()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class = 'ap-timer-left']")));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[text() = 'Manage beneficiary or group']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() = 'Traverse']/../../../..//button[@aria-label = 'Remove beneficiary. ']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@role = 'alertdialog']//div[@class = 'ui-button-left']//div[text() = 'Next']/.."))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@role = 'alertdialog']//div[@class = 'ui-button-left']//div[text() = 'Remove']/.."))).Click();

            driver.Quit();
        }*/

        public static void confirmPay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[text() = 'Seconds remaining']")));

            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'status-panel-header__text']//h4[contains(@class, 'status-panel-header__title')]")));

            stat = driver.FindElement(By.XPath("//div[@class = 'status-panel-header__text']//h4[contains(@class, 'status-panel-header__title')]")).Text;
        }

        public static void phraseCapturepoint1(string point1)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff1']"))).SendKeys(point1);
        }

        public static void phraseCapturepoint2(string point2)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff2']"))).SendKeys(point2);
        }

        public static void phraseCapturepoint3(string point3)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff3']"))).SendKeys(point3);
        }

        public static void getphrase1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            tphrase1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff1']"))).GetAttribute("value");
        }
        public static void getphrase2()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            tphrase2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[@id = 'id_pff2']/..//input[@id = 'pff2']"))).GetAttribute("value");
        }

        public static void conCap(string rec)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class = 'ui-dialog ui-widget ui-widget-content ui-corner-all  ui-draggable']")));

            //driver.SwitchTo().DefaultContent();

            //driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Go to the payments menu']"))).Click();

            /*driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));
            */
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay a beneficiary']"))).Click();
            /*
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));
            */
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Create my own beneficiary']"))).Click();
            /*
            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));
            */
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'beneficiaryName']"))).SendKeys("Traverse");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'beneficiaryAccountNo']"))).SendKeys("270657282");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id = 'selectedBankID']//option[text() = 'Standard Bank']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'beneficiaryToStatementDesc']"))).SendKeys("eftref1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'emailShow']"))).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name= 'email']"))).SendKeys(rec);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Add this beneficiary to my list']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[7]")));
        }

        public static void conPay1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//html/body/div[7]")));

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this beneficiary']"))).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'amount']"))).SendKeys("1");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this amount now (Money will be available within 48 hours)']"))).Click();

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this amount now (Money will be available within 48 hours)']"))).Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[4]")));
        }

        //public static void confirmPay()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //    driver.SwitchTo().DefaultContent();

        //    driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        //    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() = 'Status:']/..//em")));

        //    stat = driver.FindElement(By.XPath("//div[text() = 'Status:']/..//em")).Text;

        //    if (stat.Equals("Successful"))
        //    {

        //    }
        //    else
        //    {

        //    }


        //}

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

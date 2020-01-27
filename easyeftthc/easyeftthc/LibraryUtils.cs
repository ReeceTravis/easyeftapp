﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Windows;

/// <summary>
/// Summary description for LibraryUtils
/// </summary>
public static class LibraryUtils
{

    public static IWebDriver driver;

    static string eftref;
    public static string con;
    public static string fail;
    //public static string rec;
     
   

     //Mehtod should be called after user enters credentialss and clicks the login button
    public static void EmailLogin(String email, String password)
    {
        FirefoxOptions option = new FirefoxOptions();
        option.AddArguments("--headless", "--disable-gpu", "--window-size=1200,900");
        //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\EFT\chromedriver.exe");
        //driver = new ChromeDriver("C:\\EFT", option);
        //var service = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
        //Convert.ToString(service);
        //option.BinaryLocation = "C:\\Users\\Public\\chromedriver.exe";
        //string opt = Convert.ToString(service);
        //opt += @".chromedriver";
        //option.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chromedriver.exe";
        //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C:\\Users\\Public\\chromedriver.exe");
        // ChromeOptions opts = new ChromeOptions();
        // opts.AddExcludedArgument("enable-automation");
        //opts.AddAdditionalCapability("useAutomationExtension", false);
        driver = new FirefoxDriver(/*service,*/ option);

        //driver.Navigate().GoToUrl("https://onlinebanking.standardbank.co.za/#/login?intcmp=coza-sitewide-headernav-direct-login");
        driver.Navigate().GoToUrl("https://onlinebanking.standardbank.co.za/#/login");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //Credentials will be called from login credentials page
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'username']"))).SendKeys(email);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text() = 'Next']"))).Click();

        if (LibraryUtils.IsElementPresent(By.XPath("//span[text() = 'Sign In With Password']/..")))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Sign In With Password']/.."))).Click();
        }
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type = 'password']"))).SendKeys(password);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Sign in']/.."))).Click();
    }

    public static void conBen(String rec)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        Random generator = new Random();
        String r = generator.Next(0, 999999).ToString("D6");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'PAY']"))).Click();

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[text() = 'Once-off payment']"))).Click();

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'name']"))).SendKeys("Traverse");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'Bank-input']"))).SendKeys("standard bank");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'Bank-input']"))).SendKeys(Keys.Enter);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'accountNumber']"))).Click();

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'accountNumber']"))).SendKeys("10091879696");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'myReference']"))).SendKeys("eft test");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'beneficiaryReference']"))).SendKeys(r);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'Recipient_Name']"))).SendKeys("Traverse");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'Recipient_Email']"))).SendKeys(rec);


        //Amount will be called form the front end
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'amount']"))).SendKeys("1");
    }

   


    //Check should be pplaced to see if the user has enough credit for transaction, if they do not they should be notified  they don't have funds in account
    public static void money()
    {
        if (IsElementPresent(By.XPath("//span[text() = 'The amount exceeds your available balance']")))
        {
            MessageBox.Show("The amount exceeds your available balance");
            //driver.Quit();
        }
    }

    //Check should be pplaced to see if the user has enough credit for transaction, if they do not they should be notified  they don't have funds in account
    public static void aftermoney()
    {
        var Page2 = new easyeftthc.PaymentConfirmOTP();

        if (LibraryUtils.IsElementPresent(By.XPath("//span[text() = 'The amount exceeds your available balance']")))
        {
            LibraryUtils.driver.Quit();
        }
        else
        {
            LibraryUtils.conPay();
            Page2.Show();
        }
    }

   
    //If user has enough credit the transaction can proceed
    public static void conPay()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Next']/.."))).Click();

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Confirm']/.."))).Click();
    }

   
    //Should be called when OTP is requested
    public static void OTPSequence(String otp)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'otp']"))).SendKeys(otp);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Submit']/.."))).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'notification ng-scope success']//span//span")));

        con = driver.FindElement(By.XPath("//div[@class = 'notification ng-scope success']//span//span")).Text.ToString();

        driver.Quit();
    }

    public static void otpcheck(String rec)
    {
        if (IsElementPresent(By.XPath("//input[@id = 'otp']")))
        {

        }
        else
        {
            conBen(rec);
        }
    }

    //USsed to click the login button
    public static void loginOTP(String otp)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'otp']"))).SendKeys(otp);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Submit']/.."))).Click();
    }

    //Used to click resubmit button
    public static void Resubmit()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text() = 'Resend']/.."))).Click();
    }

    //Used to click cancel button
    public static void Cancel()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='cancel-button']"))).Click();
        driver.Quit();
    }


//---------------------------------------------------------------------------------------SELENIUM METHODS----------------------------------------------------------------------------------------------------------------//
    public static void WaitFindAndClick(IWebDriver parent, By by, int counter)

    {
        bool Displayed = false;

        for (int v = 0; v < counter; counter++)
        {
            try
            {
                // Thread.Sleep(2000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until((d) => { return parent.FindElement(by); });

                Displayed = parent.FindElement(by).Displayed;

                if (Displayed)
                {
                    parent.FindElement(by).Click();
                    break;
                }
            }
            catch
            {
            }
        }
    }

    public static bool IsElementPresent(By by)
    {
        try
        {
            Thread.Sleep(3000);
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public static void WaitFindAndEnter(IWebDriver parent, By by, int counter, String path)

    {
        bool Displayed = false;

        for (int v = 0; v < counter; counter++)
        {
            try
            {
                // Thread.Sleep(2000);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until((d) => { return parent.FindElement(by); });

                Displayed = parent.FindElement(by).Displayed;

                if (Displayed)
                {
                    parent.FindElement(by).SendKeys(path);
                    break;
                }
            }
            catch
            {
            }
        }


    }
    public static IWebElement waitForElement(this IWebDriver driver, By By, int timeoutInSeconds)
    {
        if (timeoutInSeconds > 0)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(By));
        }
        return driver.FindElement(By);
    }

    public static bool IsPresent(this IWebDriver driver, By bylocator)
    {
        bool variable = true;
        try
        {
            IWebElement element = driver.FindElement(bylocator);

        }
        catch (NoSuchElementException)
        {
            variable = false;
        }
        return variable;
    }
}
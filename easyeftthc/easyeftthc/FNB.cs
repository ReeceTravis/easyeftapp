﻿using OpenQA.Selenium;
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
            driver = new ChromeDriver(/*option*/);

            driver.Navigate().GoToUrl("https://www.fnb.co.za/ways-to-bank/online-banking.html");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

            //driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame[@name = 'frameMain']"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'user']"))).SendKeys(email);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'pass']"))).SendKeys(password);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'OBSubmit']"))).Click();

           // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@title= 'Close']"))).Click();

           // wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//font[text() = 'Payments']"))).Click();

            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//font[text() = 'Pay']"))).Click();

           // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'ui-dialog ui-widget ui-widget-content ui-corner-all  ui-draggable']")));
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

        public static void confirmPay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() = 'Status:']/..//em")));

            stat = driver.FindElement(By.XPath("//div[text() = 'Status:']/..//em")).Text;

            if (stat.Equals("Successful"))
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
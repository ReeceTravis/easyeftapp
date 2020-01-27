using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

/// <summary>
/// Summary description for Capitec
/// </summary>
public class Capitec
{
    static IWebDriver driver;
    public static string fail;
    public static string stat;

    
    //Method to be called when user clicks login button
    public static void CapitecLog(String email, String password)
    {
        ChromeOptions option = new ChromeOptions();
        option.AddArguments("--headless", "--disable-gpu", "--window-size=1200,900");
        driver = new ChromeDriver(/*option*/);

        driver.Navigate().GoToUrl("https://direct.capitecbank.co.za/ibank/");
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

        driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        //Credentials to be called from front end 
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//form//input[@id = 'username']"))).SendKeys(email);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type = 'password']"))).SendKeys(password);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Sign in']"))).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'ui-dialog ui-widget ui-widget-content ui-corner-all  ui-draggable']")));
    }


    //Only after user confirms login on front end should the following be called 
    //Does wait until timer disappears
    public static void conCap(string rec)
    {

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromMinutes(3));

        wait1.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class = 'ui-dialog ui-widget ui-widget-content ui-corner-all  ui-draggable']")));

        driver.SwitchTo().DefaultContent();

        driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Go to the payments menu']"))).Click();

        driver.SwitchTo().DefaultContent();

        driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay a beneficiary']"))).Click();

        driver.SwitchTo().DefaultContent();

        driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Create my own beneficiary']"))).Click();

        driver.SwitchTo().DefaultContent();

        driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'beneficiaryName']"))).SendKeys("Traverse");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'beneficiaryAccountNo']"))).SendKeys("270657282");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id = 'selectedBankID']//option[text() = 'Standard Bank']"))).Click();

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'beneficiaryToStatementDesc']"))).SendKeys("eftref1");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'emailShow']"))).Click();

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name= 'email']"))).SendKeys(rec);

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Add this beneficiary to my list']"))).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[7]")));
    }


    //Method to be called after user confirms beneficiary on banking app
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


        //Gets amount from front end
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'amount']"))).SendKeys("1");

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this amount now (Money will be available within 48 hours)']"))).Click();

        driver.SwitchTo().DefaultContent();

        driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text() = 'Pay this amount now (Money will be available within 48 hours)']"))).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//html/body/div[4]")));
    }
    

    //Method to be called after payment is complete to confirm status of request
    public static void confirmPay()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        driver.SwitchTo().DefaultContent();

        driver.SwitchTo().Frame(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//frame"))));

        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text() = 'Status:']/..//em")));

        stat = driver.FindElement(By.XPath("//div[text() = 'Status:']/..//em")).Text;

        if(stat.Equals("Successful"))
        {

        }
        else
        {

        }


    }


    //Removes added beneficiary
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
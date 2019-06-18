using OpenQA.Selenium;
using System.Windows;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for LoginOTP.xaml
    /// </summary>
    public partial class LoginOTP : Window
    {
        public LoginOTP()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string otp = logOTP.Password;
            var Page2 = new PaymentConfirmOTP();

            LibraryUtils.loginOTP(otp);

            if (LibraryUtils.IsElementPresent(By.XPath("//span[text() = 'PAY']")))
            {
                LibraryUtils.conBen(EnterCredentials.rec);
                LibraryUtils.money();
            }

            if (LibraryUtils.IsElementPresent(By.XPath("//span[text() = 'The amount exceeds your available balance']")))
            {
                LibraryUtils.driver.Quit();
            }
            else
            {
                LibraryUtils.conPay();
                Page2.Show();
                this.Close();
            }
        }
    }
}

using OpenQA.Selenium;
using System.Windows;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for Enter_Credentials.xaml
    /// </summary>
    public partial class EnterCredentials : Window
    {
        public static string rec;
        public EnterCredentials()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string pass = password.Password;
            rec = recemail.Text;
            var Page2 = new PaymentConfirmOTP();
            var Page3 = new LoginOTP();
            var ec = new EnterCredentials();
            
            LibraryUtils.EmailLogin(user, pass);

            if (LibraryUtils.IsElementPresent(By.XPath("//span[contains(text(), 'Incorrect')]")))
            {
                MessageBox.Show("Invalid sign-in details. Please try again");
            }
            else if (LibraryUtils.IsElementPresent(By.XPath("//input[@id = 'otp']")))
            {
                Page3.Show();
                this.Close();
            }
            else if (LibraryUtils.IsElementPresent(By.XPath("//span[text() = 'PAY']")))
            {
                LibraryUtils.conBen(rec);
                LibraryUtils.money();
                LibraryUtils.aftermoney();
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

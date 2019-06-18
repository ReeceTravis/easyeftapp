using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
    }
}

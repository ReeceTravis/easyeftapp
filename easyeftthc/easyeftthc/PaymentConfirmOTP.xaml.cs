using OpenQA.Selenium;
using System.Windows;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for PaymentConfirmOTP.xaml
    /// </summary>
    public partial class PaymentConfirmOTP : Window
    {
        public static IWebDriver driver;
        public PaymentConfirmOTP()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string otp = conotp.Password;
            
            LibraryUtils.OTPSequence(otp);

            if (LibraryUtils.con.Contains("successful"))
            {
                MessageBox.Show("Payment successful");
            }
            else
            {
                MessageBox.Show("Payment unsuccessful");
            }
        }

        private void Resubmit_Click(object sender, RoutedEventArgs e)
        {
            LibraryUtils.Resubmit();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            LibraryUtils.Cancel();
            var ec = new EnterCredentials();
            ec.Show();
            this.Close();
        }
    }
}

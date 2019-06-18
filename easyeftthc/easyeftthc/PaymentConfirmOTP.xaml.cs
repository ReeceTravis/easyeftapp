using System.Windows;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for PaymentConfirmOTP.xaml
    /// </summary>
    public partial class PaymentConfirmOTP : Window
    {
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
    }
}

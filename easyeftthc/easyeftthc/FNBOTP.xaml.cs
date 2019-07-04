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
    /// Interaction logic for FNBOTP.xaml
    /// </summary>
    public partial class FNBOTP : Window
    {
        public FNBOTP()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string otp = conotp.Password;
            var ec = new EnterCredentials();

            FNB.loginOTP(otp);

            if (FNB.stat.Contains("successfully paid"))
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

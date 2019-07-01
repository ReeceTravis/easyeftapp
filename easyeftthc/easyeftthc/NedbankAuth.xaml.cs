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
    /// Interaction logic for NedbankAuth.xaml
    /// </summary>
    public partial class NedbankAuth : Window
    {
        public NedbankAuth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string piN = pin.Password;
            string pass = password.Password;
            //rec = recemail.Text;

            Nedbank.NedbankLog(user, piN, pass);

            MessageBox.Show("Please check mobile banking app");

            Nedbank.conCap(/*rec*/);

            MessageBox.Show("Please check mobile banking app");

            //Nedbank.conPay1();

           // MessageBox.Show("Please check mobile banking app");

            Nedbank.confirmPay();

            if (Nedbank.stat.Equals("Pay - complete"))
            {
                MessageBox.Show("Payment successful");
            }
            else
            {
                MessageBox.Show("Payment unsuccessful");
            }

            //Nedbank.conPay2();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

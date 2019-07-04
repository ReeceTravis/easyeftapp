using System.Windows;

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

            Nedbank.confirmPay();

            if (Nedbank.stat.Equals("Pay - complete"))
            {
                MessageBox.Show("Payment successful");
            }
            else
            {
                MessageBox.Show("Payment unsuccessful");
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

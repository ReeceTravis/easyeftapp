using System.Windows;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for CapitecAuth.xaml
    /// </summary>
    public partial class CapitecAuth : Window
    {
        public static string rec;
        public CapitecAuth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string pass = password.Password;
            rec = recemail.Text;

            Capitec.CapitecLog(user, pass);

            MessageBox.Show("Please check mobile banking app");

            Capitec.conCap(rec);

            MessageBox.Show("Please check mobile banking app");

            Capitec.conPay1();

            MessageBox.Show("Please check mobile banking app");

            Capitec.conPay2();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

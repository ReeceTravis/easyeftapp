using System.Windows;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for ABSAAuth.xaml
    /// </summary>
    public partial class ABSAAuth : Window
    {
        public ABSAAuth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string piN = pin.Password;
            string pass = password.Password;
            //rec = recemail.Text;
            var Page2 = new ABSAPhraseCapture();

            ABSA.ABSALog(user, piN, pass);

            this.Close();
            Page2.Show();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}

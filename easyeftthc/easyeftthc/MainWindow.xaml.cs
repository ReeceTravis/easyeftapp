using System.Windows;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new EnterCredentials();
            Page2.Show();
            this.Close();
        }

        private void Capitec_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new CapitecAuth();
            Page2.Show();
            this.Close();
        }

        private void Nedbank_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new NedbankAuth();
            Page2.Show();
            this.Close();
        }

        private void FNB_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new FNBAuth();
            Page2.Show();
            this.Close();
        }

        private void ABSA_Click(object sender, RoutedEventArgs e)
        {
            var Page2 = new ABSAAuth();
            Page2.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Netwerk.netwerk();
        }
    }
}

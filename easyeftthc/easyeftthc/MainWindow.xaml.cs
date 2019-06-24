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
    }
}

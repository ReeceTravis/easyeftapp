using System;
using System.Windows;
using System.Windows.Media;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace easyeftthc
{
    /// <summary>
    /// Interaction logic for ABSAPhraseCapture.xaml
    /// </summary>
    public partial class ABSAPhraseCapture : Window
    {
        public static IWebDriver driver;
        public ABSAPhraseCapture()
        {
            InitializeComponent();
           // phraseheader.Content = ABSA.phrase;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (phrase1.IsEnabled == true)
            {
                string p1 = phrase1.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();

                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p1);
                }
                else if(ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p1);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p1);
                }
            }

            if (phrase2.IsEnabled == true)
            {
                string p2 = phrase2.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p2);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p2);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p2);
                }
            }

            if (phrase3.IsEnabled == true)
            {
                string p3 = phrase3.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p3);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p3);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p3);
                }
            }

            if (phrase4.IsEnabled == true)
            {
                string p4 = phrase4.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p4);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p4);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p4);
                }
            }

            if (phrase5.IsEnabled == true)
            {
                string p5 = phrase5.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p5);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p5);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p5);
                }
            }

            if (phrase6.IsEnabled == true)
            {
                string p6 = phrase6.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p6);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p6);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p6);
                }
            }

            if (phrase7.IsEnabled == true)
            {
                string p7 = phrase7.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p7);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p7);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p7);
                }
            }

            if (phrase8.IsEnabled == true)
            {
                string p8 = phrase8.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p8);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p8);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p8);
                }
            }

            if (phrase9.IsEnabled == true)
            {
                string p9 = phrase9.Password;
                ABSA.getphrase1();
                ABSA.getphrase2();
                if (ABSA.tphrase1.Length == 0)
                {
                    ABSA.phraseCapturepoint1(p9);
                }
                else if (ABSA.tphrase2.Length == 0)
                {
                    ABSA.phraseCapturepoint2(p9);
                }
                else
                {
                    ABSA.phraseCapturepoint3(p9);
                }
            }

            ABSA.payNav();

            MessageBox.Show("Please check mobile banking app");

            ABSA.makepay();

            MessageBox.Show("Please check mobile banking app");

            ABSA.confirmPay();

            if (ABSA.stat.Equals("Payment successful"))
            {
                MessageBox.Show("Payment successful");
            }
            else
            {
                MessageBox.Show("Payment unsuccessful");
            }

            ABSA.DeleteBen();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            switch (ABSA.cphrase1)
            {
                case "1":
                    if (ABSA.cphrase1.Equals("1"))
                    {
                        phrase1.IsEnabled = true;
                        phrase1.Background = Brushes.Red;
                    }

                    break;

                case "2":
                    if (ABSA.cphrase1.Equals("2"))
                    {
                        phrase2.IsEnabled = true;
                        phrase2.Background = Brushes.Red;
                    }

                    break;

                case "3":
                    if (ABSA.cphrase1.Equals("3"))
                    {
                        phrase3.IsEnabled = true;
                        phrase3.Background = Brushes.Red;
                    }

                    break;

                case "4":
                    if (ABSA.cphrase1.Equals("4"))
                    {
                        phrase4.IsEnabled = true;
                        phrase4.Background = Brushes.Red;
                    }

                    break;

                case "5":
                    if (ABSA.cphrase1.Equals("5"))
                    {
                        phrase5.IsEnabled = true;
                        phrase5.Background = Brushes.Red;
                    }

                    break;

                case "6":
                    if (ABSA.cphrase1.Equals("6"))
                    {
                        phrase6.IsEnabled = true;
                        phrase6.Background = Brushes.Red;
                    }

                    break;

                case "7":
                    if (ABSA.cphrase1.Equals("7"))
                    {
                        phrase7.IsEnabled = true;
                        phrase7.Background = Brushes.Red;
                    }

                    break;

                case "8":
                    if (ABSA.cphrase1.Equals("8"))
                    {
                        phrase8.IsEnabled = true;
                        phrase8.Background = Brushes.Red;
                    }

                    break;

                case "9":
                    if (ABSA.cphrase1.Equals("9"))
                    {
                        phrase9.IsEnabled = true;
                        phrase9.Background = Brushes.Red;
                    }

                    break;
            }

            switch (ABSA.cphrase2)
            {
                case "1":
                    if (ABSA.cphrase2.Equals("1"))
                    {
                        phrase1.IsEnabled = true;
                        phrase1.Background = Brushes.Red;
                    }

                    break;

                case "2":
                    if (ABSA.cphrase2.Equals("2"))
                    {
                        phrase2.IsEnabled = true;
                        phrase2.Background = Brushes.Red;
                    }

                    break;

                case "3":
                    if (ABSA.cphrase2.Equals("3"))
                    {
                        phrase3.IsEnabled = true;
                        phrase3.Background = Brushes.Red;
                    }

                    break;

                case "4":
                    if (ABSA.cphrase2.Equals("4"))
                    {
                        phrase4.IsEnabled = true;
                        phrase4.Background = Brushes.Red;
                    }

                    break;

                case "5":
                    if (ABSA.cphrase2.Equals("5"))
                    {
                        phrase5.IsEnabled = true;
                        phrase5.Background = Brushes.Red;
                    }

                    break;

                case "6":
                    if (ABSA.cphrase2.Equals("6"))
                    {
                        phrase6.IsEnabled = true;
                        phrase6.Background = Brushes.Red;
                    }

                    break;

                case "7":
                    if (ABSA.cphrase2.Equals("7"))
                    {
                        phrase7.IsEnabled = true;
                        phrase7.Background = Brushes.Red;
                    }

                    break;

                case "8":
                    if (ABSA.cphrase2.Equals("8"))
                    {
                        phrase8.IsEnabled = true;
                        phrase8.Background = Brushes.Red;
                    }

                    break;

                case "9":
                    if (ABSA.cphrase2.Equals("9"))
                    {
                        phrase9.IsEnabled = true;
                        phrase9.Background = Brushes.Red;
                    }

                    break;
            }

            switch (ABSA.cphrase3)
            {
                case "1":
                    if (ABSA.cphrase3.Equals("1"))
                    {
                        phrase1.IsEnabled = true;
                        phrase1.Background = Brushes.Red;
                    }

                    break;

                case "2":
                    if (ABSA.cphrase3.Equals("2"))
                    {
                        phrase2.IsEnabled = true;
                        phrase2.Background = Brushes.Red;
                    }

                    break;

                case "3":
                    if (ABSA.cphrase3.Equals("3"))
                    {
                        phrase3.IsEnabled = true;
                        phrase3.Background = Brushes.Red;
                    }

                    break;

                case "4":
                    if (ABSA.cphrase3.Equals("4"))
                    {
                        phrase4.IsEnabled = true;
                        phrase4.Background = Brushes.Red;
                    }

                    break;

                case "5":
                    if (ABSA.cphrase3.Equals("5"))
                    {
                        phrase5.IsEnabled = true;
                        phrase5.Background = Brushes.Red;
                    }

                    break;

                case "6":
                    if (ABSA.cphrase3.Equals("6"))
                    {
                        phrase6.IsEnabled = true;
                        phrase6.Background = Brushes.Red;
                    }

                    break;

                case "7":
                    if (ABSA.cphrase3.Equals("7"))
                    {
                        phrase7.IsEnabled = true;
                        phrase7.Background = Brushes.Red;
                    }

                    break;

                case "8":
                    if (ABSA.cphrase3.Equals("8"))
                    {
                        phrase8.IsEnabled = true;
                        phrase8.Background = Brushes.Red;
                    }

                    break;

                case "9":
                    if (ABSA.cphrase3.Equals("9"))
                    {
                        phrase9.IsEnabled = true;
                        phrase9.Background = Brushes.Red;
                    }

                    break;
            }
        }
    }
}

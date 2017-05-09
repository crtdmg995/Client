using Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace WFPclient
{
    /// <summary>
    /// Логика взаимодействия для Choose_City.xaml
    /// </summary>
    public partial class Choose_City : Window
    {



        //ServerConnector scServerConnector = new ServerConnector(ipAdr,PortNumber);
        ServerConnector scServerConnector = new ServerConnector();
        public Choose_City()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
       
        private void cmbl(object sender, RoutedEventArgs e)
        {
            string strSQLRequest = "SELECT * FROM City";
            DataTable dt1 = scServerConnector.exequteSQLRequest(strSQLRequest);
            combob0x.SelectedIndex = 0;
            List<string> list = dt1.AsEnumerable().Select(r => r.Field<string>("Місто")).ToList();
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            // ... Assign the ItemsSource to the List.
            combob0x.ItemsSource = list;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            const string quote = "'";
            if (dp.Text.Equals(""))
                MessageBox.Show("Ви не вибрали дату");
            else
            {
                t2.Text = "Прогноз погоди в місті " + combob0x.Text + " на " + dp.Text;
                string strSQLRequest1 = "SELECT * FROM Pogoda WHERE (Місто=N"+quote+combob0x.Text+quote+" AND Дата=" + quote + dp.Text + quote + ")";
                string strSQLRequest2 = "SELECT * FROM Pogoda WHERE (Місто=N"+quote+combob0x.Text+quote+" AND Дата=" + quote + dp.Text + quote + ")";
                string strSQLRequest3 = "SELECT * FROM Pogoda WHERE (Місто=N"+quote+combob0x.Text+quote+" AND Дата=" + quote + dp.Text + quote + ")";
                DataTable dt3 = scServerConnector.exequteSQLRequest(strSQLRequest1);
                DataTable dt4 = scServerConnector.exequteSQLRequest(strSQLRequest2);
                DataTable dt5 = scServerConnector.exequteSQLRequest(strSQLRequest3);
                try
                {
                    TDAY.Text = dt3.Rows[0]["ТВдень"].ToString();
                    TNIGHT.Text = dt4.Rows[0]["ТВночі"].ToString();
                    t1.Text = dt5.Rows[0]["Ситуація"].ToString();
                    TDAY.Text = TDAY.Text.Replace(" ", "");
                    TNIGHT.Text = TNIGHT.Text.Replace(" ", "");
                    t1.Text = t1.Text.Replace(" ", "");
                    day.Opacity = 100;
                    night.Opacity = 100;
                }
                catch
                {
                    day.Opacity = 0;
                    night.Opacity = 0;
                    im.Source = new BitmapImage(new Uri("", UriKind.RelativeOrAbsolute));
                    TNIGHT.Text = "";
                    t1.Text = "";
                    TDAY.Text = "";
                    t2.Text = "";
                    MessageBox.Show("В базі відстутня інформація про погоду в місті "+combob0x.Text+" на "+ dp.Text, "Помилка");
                }
                if (t1.Text == "Дощ")
                {
                    t1.Foreground = Brushes.AntiqueWhite;
                    t2.Foreground = Brushes.AntiqueWhite;
                    day.Foreground = Brushes.AntiqueWhite;
                    night.Foreground = Brushes.AntiqueWhite;
                    TDAY.Foreground = Brushes.AntiqueWhite;
                    TNIGHT.Foreground = Brushes.AntiqueWhite;
                    im.Source = new BitmapImage(new Uri("NewFolder1/rain.jpg", UriKind.RelativeOrAbsolute));
                }
                if (t1.Text == "Сніг")
                {
                    t1.Foreground = Brushes.Black;
                    t2.Foreground = Brushes.Black;
                    day.Foreground = Brushes.Black;
                    night.Foreground = Brushes.Black;
                    TDAY.Foreground = Brushes.Black;
                    TNIGHT.Foreground = Brushes.Black;
                    im.Source = new BitmapImage(new Uri("NewFolder1/snow.jpg", UriKind.RelativeOrAbsolute));
                }
                if (t1.Text == "Хмарно")
                {
                    t1.Foreground = Brushes.Red;
                    t2.Foreground = Brushes.Red;
                    day.Foreground = Brushes.Red;
                    night.Foreground = Brushes.Red;
                    TDAY.Foreground = Brushes.Red;
                    TNIGHT.Foreground = Brushes.Red;
                    im.Source = new BitmapImage(new Uri("NewFolder1/cloud.jpg", UriKind.RelativeOrAbsolute));
                }
                if (t1.Text == "Сонячно")
                {
                    t1.Foreground = Brushes.Blue;
                    t2.Foreground = Brushes.Blue;
                    day.Foreground = Brushes.Blue;
                    night.Foreground = Brushes.Blue;
                    TDAY.Foreground = Brushes.Blue;
                    TNIGHT.Foreground = Brushes.Blue;
                    im.Source = new BitmapImage(new Uri("NewFolder1/sun.jpg", UriKind.RelativeOrAbsolute));
                }

            }
        }
    }
}
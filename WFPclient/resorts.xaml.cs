using Client;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WFPclient
{
    /// <summary>
    /// Логика взаимодействия для resorts.xaml
    /// </summary>
    public partial class resorts : Window
    {
        ServerConnector scServerConnector = new ServerConnector();
        public resorts()
        {
            InitializeComponent();
            string time = DateTime.Now.ToString("dd.MM.yyyy");
            const string quote = "'";
            t1.Text = time;
            t2.Text = time;
            t3.Text = time;
            t4.Text = time;
            string strSQLRequest1 = "SELECT * FROM Pogoda WHERE (Місто=N'Ялта' AND Дата=" + quote + t1.Text + quote + ")";
            string strSQLRequest2 = "SELECT * FROM Pogoda WHERE (Місто=N'Алушта' AND Дата=" + quote + t1.Text + quote + ")";
            string strSQLRequest3 = "SELECT * FROM Pogoda WHERE (Місто=N'Алупка' AND Дата=" + quote + t1.Text + quote + ")";
            string strSQLRequest4 = "SELECT * FROM Pogoda WHERE (Місто=N'Маріуполь' AND Дата=" + quote + t1.Text + quote + ")";
            DataTable dt1 = scServerConnector.exequteSQLRequest(strSQLRequest1);
            DataTable dt2 = scServerConnector.exequteSQLRequest(strSQLRequest2);
            DataTable dt3 = scServerConnector.exequteSQLRequest(strSQLRequest3);
            DataTable dt4 = scServerConnector.exequteSQLRequest(strSQLRequest4);

            try
            {
                t11.Text = dt1.Rows[0]["ТВдень"].ToString();
                t21.Text = dt1.Rows[0]["ТВночі"].ToString();
                _111.Opacity = 100;
                _11.Opacity = 100;
                _1.Opacity = 100;
                t1.Opacity = 100;
                t11.Opacity = 100;
                t21.Opacity = 100;
                
            }
            catch
            {
                 _111.Opacity = 0;
                _11.Opacity = 0;
                _1.Opacity = 0;
                t1.Opacity = 0;
                t11.Opacity = 0;
                t21.Opacity = 0;


            }
            try
            {
                t12.Text = dt2.Rows[0]["ТВдень"].ToString();
                t22.Text = dt2.Rows[0]["ТВночі"].ToString();
                _222.Opacity = 100;
                _22.Opacity = 100;
                _2.Opacity = 100;
                t2.Opacity = 100;
                t12.Opacity = 100;
                t22.Opacity = 100;

            }
            catch
            {
                 _222.Opacity = 0;
                _22.Opacity = 0;
                _2.Opacity = 0;
                t2.Opacity = 0;
                t12.Opacity = 0;
                t22.Opacity = 0;

                
            }
            try
            {
                t13.Text = dt3.Rows[0]["ТВдень"].ToString();
                t23.Text = dt3.Rows[0]["ТВночі"].ToString();
                _333.Opacity = 100;
                _33.Opacity = 100;
                _3.Opacity = 100;
                t3.Opacity = 100;
                t13.Opacity = 100;
                t23.Opacity = 100;

            }
            catch
            {
                 _333.Opacity = 0;
                _33.Opacity = 0;
                _3.Opacity = 0;
                t3.Opacity = 0;
                t13.Opacity = 0;
                t23.Opacity = 0;

                
            }
            try
            {
                t14.Text = dt4.Rows[0]["ТВдень"].ToString();
                t24.Text = dt4.Rows[0]["ТВночі"].ToString();
                _444.Opacity = 100;
                _44.Opacity = 100;
                _4.Opacity = 100;
                t4.Opacity = 100;
                t14.Opacity = 100;
                t24.Opacity = 100;

            }
            catch
            {
                 _444.Opacity = 0;
                _44.Opacity = 0;
                _4.Opacity = 0;
                t4.Opacity = 0;
                t14.Opacity = 0;
                t24.Opacity = 0;

                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}

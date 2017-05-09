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
    /// Логика взаимодействия для Adminka.xaml
    /// </summary>
    public partial class Adminka : Window
    {



        //ServerConnector scServerConnector = new ServerConnector(ipAdr,PortNumber);
        ServerConnector scServerConnector = new ServerConnector();
        public Adminka()
        {

            InitializeComponent();
        }

        private void l1(object sender, RoutedEventArgs e)
        {
            string strSQLRequest = "SELECT * FROM City";
            DataTable dt1 = scServerConnector.exequteSQLRequest(strSQLRequest);
            Combobox1.SelectedIndex = 0;
            List<string> list = dt1.AsEnumerable().Select(r => r.Field<string>("Місто")).ToList();
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            // ... Assign the ItemsSource to the List.
            Combobox1.ItemsSource = list;

        }
        private void l2(object sender, RoutedEventArgs e)
        {
            string strSQLRequest = "SELECT * FROM Situation";
            DataTable dt2 = scServerConnector.exequteSQLRequest(strSQLRequest);
            Combobox2.SelectedIndex = 0;
            List<string> list = dt2.AsEnumerable().Select(r => r.Field<string>("Ситуація")).ToList();
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;
            // ... Assign the ItemsSource to the List.
            Combobox2.ItemsSource = list;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dp.Text.Equals(""))
                MessageBox.Show("Ви не вибрали дату");
            if (TempD.Text.Equals(""))
                MessageBox.Show("Поле Температура вдень пуста");
            if (TempN.Text.Equals(""))
                MessageBox.Show("Поле Температура вночі пуста");
            else
            {
                const string quote = "'";
                string buf1 = quote + dp.Text + quote;
                string buf2 = quote + TempD.Text + quote;
                string buf3 = quote + TempN.Text + quote;
                string buf4 = Combobox1.Text;
                buf4 = buf4.Replace(" ", "");
                string buf5 = Combobox2.Text;
                buf5 = buf5.Replace(" ", "");
                try
                {
                    int test1 =  (Convert.ToInt32(TempD.Text));
                    int test2 =  (Convert.ToInt32(TempN.Text));
                {
                if (Convert.ToInt32(TempD.Text) <= 60 && Convert.ToInt32(TempD.Text) >= -90 &&
                    Convert.ToInt32(TempN.Text) <= 60 && Convert.ToInt32(TempN.Text) >= -90)
                {
                    string strSQLRequest = "INSERT INTO POGODA (Дата,ТВдень,ТВночі,Місто,Ситуація)" + "VALUES(" + buf1 + "," + buf2 + "," + buf3 + "," + "N" + quote + buf4 + quote + "," + "N" + quote + buf5 + quote + ")";
                    scServerConnector.exequteSQLRequest(strSQLRequest);
                    MessageBox.Show("Успішно записано в БД!");
                }
                else
                {
                    MessageBox.Show("Вкажіть градуси в межах -90 - + 60!");
                
                }
                }
                }
                catch
                {
                    MessageBox.Show("Помилка вводу температури. Мабуть, введений текст!");
                }

            }
        }

        
    }
}

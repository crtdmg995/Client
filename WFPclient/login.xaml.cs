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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        //ServerConnector scServerConnector = new ServerConnector(ipAdr,PortNumber);
        ServerConnector scServerConnector = new ServerConnector();
        public login()
        {
            InitializeComponent();
        }
        private void t1_TextChanged(object sender, TextChangedEventArgs e)
        {          
        }
        private void t2_TextChanged(object sender, TextChangedEventArgs e)
        { 
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string bufl,bufp;
            string strSQLRequest = "SELECT * FROM admin";
            DataTable dt1 = scServerConnector.exequteSQLRequest(strSQLRequest);
            bufl = dt1.Rows[0]["Логін"].ToString();
            string strSQLRequest1 = "SELECT * FROM admin";
            DataTable dt2 = scServerConnector.exequteSQLRequest(strSQLRequest1);
            bufp = dt2.Rows[0]["Пароль"].ToString();
            if (t1.Text != bufl)
            {
                MessageBox.Show("Ви Ввели не вірний логін");
                return;
            }
            else if (t2.Password !=bufp)
            {
                MessageBox.Show("Ви Ввели не вірний Пароль");
                return;
            }
                    new Adminka().Show();
                    Close();
        }
        }
    }

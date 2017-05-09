using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Net;
using System.Data;
using System.Net.Sockets;
using System.IO;
using System.Data.SqlClient;
using Client;

namespace WFPclient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        //ServerConnector scServerConnector = new ServerConnector(ipAdr,PortNumber);
        ServerConnector scServerConnector = new ServerConnector();
        DispatcherTimer timer = new DispatcherTimer();
        public System.Windows.Threading.DispatcherTimer connect = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            connect.Start();
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            slider1.Value += 0.5;
        }
        private void Choose(object sender, RoutedEventArgs e)
        {
            new Choose_City().Show();
            Close();
        }
        private void Lviv(object sender, RoutedEventArgs e)
        {
            new Lviv().Show();
            Close();
        }
        private void Resorts(object sender, RoutedEventArgs e)
        {
            new resorts().Show();
            Close();
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            new login().Show();
            Close();
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}

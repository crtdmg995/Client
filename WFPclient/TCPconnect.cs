using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Client
{
    class ServerConnector
    {
        private String IPadress;
        private int portNumber;
        private TcpClient client;
        private BinaryFormatter binaryFormatter;
        private NetworkStream stream;


        public ServerConnector()
        {
            setIPport("127.0.0.1", 2200);
        }
        public ServerConnector(String IPadr, int PortN)
        {
            setIPport(IPadr, PortN);
        }

        ~ServerConnector()
        { }

        public void setIPport(string IPadrr, int portN)
        {
            IPadress = IPadrr;
            portNumber = portN;
        }

        public DataTable exequteSQLRequest(string strRequestText)
        {
            DataTable dtRequestResoult;
            dtRequestResoult = new DataTable();

            try
            {
                client = new TcpClient(IPadress, portNumber);
                binaryFormatter = new BinaryFormatter();
                stream = client.GetStream();
                binaryFormatter.Serialize(stream, strRequestText);
                dtRequestResoult = (DataTable)binaryFormatter.Deserialize(stream);
            }
            catch (Exception)
            {

                MessageBox.Show("Сервер не знайдено!", "Помилка");
                return dtRequestResoult;
            }
            return dtRequestResoult;
        }
    }
}

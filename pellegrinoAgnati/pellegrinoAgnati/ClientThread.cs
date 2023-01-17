using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pellegrinoAgnati
{
    public class ClientThread 
    {
        TcpClient client;
        public NetworkStream stream;
        Byte[] data;
        public ClientThread(TcpClient Client)
        {
            this.client = Client;
        }

        public void run()
        {
            stream = client.GetStream();
            while (true)
            {
                Byte[] data = new byte[256];
                String responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                MessageBox.Show(responseData);
                
            }
        }
    }
}

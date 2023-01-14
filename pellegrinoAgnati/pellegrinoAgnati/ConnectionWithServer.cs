using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace pellegrinoAgnati
{
    public class ConnectionWithServer
    {
       /*  private TcpClient? client;
         private Int32 porta = 8080;
         private NetworkStream? stream;

        public void Connection(String server, String nomePlayer) //stabilisce la connessione con il server
        {
            try
            {
                client = new TcpClient(server, porta);
                stream=client.GetStream();

                Console.WriteLine("Connessione stabilita");
                send(nomePlayer + "è pronto alla connessione");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.Read();
        }
        
        public void send(string messaggio)  //invio del messaggio al client
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(messaggio);

            stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", messaggio);
        }

        public void receive() //ricezione del messaggio del server
        {
            Byte[] data = new byte[256];
            String responseData = String.Empty;

            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
        }

        public void closeConnection() //chiude completamente la connessione
        {
            stream.Close();
            client.Close();
        }*/

        
    }
}

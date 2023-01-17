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
         private static TcpClient client;
         private Int32 porta = 8080;
         public static NetworkStream stream;
        ClientThread ct;

        public ConnectionWithServer()
        {

        }

        public void Connection(String nomePlayer) //stabilisce la connessione con il server
        {
            try
            {
                client = new TcpClient();
                client.Connect("localhost", porta);
                //ct = new ClientThread(client);
                stream = client.GetStream();

                //ct.run();

                send("connected:" + nomePlayer);
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
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(messaggio + "\n");

            stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", messaggio);
        }

        public void closeConnection() //chiude completamente la connessione
        {
            stream.Close();
            client.Close();
        }

        
    }
}

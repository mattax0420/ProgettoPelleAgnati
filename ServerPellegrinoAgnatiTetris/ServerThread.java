import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketTimeoutException;


public class ServerThread extends Thread{
    
    public boolean connected = false;

    public void Connessione() throws IOException   {
        shared istance=shared.getInstance(); 
        ServerSocket sersock = new ServerSocket(8080); 
        Socket sock;
        while(true){
            try {
                    
                System.out.println("Server pronto alla connessione");
                sock = sersock.accept();

                mySocket ms=new mySocket(sock);
                if(istance.addSocket(ms)){
                    clientThread ct=new clientThread(ms);
                    ct.start();
                }

                connected = true;
                //receive();
                sersock.close();
            }
            catch (SocketTimeoutException ex) {
                sersock.close();
                connected = false;
            }
        }  
    }
    
    /*public void receive() throws IOException {
        //if (connected = true)  
        String risposta=input.nextLine();
        System.out.println(risposta);
    }

    public void send(String text) {
        if (connected == false) return;
        output.println(text);
        output.flush();
    }

    public void close() {
        input.close();
        output.close();
    }*/
}
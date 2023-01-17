import java.io.IOException;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketTimeoutException;
import java.util.Scanner;


public class ServerThread extends Thread{
    
    public boolean connected = false;
        private PrintWriter output;
        private Scanner input;


    public void Connessione() throws IOException   {
        shared istance=shared.getInstance(); 
        ServerSocket sersock = new ServerSocket(8080);
        Socket sock = new Socket();
        System.out.println("Server pronto alla connessione");
        while(true){
            try {
                    
                sock = sersock.accept();

                mySocket ms=new mySocket(sock);
                if(istance.addSocket(ms)){
                    clientThread ct=new clientThread(ms);
                    ct.start();
                }

                connected = true;
                //receive();
            }
            catch (SocketTimeoutException ex) {
                sersock.close();
                connected = false;
            }
        }  
    }
    
    public void receive() throws IOException {
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
    }
}
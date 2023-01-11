import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketTimeoutException;
import java.util.Scanner;


public class Server {
    
    public int timeOut = 60;
    public boolean connected = false;
    private PrintWriter output;
    private Scanner input;
    private ServerSocket sersock;

    public Server() throws IOException {
        try {
        sersock = new ServerSocket(8080);        
        sersock.setSoTimeout(timeOut * 1000);
        System.out.println("Server pronto alla connessione");
        Socket sock = sersock.accept();
        OutputStream ostream = sock.getOutputStream();
        output = new PrintWriter(ostream, true);
        InputStream istream = sock.getInputStream();
        input = new Scanner(istream);
        connected = true;
        receive();
        sersock.close();
        }
        catch (SocketTimeoutException ex) {
            sersock.close();
            connected = false;
        }
    }
    
    public void receive() throws IOException {
        //if (connected = true)  
        System.out.println(input.nextLine());
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
    public static void main(String[] args) throws IOException{
        Server server = new Server();
    }
}
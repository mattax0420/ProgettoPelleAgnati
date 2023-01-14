import java.io.IOException;

public class ServerTCP {
    public static void main(String[] args) throws IOException{
        ServerThread server = new ServerThread();
        server.Connessione();  
    }
}

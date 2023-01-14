import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class clientThread extends Thread{
    mySocket _socket=null;
    BufferedReader in;
    
    public clientThread(mySocket socket) throws IOException
    {
        _socket=socket;
        in =new BufferedReader(new InputStreamReader(_socket.socket.getInputStream()));
    }

    @Override
    public void run() {
        
        shared inst=shared.getInstance();
        String ricevuto="";
        boolean cicla=true;
        int cont=0;
        while (cicla) {
            try {
                ricevuto = in.readLine();
                if(ricevuto != null){ 
                    System.out.println(_socket.id+" ha ricevuto : " + ricevuto);
                    if (ricevuto.equals("END")){ 
                        _socket.close();
                        cicla=false;
                        break;
                    }
                   
                    String[] messSplit=ricevuto.split(":");
                    if(messSplit[0].equals("punteggio")){
                        cont++;
                        _socket.punteggio=Integer.parseInt(messSplit[1]);
                    }
                    if(cont==2){
                            int punt1=0;
                            int punt2=0;
                            punt1=shared.getInstance().sockets.get(1).punteggio;
                            punt2=shared.getInstance().sockets.get(2).punteggio;
                            String vinto="Congratulazioni, hai vinto";
                            String perso="Mi dispiace, hai perso";

                            if(punt1>punt2){
                                shared.getInstance().sockets.get(1).out.println(vinto);
                                shared.getInstance().sockets.get(2).out.println(perso);
                            }
                            else{
                                shared.getInstance().sockets.get(1).out.println(perso);
                                shared.getInstance().sockets.get(2).out.println(vinto);
                            }
                    }
                }
            } catch (IOException e) {
               //connessione chiusa
               break;   //e vado a rimuovere la socket
            }
        }

        inst.removeSocket(_socket);            

    }
}

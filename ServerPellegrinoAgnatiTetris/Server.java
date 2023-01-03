import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.Inet4Address;
import java.net.InetAddress;

public class Server{
    public static void main(String[] args){
        try{
            DatagramSocket socketFirstPlayer=new DatagramSocket(/*porta Giocatore 1 */); //aperatura della socket con il giocatore 1
            
            byte[] bufferFirstPlayer=new byte[1500];
            DatagramPacket packetFirstPlayer=new DatagramPacket(bufferFirstPlayer,bufferFirstPlayer.length);
            packetFirstPlayer.setAddress(InetAddress.getByName(/*indirizzo IP giocatore 1*/));
            socketFirstPlayer.receive(packetFirstPlayer);
            String messFirstPlayer=new String(packetFirstPlayer.getData());
            
            
            DatagramSocket socketSecondPlayer=new DatagramSocket(/*porta Giocatore 2 */); //aperatura della socket con il giocatore 2
            
            byte[] bufferSecondPlayer=new byte[1500];
            DatagramPacket packetSecondPlayer=new DatagramPacket(bufferSecondPlayer,bufferSecondPlayer.length); 
            packetSecondPlayer.setAddress(InetAddress.getByName(/*indirizzo IP giocatore 2*/));
            socketSecondPlayer.receive(packetSecondPlayer);
            String messSecondPlayer=new String(packetSecondPlayer.getData());
            
            int pointsFirstPlayer;
            int pointsSecondPlayer;
            
            //controllo se i messaggi contengono il punteggio
            if(messFirstPlayer.startsWith("Punteggio:")){ 
                pointsFirstPlayer=Integer.valueOf(messFirstPlayer.substring(10)); 
            }

            if(messSecondPlayer.startsWith("Punteggio:")){
                pointsSecondPlayer=Integer.valueOf(messSecondPlayer.substring(10)); 
            }

            String rispostaFirstPlayer;
            String rispostaSecondPlayer;


            //confronto tra punteggio del giocatore 1 e quello del giocatore 2
            if(pointsFirstPlayer > pointsSecondPlayer){   //manca il cast da string a int
                rispostaFirstPlayer= "Congratulazioni Giocatore 1, hai vinto con un punteggio di " + pointsFirstPlayer + ":)";
                rispostaSecondPlayer= "Mi dispiace Giocatore 2, ma sei lo sconfitto :(";
            }  
            else{
                rispostaFirstPlayer= "Mi dispiace Giocatore 1, ma sei lo sconfitto :(";
                rispostaSecondPlayer= "Congratulazioni Giocatore 2, hai vinto con un punteggio di " + pointsSecondPlayer + ":)";
            }
            
            //Estrazione di indirizzi e porte di entrambi i giocatori
            InetAddress responseAddressFirstPlayer=packetFirstPlayer.getAddress(); //Giocatore 1
            int responsePortFirstPlayer=packetFirstPlayer.getPort(); //Giocatore 1
            InetAddress responseAddressSecondPlayer=packetSecondPlayer.getAddress(); //Giocatore 2
            int responsePortSecondPlayer=packetSecondPlayer.getPort(); //Giocatore 2
            
            //invio risposta al gicoatore 1
            bufferFirstPlayer=rispostaFirstPlayer.getBytes();

            packetFirstPlayer=new DatagramPacket(bufferFirstPlayer,bufferFirstPlayer.length);
            packetFirstPlayer.setAddress(responseAddressFirstPlayer);
            packetFirstPlayer.setPort(responsePortFirstPlayer);
            socketFirstPlayer.send(packetFirstPlayer); //invio della risposta
            socketFirstPlayer.close(); //chiusura socket

            //invio risposta al giocatore 2
            bufferSecondPlayer=rispostaSecondPlayer.getBytes();

            packetSecondPlayer=new DatagramPacket(bufferSecondPlayer,bufferSecondPlayer.length);
            packetSecondPlayer.setAddress(responseAddressSecondPlayer);
            packetSecondPlayer.setPort(responsePortSecondPlayer);
            socketSecondPlayer.send(packetSecondPlayer); //invio della risposta
            socketSecondPlayer.close(); //chiusura socket
        }
        catch(Exception e){
            e.printStackTrace();
        }
    }
}
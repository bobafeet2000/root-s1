using System;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Client
    {
        public NetClient netclient;
        public NetPeerConfiguration Config;
        //public static NetIncomingMessage incmsg;
        //public static NetOutgoingMessage outmsg;

        public Client() // envoie d'une demande de connexion
        {
            //Mode DiscoveryResponse messages
            Config = new NetPeerConfiguration(Message.connectstring);
            Config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse);

            //Emission signal
            netclient = new NetClient(Config);
            netclient.Start();
            netclient.DiscoverLocalPeers(Message.useport);
        }

        public int Readmsg(int x)
        {
            NetIncomingMessage msg;
            int x2=0;

            while ((msg = netclient.ReadMessage()) != null)
            {
                switch (msg.MessageType)
                {
                    case NetIncomingMessageType.DiscoveryResponse:
                        netclient.Connect(msg.SenderEndPoint);
                        Game.peer = true;
                        break;
                    case NetIncomingMessageType.Data:                       
                        x2 = msg.ReadInt32();
                        NetOutgoingMessage sendMsg = netclient.CreateMessage();
                        sendMsg.Write(x);                 
                        netclient.SendMessage(sendMsg,msg.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                        break;
                    default:
                        break;
                }
                
            }
            return x2;
        }
    }
}

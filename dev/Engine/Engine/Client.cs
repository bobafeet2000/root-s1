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

        public void Readmsg()
        {
            NetIncomingMessage msg;
            int a;

            while ((msg = netclient.ReadMessage()) != null)
            {
                switch (msg.MessageType)
                {
                    case NetIncomingMessageType.DiscoveryResponse:
                        Game.peer = true;
                        break;
                    default:

                        break;
                }
                //Server.Recycle(msg);
            }

        }
    }
}

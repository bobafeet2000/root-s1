using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Engine
{
    public class Host
    {
        public NetServer Server; //Le serveur
        public NetPeerConfiguration Config; //La config serveur
        //static NetIncomingMessage incmsg; //messages entrant
        //public static NetOutgoingMessage outmsg; //message sortant


        public Host() // création du Host et démarrage écoute
        {
            Config = new NetPeerConfiguration(Message.connectstring);
            Config.Port = Message.useport;
            Server = new NetServer(Config);
            Server.Start();
        }

        public void Readmsg()
        {
            NetIncomingMessage msg;
            while ((msg = Server.ReadMessage()) != null)
            {
                switch (msg.MessageType)
                {
                    case NetIncomingMessageType.DiscoveryRequest:

                        // Create a response and write some example data to it
                        NetOutgoingMessage response = Server.CreateMessage();
                        response.Write("Galaga");                       

                        // Send the response to the sender of the request
                        Server.SendDiscoveryResponse(response, msg.SenderEndPoint);
                        Game.peer = true;
                        break;
                    case NetIncomingMessageType.VerboseDebugMessage:
                    case NetIncomingMessageType.DebugMessage:
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.ErrorMessage:
                    default:

                        break;
                }
                Server.Recycle(msg);
            }
        
        }

    }
}

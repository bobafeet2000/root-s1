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

        public int Readmsg(int x)
        {
            int x2 = 0;
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
                    case NetIncomingMessageType.Data:
                        x2 = msg.ReadInt32();
                        NetOutgoingMessage sendMsg = Server.CreateMessage();
                        sendMsg.Write(x);
                        Server.SendMessage(sendMsg, msg.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);
                        break;
                    default:

                        break;
                }
                Server.Recycle(msg);
            }
            return x2;
        
        }

        public void Sendmsg(int x)
        {
            NetOutgoingMessage sendMsg = Server.CreateMessage();

            //sendMsg.Write("Hello");
            sendMsg.Write(x);

            Server.SendMessage(sendMsg,Server.Connections[0], NetDeliveryMethod.ReliableOrdered);
        }

        public void Stop()
        {
            Server.Shutdown("bye");
        }

    }
}

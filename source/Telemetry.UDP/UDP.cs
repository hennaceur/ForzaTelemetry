﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry.UDP
{
    public class UDP
    {
        private static void UDPListener()
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(11000))
                {
                    string loggingEvent = "";
                    while (true)
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any source.
                        var receivedResults = await udpClient.ReceiveAsync();
                        loggingEvent += Encoding.ASCII.GetString(receivedResults.Buffer);
                    }
                }
            });
        }
    }
}

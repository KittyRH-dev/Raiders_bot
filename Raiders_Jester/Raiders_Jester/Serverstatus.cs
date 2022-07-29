using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;


namespace Raiders_Jester
{
    public class Serverstatus
    {
        public static string serverstat_dcsserver;
        public static void Serverping_DCSServer()
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                string address = YamlSerialization.ipaddress;
                int port = Convert.ToInt32(YamlSerialization.port);
                
                if (tcpClient.ConnectAsync($"{address}", port).Wait(1000))
                {

                    serverstat_dcsserver = YamlSerialization.onlinemessage;
                    tcpClient.Close();
                }

                else
                {

                    serverstat_dcsserver = YamlSerialization.offlinemessage;
                }
            }

            
            
            

            



        }


    }



}

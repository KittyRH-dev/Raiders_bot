using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;


namespace Raiders_Jester
{
    public class Serverstatus
    {
        public static string serverstat_dcsserver;
        public static string ipaddress = Convert.ToString(YamlSerialization.ipaddress);
        public static int port = Convert.ToInt32(YamlSerialization.port);
        

        

       

        
        


        public static async void Serverping_DCSServer()
        {
            TcpClient tcpClient = new TcpClient();
            

            if (tcpClient.ConnectAsync(IPAddress.Parse(ipaddress), port).Wait(1000))
            {
                
                serverstat_dcsserver = "332nd Raiders Server is online";
                tcpClient.Close();
            }

            else
            {
                
                serverstat_dcsserver = "332nd Raiders Server is offline";
            }



        }


    }



}

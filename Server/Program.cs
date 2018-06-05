using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        //static void StartServer()
        //{
        //    IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 5656);
        //    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        //    sock.Bind(ipEnd);
        //    sock.Listen(100);
        //    Socket clientSock = sock.Accept();
        //    string fileName = "test.txt";// "Your File Name"; 
        //    string filePath = @"C:\FT\";//Your File Path;
        //    byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
        //    byte[] fileData = File.ReadAllBytes(filePath + fileName);
        //    byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
        //    byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
        //    fileNameLen.CopyTo(clientData, 0);
        //    fileNameByte.CopyTo(clientData, 4);
        //    fileData.CopyTo(clientData, 4 + fileNameByte.Length);
        //    clientSock.Send(clientData);
        //    clientSock.Close(); 
        //}

        static void StartServer(int portNum , string clientip , string message )
        {
            //--------- wanted port number = 8000 and ipaddress of device is ipaddress of network -------------------------//
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(clientip), portNum); 
      
            try
            {
                if (!clientSocket.Connected)
                {
                    clientSocket.Connect(iep);
                }

                clientSocket.Send(Encoding.UTF8.GetBytes(message));
               // clientSocket.Disconnect(true);
                clientSocket.Close();
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //You need to close the send code
               
        }
        catch (Exception ex)
        {
            throw ex;
          

        }
           
  
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Client port number :");
            int portNum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Client IP address of wireless :");
            string clientIP=Console.ReadLine();
            string word;
            string sendAgain = "y";
            while (sendAgain == "y")
            {
                 Console.WriteLine("Enter wanted message to send to Client");
                 word = Console.ReadLine();
                 StartServer(portNum , clientIP, word);
                 Console.WriteLine("press 'y' to continue or 'n' to terminate");
                 sendAgain = Console.ReadLine();
            }
            return;
            
        }

        /*static void Main(string[] args)
        {
            StartServer();
           

        }

        static void StartServer()
        {

            Console.WriteLine("Enter Client port number :");
            int portNum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Client IP address of wireless :");
            string clientIP = Console.ReadLine();
            string message;
            string sendAgain = "y";
            while (sendAgain == "y")
            {
                Console.WriteLine("Enter wanted message to send to Client");
                message = Console.ReadLine();

                //--------- wanted port number = 8000 and ipaddress of device is ipaddress of network -------------------------//
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(clientIP), portNum);

                try
                {
                    if (!clientSocket.Connected)
                    {
                        clientSocket.Connect(iep);
                    }

                    clientSocket.Send(Encoding.UTF8.GetBytes(message));
                   // clientSocket.Disconnect(true);
                    clientSocket.Close();
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //You need to close the send code
                  
                }
                catch (Exception ex)
                {
                    throw ex;
                  
                }
              

                Console.WriteLine("press 'y' to continue or 'n' to terminate");
                sendAgain = Console.ReadLine();
            }
        
 
  
        }
        */
        
    }
}

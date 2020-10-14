using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientServeur
{
    public class Client
    {
        private TcpClient _tcpClient;
        private Thread _threadClient;

        public Client()
        {

            //this._threadClient = new Thread(new ThreadStart(ThreadClientLoop));
            //this._threadClient.Start();
            ThreadClientLoop();
        }

        private void ThreadClientLoop ()
        {
            try
            {
                //while (this._threadClient.IsAlive) {
                IPAddress localHost = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                IPEndPoint iPeP = new IPEndPoint(localHost, 0);
                this._tcpClient = new TcpClient(iPeP);
                Byte[] readBuffer = new Byte[1024];
                int nbOctet;
                StringBuilder sB = new StringBuilder();

                NetworkStream nS = this._tcpClient.GetStream();

                if (nS.CanRead)
                {
                    do
                    {
                        nbOctet = nS.Read(readBuffer, 0, readBuffer.Length);
                        sB.AppendFormat("{0}", Encoding.UTF8.GetString(readBuffer, 0, nbOctet));
                    } while (nS.DataAvailable);

                    Debug.WriteLine(sB.ToString());
                }
                else
                {
                    Debug.WriteLine("Impossible de lire sur le NetworkStream.");
                }
                nS.Close();
                this._tcpClient.Close();
                this._threadClient.Abort();
                //}
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}

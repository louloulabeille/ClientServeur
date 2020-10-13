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
                Byte[] readBuffer = new Byte[1024];
                int nbOctet;
                StringBuilder sB = new StringBuilder();

                IPAddress localHost = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                Socket sok = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
                sok.Connect(ip, 8580);

                do
                {
                    nbOctet = sok.Receive(readBuffer);
                    sB.AppendFormat("{0}",Encoding.UTF8.GetString(readBuffer));
                    Debug.WriteLine(sB.ToString());
                } while (nbOctet != 0);

                Debug.WriteLine(sB.ToString());

                /*
                IPEndPoint iPeP = new IPEndPoint(ip, 8580);
                Debug.WriteLine(iPeP.Address.ToString());
                this._tcpClient = new TcpClient(iPeP);

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
                */

            }
            catch (ArgumentNullException aNE)
            {
                Debug.WriteLine("Message: {0}",aNE.Message);
                Debug.WriteLine("Source: {0}", aNE.Source);
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                Debug.WriteLine("Message: {0}", aOORE.Message);
                Debug.WriteLine("Source: {0}", aOORE.Source);
            }
            catch (SocketException sE)
            {
                Debug.WriteLine($"Message :{sE.Message}\nCode erreur :{sE.ErrorCode}");
                Debug.WriteLine("Source: {0}",sE.Source);
            }
            catch(ObjectDisposedException oDE)
            {
                Debug.WriteLine("Message: {0}", oDE.Message);
                Debug.WriteLine("Source: {0}", oDE.Source);
            }
            catch (NotSupportedException nSE)
            {
                Debug.WriteLine("Message: {0}", nSE.Message);
                Debug.WriteLine("Source: {0}", nSE.Source);
            }
            catch (InvalidOperationException iOE)
            {
                Debug.WriteLine("Message: {0}", iOE.Message);
                Debug.WriteLine("Source: {0}", iOE.Source);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Message: {0}", e.Message);
                Debug.WriteLine("Source: {0}", e.Source);
            }
        }
    }
}

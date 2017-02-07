using System;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace Sockets {
    class ServerSocket {
        private Socket serverSocket;
        /// <summary>
        /// Create a new ServerSocket object
        /// </summary>
        /// <param name="port">The port to bind</param>
        public ServerSocket(int port) {
            this.serverSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            try {
                this.serverSocket.Bind(new IPEndPoint(0, port));
                this.serverSocket.Listen(10);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                this.serverSocket.Close();
                return;
            }
        }
        /// <summary>
        /// Wait and accept any connection
        /// </summary>
        /// <returns>A Socket to connect to</returns>
        public Socket Accept() => this.serverSocket.Accept();
        /// <summary>
        /// Close the socket
        /// </summary>
        public void Close() => this.serverSocket.Close();
    }
}

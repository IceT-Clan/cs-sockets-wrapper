using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace Sockets {
    class ClientSocket {
        private Socket socket;
        private int port;
        private IPAddress host;
        private IPEndPoint endPoint;
        private Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// Create a new ClientSocket object
        /// </summary>
        /// <param name="host">A host to connect to</param>
        /// <param name="port">The port to connect to</param>
        public ClientSocket(string host, int port) {
            //this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            this.port = port;
            if(!IPAddress.TryParse(host, out this.host)) {
                this.host = Dns.GetHostEntry(host).AddressList[0];
            }
            this.endPoint = new IPEndPoint (this.host,this.port);
        }
        /// <summary>
        /// Create a ClientSocket object with another ClientSocket object
        /// </summary>
        /// <param name="socket">a ClientSocket object</param>
        public ClientSocket(Socket socket) {
            this.socket = socket;
        }
        /// <summary>
        /// Connect to the server
        /// </summary>
        /// <returns>The succeess of the connection</returns>
        public bool Connect() {
            try {
                //this.socket.Connect(this.host, this.port);
                this.socket.Connect(this.endPoint);
            } catch (Exception e) {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Check if data is available at the socket
        /// </summary>
        /// <returns>Return the number of byte available</returns>
        public Int32 DataAvailable() => this.socket.Available;
        /// <summary>
        /// Send a single byte to the socket
        /// </summary>
        /// <param name="data">The byte to send</param>
        public void Write(Int32 data) {
            Byte[] msg = new Byte[1];
            msg[0] = (Byte)data;
            this.socket.Send(msg);
        }
        /// <summary>
        /// Write a string to the socket
        /// </summary>
        /// <param name="data">The data to send</param>
        public void Write(string data) => this.socket.Send(this.encoding.GetBytes(data));
        /// <summary>
        /// Read a single byte from the socket
        /// </summary>
        /// <returns>The number of bytes recieved</returns>
        public Int32 Read() {
            Byte[] rcvbuffer = new Byte[1];
            this.socket.Receive(rcvbuffer);
            return (Char)rcvbuffer[0];
        }
        /// <summary>
        /// Read a specified number of bytes from the socket into a buffer
        /// </summary>
        /// <param name="buffer">The storeage location for the bytes</param>
        /// <param name="lenght">The number of bytes to recieve</param>
        /// <returns>The number of bytes recieved</returns>
        public Int32 Read(Byte[] buffer, Int32 lenght) => this.socket.Receive(buffer, lenght, SocketFlags.None);
        /// <summary>
        /// Receive bytes from server until a newline is hit
        /// </summary>
        /// <returns>String with bytes from server (without newline)</returns>
        public String ReadLine() {
            String rcv = "";
            Byte[] rcvbuffer = new Byte[1] { 0 };

            while (rcvbuffer[0] != '\n') {
                this.socket.Receive(rcvbuffer);
                ASCIIEncoding enc = new ASCIIEncoding(); // TODO check if this can be omitted
                rcv += this.encoding.GetString(rcvbuffer);
            }

            return rcv.Substring(0, rcv.Length - 1);
        }
        /// <summary>
        /// Close the socket
        /// </summary>
        public void Close() => this.socket.Close();
        /// <summary>
        /// Dispose the socket
        /// </summary>
        public void Dispose() => this.socket.Dispose();
    }
}
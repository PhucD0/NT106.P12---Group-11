global using global::System;
global using global::System.Collections.Generic;
global using global::System.Drawing;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
global using global::System.Windows.Forms;
using System.Net.Sockets;

namespace Client
{
    public partial class Client : Form
    {
        // KHAI BAO HERE
        private NetworkStream stream;
        private TcpClient client;

        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        // Ket noi den server
        private void ConnectToServer()
        {
            try
            {
                //// code k?t n?i ??n server here
                
                // B?t ??u l?ng nghe t? server
                ListenAndDisplayImages();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"K?t n?i th?t b?i: {ex.Message}");
            }
        }
        
        // L?ng nghe v� hi?n th? d? li?u h�nh ?nh b�n ph�a server
        private void ListenAndDisplayImages()
        {
            new Thread(() =>
            {
                try
                {
                    while (client.Connected)
                    {
                        // ??c d? li?u ?nh t? server v� hi?n th? l�n picturebox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i l?ng nghe d? li?u t? server: {ex.Message}");
                }
            }).Start();
        }

        // X? l� input v� g?i t?i server
        private void SendInputData(byte[] inputData)
        {
            // code something here
        }
        // H�m SendInputData ???c g?i qua c�c s? ki?n c?a chu?t v� b�n ph�m

        // Luu dia chi IP v� port
        private void btnSaveIP_Click(object sender, EventArgs e)
        {

        }

        // Th�m, x�a ??a ch? IP v� port


        // Ghi l?i l?ch s? c�c l?n k?t n?i


        // G?i file qua server
    }
}

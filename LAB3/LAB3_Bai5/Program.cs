using System;
using System.Windows.Forms;

namespace LAB3_Bai5
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Kh?i ch?y form Server trên m?t lu?ng riêng
            Thread serverThread = new Thread(() =>
            {
                Application.Run(new Server.Server());
            });
            serverThread.SetApartmentState(ApartmentState.STA); // C?n thi?t cho các ?i?u khi?n WinForms
            serverThread.Start();

            // Kh?i ch?y form Client trên lu?ng chính
            Application.Run(new Client.Client());
        }

    }
}
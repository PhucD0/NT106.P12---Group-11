using System;
using System.Windows.Forms; 

namespace LAB3_Bai4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(new Bai4());
            //Server serverForm = new Server();
            //Client clientForm = new Client();
            //Application.Run(new MultiFormContext(serverForm, clientForm));
            //Application.Run(new Server());
            //Application.Run(new Client());
        }

        //public class MultiFormContext : ApplicationContext
        //{
        //    private int openForms;

        //    public MultiFormContext(params Form[] forms)
        //    {
        //        openForms = forms.Length;

        //        foreach (var form in forms)
        //        {
        //            form.FormClosed += (s, args) =>
        //            {
        //                if (Interlocked.Decrement(ref openForms) == 0)
        //                    ExitThread();
        //            };

        //            form.Show();
        //        }
        //    }
        //}
    }
}
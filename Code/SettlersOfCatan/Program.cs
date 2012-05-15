using System;
using System.Windows.Forms;

namespace SettlersOfCatan
{
    internal static class Program
    {
#if DEBUG
        public const bool Debug = true;
#else
        public const bool Debug = false;
#endif

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Start());
        }
    }
}
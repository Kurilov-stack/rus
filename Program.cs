using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovoiProject
{
    static class Program
    {   
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            string pathWrongDocument = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\Wrong paronims.txt");
            using (StreamWriter sw = new StreamWriter(pathWrongDocument, false, System.Text.Encoding.Default))
            {
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
            
        }
    }
}

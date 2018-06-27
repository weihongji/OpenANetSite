using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            string site = "linux01";
            string browser = "chrome";
            if (args != null && args.Length > 0)
            {
                site = args[0].Trim().ToLower();
                if (args.Length >= 2)
                {
                    browser = args[1].Trim().ToLower();
                    if (browser.Equals("ie"))
                    {
                        browser = "iexplore";
                    }
                }
            }

            string server = System.Configuration.ConfigurationManager.AppSettings["server"];
            if (String.IsNullOrEmpty(server))
            {
                server = "localhost:8080";
            }
            server = server.Trim();
            string url = String.Format("http://{0}/{1}/servlet/adminLogin.sdi", server, site);
            string parameters = url;
            if (browser.Equals("chrome")) {
                parameters = url + " -new-tab";
            }

            Process process = new Process();
            process.StartInfo.FileName = browser;
            process.StartInfo.Arguments = url;
            process.Start();
            process.Close();
        }
    }
}

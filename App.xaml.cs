using Paragon.Plugins.ScreenCapture;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace ScreenSnippet
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // mandatory filename arg - grabbed output will write to this file.
            if (e.Args.Length == 1 && !string.IsNullOrEmpty(e.Args[0]))
            {
                string filename = e.Args[0];
                var win = new SnippingWindow(filename);
                win.Show();
            }
            // or Openfin port and app UUID
            else if(e.Args.Length == 3 && !string.IsNullOrEmpty(e.Args[0]) && !string.IsNullOrEmpty(e.Args[1]) && !string.IsNullOrEmpty(e.Args[2]))
            {
                int port;

                if(!int.TryParse(e.Args[0], out port) || port < 1 || port > 65535)
                {
                    throw new Exception("Invalid port number.");
                }

                var uuid = e.Args[1];
                var topic = e.Args[2];

                var win = new SnippingWindow(port, uuid, topic);
                win.Show();
            }
            else
            {
                throw new Exception("Invalid command line arguments.");
            }
        }
    }
}

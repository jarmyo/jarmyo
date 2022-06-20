using System;
using System.Windows;
using System.IO;
namespace SecretDrawer
{
    public partial class App : Application
    {
        public App()
        {            
           //TODO: update
        }
        internal static Data.SecretContext? DataContext;

        public static string Pass { get; internal set; } = "SecretDrawer";

        protected override async void OnStartup(StartupEventArgs e)
        {            
            //TODO: get the global pass
            //TODO: Check updates
            //TODO: Check logs
            Directory.CreateDirectory(AppContext.BaseDirectory + "\\Data");
            DataContext = new Data.SecretContext();
            if (!File.Exists(AppContext.BaseDirectory + @"\Data\Secrets.db"))
            {
                if (!await DataContext.Database.EnsureCreatedAsync())
                {
                    MessageBox.Show("Fail Creating Database context");
                    return;
                }
            }

            var w = new MainWindow();
            w.Show();
        }
    }
}
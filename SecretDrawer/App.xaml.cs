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
        
        protected override async void OnStartup(StartupEventArgs e)
        {            
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
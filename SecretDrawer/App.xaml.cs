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

        protected override async void OnStartup(StartupEventArgs e)
        {            
            //TODO: get the global pass
            //TODO: Check updates
            //TODO: Check logs
            Directory.CreateDirectory(AppContext.BaseDirectory + "\\Data");
            if (await GlobalCode.InitDataBase())
            {
                var w = new MainWindow();
                w.Show();
            }            
        }
    }
}
using System.Linq;
using System.Windows;

namespace SecretDrawer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MoveWindowToRightCorder();
            LoadItems();
        }

        private void LoadItems()
        {
            SecretsList.Children.Clear();
            foreach (var secret in from item in GlobalCode.GetSecrets()
                                   let secret = new Controls.SecretButton(item)
                                   select secret)
            {
                SecretsList.Children.Add(secret);
            }
        }

        private void MoveWindowToRightCorder()
        {
            this.Height = SystemParameters.PrimaryScreenHeight - 50;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height - 50;
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
        }

        private void AddNewSecret(object sender, RoutedEventArgs e)
        {
            var newScret = new NewSecretWindow();
            if (newScret.ShowDialog() == true)
            {
                //update the list
                LoadItems();
            }
            //Open add new window.
        }

        private void ConfigApplication(object sender, RoutedEventArgs e)
        {
            //open config window
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            //flush clipboard.
            //Save last window location and size on registry.
            App.Current.Shutdown();
        }

        private void HideApplication(object sender, RoutedEventArgs e)
        {
            //move to tray
        }
    }
}
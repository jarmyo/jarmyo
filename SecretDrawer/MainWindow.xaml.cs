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
                                   let secretButton = new Controls.SecretButton(item)
                                   select secretButton)
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
            var newSecretWindow = new NewSecretWindow();
            if (newSecretWindow.ShowDialog() == true)
                if (newSecretWindow.NewSecret != null)
                    SecretsList.Children.Add(new Controls.SecretButton(newSecretWindow.NewSecret));
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
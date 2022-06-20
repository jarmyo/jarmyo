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
            if (App.DataContext != null && App.DataContext.Secrets != null)
            {
                App.DataContext.Secrets.RemoveRange(App.DataContext.Secrets);
                App.DataContext.SaveChanges();
                var data = GlobalCode.CreateSecret("Github", "1234512345_12345_12345");
                App.DataContext.Secrets.Add(data);
                App.DataContext.SaveChanges();

                foreach (var secret in from item in App.DataContext.Secrets.OrderBy(s => s.Order).ToList()
                                       let secret = new Controls.SecretButton(item)
                                       select secret)
                {
                    SecretsList.Children.Add(secret);
                }
            }
        }

        private void MoveWindowToRightCorder()
        {
            this.Height = SystemParameters.PrimaryScreenHeight;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height;
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
        }
    }
}
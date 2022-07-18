using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SecretDrawer
{
    /// <summary>
    /// Interaction logic for NewSecretWindow.xaml
    /// </summary>
    public partial class NewSecretWindow : Window
    {
        private string valueTitle { get; set; } = string.Empty;
        private string valueContent { get; set; } = string.Empty;
        private int valueOrder { get; set; } = 0;

        public NewSecretWindow()
        {
            InitializeComponent();
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(textTitle.Text))
            {
                //validation msg
                return false;
            }
            
            return true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //validate
            //update
            if (Validate())
            {
                GlobalCode.CreateSecret(valueTitle, valueContent, valueOrder);
                this.DialogResult = true;
                this.Close();
            }            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

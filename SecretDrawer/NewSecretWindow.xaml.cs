using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Windows;
using System.Windows.Controls;
namespace SecretDrawer
{
    public partial class NewSecretWindow : Window
    {
        internal Data.Secret? NewSecret { get; set; } = null;
        private string ValueTitle { get { return textTitle.Text; } }
        private string ValueContent
        {
            get { return textSecret.Password; }
        }
        private int ValueOrder;        
        private bool ShowPassword { get; set; } = false;
        public NewSecretWindow() => InitializeComponent();
        private bool Validate()
        {
            var result = true;
            if (string.IsNullOrWhiteSpace(ValueTitle))
            {
                TitleValidation.Visibility = Visibility.Visible;
                result = false;
            }
            if (string.IsNullOrWhiteSpace(ValueContent))
            {
                SecretValidation.Visibility = Visibility.Visible;
                result = false;
            }
            if (string.IsNullOrWhiteSpace(textOrder.Text)) textOrder.Text = "1";
                                        
            if (!int.TryParse(textOrder.Text, out ValueOrder))
            {
                result = false;
                OrderValidation.Visibility = Visibility.Visible;
            }

            return result;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {                
                NewSecret = GlobalCode.CreateSecret(ValueTitle, ValueContent, ValueOrder);
                this.DialogResult = true;
                this.Close();
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            ShowPassword = true;
            SecretPasswordText.Text = textSecret.Password;
            SecretPasswordText.Visibility = Visibility.Visible;
        }
        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowPassword = false;
            SecretPasswordText.Text = string.Empty;
            SecretPasswordText.Visibility = Visibility.Collapsed;
        }
        private void TextSecret_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ShowPassword)
            {
                SecretPasswordText.Text = textSecret.Password;
            }
            SecretValidation.Visibility = Visibility.Collapsed;
        }
        private void TextTitle_TextChanged(object sender, TextChangedEventArgs e) => TitleValidation.Visibility = Visibility.Collapsed;
        private void TextOrder_TextChanged(object sender, TextChangedEventArgs e) => OrderValidation.Visibility = Visibility.Collapsed;
    }
}
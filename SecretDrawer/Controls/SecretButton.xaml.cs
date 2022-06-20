using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SecretDrawer.Controls
{
    public partial class SecretButton : Grid
    {
        public SecretButton()
        {
            InitializeComponent();
        }

        private readonly Data.Secret secretItem = new();
        public SecretButton(Data.Secret secret)
        {
            secretItem = secret;
            InitializeComponent();
            Title = secret.Title;
            Color = secret.Color;
        }
        public string? Title
        {
            get => secretItem.Title;
            set => TitleLabel.Text = value;
        }
        public string? Color
        {
            get => secretItem.Color;
            set
            {
                Background = new System.Windows.Media.SolidColorBrush(FromHex(value ?? "000000"));
            }
        }
        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Get the secret hash            
            var c =  GlobalCode.DecryptText( secretItem.Content, secretItem.Hash);
            MessageBox.Show(c);
            //Clipboard.SetText(c);
            //decrypt with global secret.
            //copy to clipboard.
            //start timer to destroy clipboard.

        }
        private static System.Windows.Media.Color FromHex(string hex)
        {
            var r = Convert.ToByte(hex.Substring(0, 2), 16);
            var g = Convert.ToByte(hex.Substring(2, 2), 16);
            var b = Convert.ToByte(hex.Substring(4, 2), 16);
            return System.Windows.Media.Color.FromRgb(r, g, b);
        }
    }
}
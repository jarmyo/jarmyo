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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecretDrawer.Controls
{
    /// <summary>
    /// Interaction logic for SecretButton.xaml
    /// </summary>
    public partial class SecretButton : Grid
    {
        public SecretButton()
        {
            InitializeComponent();
        }
        private string _title = string.Empty;
        public string? Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value ?? string.Empty;
                TitleLabel.Text = _title;
            }
        }
        public string? Color { get; set; }
        public string? Hash { get; set; }
    }
}

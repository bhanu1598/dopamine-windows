using Dopamine.Core.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dopamine.Controls
{
    public partial class FullLogo : UserControl
    {
        public Brush Accent
        {
            get { return (Brush)GetValue(AccentProperty); }

            set { SetValue(AccentProperty, value); }
        }

        public static readonly DependencyProperty AccentProperty = 
            DependencyProperty.Register(nameof(Accent), typeof(Brush), typeof(FullLogo), new PropertyMetadata(null));

        public string ApplicationName
        {
            get { return ProductInformation.ApplicationName; }
        }

        public FullLogo()
        {
            InitializeComponent();
        }
    }
}

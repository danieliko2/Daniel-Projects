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

namespace GameO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            image.Margin = new Thickness(186, 104, 0, 0);
            

        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            image.Height = image.Height - 2;
            image.Width = image.Width - 2;
            button.IsEnabled = true;
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Thickness magrin = image.Margin;
            image.Margin = new Thickness(-171, -442, 0, 0);
            image.Height = image.Height + 2;
            image.Width = image.Width + 2;
            player.Margin = new Thickness(186, 104, 0, 0);

        }
    }
}

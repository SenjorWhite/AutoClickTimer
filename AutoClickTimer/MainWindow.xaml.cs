using WindowsInput;
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

namespace AutoClickTimer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;
            Width = 200;
            Height = 200;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            InputSimulator sim = new InputSimulator();
            sim.Mouse.MoveMouseBy(3600, 1000);
            //sim.Mouse.LeftButtonClick();
        }
    }
}


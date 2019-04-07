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
using System.Runtime.InteropServices;
using Point = System.Drawing.Point;
using System.Threading;

namespace AutoClickTimer
{
    /// <summary>
    /// MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;
            timePicker.Text = new DateTime().ToLongDateString();

            new Thread(() =>
            {
                while(true)
                {
                    Point p = new Point();
                    GetCursorPos(ref p);

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        Position.Content = p.X + ", " + p.Y;
                    }));

                    Thread.Sleep(100);
                }
            }).Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (buttonActivate.Content.Equals("Activate"))
            {
                buttonActivate.Content = "Waiting...";
                enableConfiguration(false);
                DateTime triggerTime = DateTime.Parse(timePicker.Text);
                double XPixelPosition = double.Parse(textBoxXPosition.Text);
                double YPixelPosition = double.Parse(textBoxYPosition.Text);

                new Thread(() =>
                {
                    TimeSpan remainTime;

                    while (true)
                    {
                        remainTime = triggerTime - DateTime.Now;

                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            countDownLabel.Content = remainTime.ToString();
                        }));

                        if (triggerTime < DateTime.Now)
                        {
                            triggerClick(XPixelPosition, YPixelPosition);
                            enableConfiguration(true);
                            break;
                        }

                        Thread.Sleep(200);
                    }
                }).Start();
            }
        }

        private void enableConfiguration(bool isEnable)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                buttonActivate.IsEnabled = isEnable;
                textBoxXPosition.IsEnabled = isEnable;
                textBoxYPosition.IsEnabled = isEnable;
                timePicker.IsEnabled = isEnable;
            }
            ));
        }

        private void setButtonContent(string content)
        {
            Dispatcher.Invoke(new Action(()=>
            {
                buttonActivate.Content = content;
            }));
        }

        private void triggerClick(double x, double y)
        {
            double XScaleRate = 65535.0 / 1919.0;
            double YScaleRate = 65535.0 / 1079.0;

            InputSimulator sim = new InputSimulator();
            sim.Mouse.MoveMouseTo(XScaleRate * x, YScaleRate * y);
            sim.Mouse.LeftButtonClick();
            setButtonContent("Activate");
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(ref Point lpPoint);
    }
}


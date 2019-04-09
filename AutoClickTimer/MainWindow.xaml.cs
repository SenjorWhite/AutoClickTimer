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

        const double XScaleRate = 65535.0 / 1919.0;
        const double YScaleRate = 65535.0 / 1079.0;
        List<ClickEvent> clickEventList = new List<ClickEvent>();

        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;
            timePicker.Text = new DateTime().ToLongDateString();
            clickEventDataGrid.ItemsSource = clickEventList;

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

        private void logOutClickEvent(ClickEvent clickEvent)
        {
            System.Console.Write(clickEvent.triggerButton.ToString());
            System.Console.Write(",");
            System.Console.Write(clickEvent.triggerClick.ToString());
            System.Console.Write(",");
            System.Console.Write(clickEvent.waitTime.ToString());
            System.Console.Write(",");
            System.Console.Write(clickEvent.X.ToString());
            System.Console.Write(",");
            System.Console.Write(clickEvent.Y.ToString());
            System.Console.WriteLine();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (buttonActivate.Content.Equals("Activate"))
            {
                clickEventDataGrid.CommitEdit();

                buttonActivate.Content = "Waiting...";
                enableConfiguration(false);
                DateTime triggerTime = DateTime.Parse(timePicker.Text);
                //double XPixelPosition = double.Parse(textBoxXPosition.Text);
                //double YPixelPosition = double.Parse(textBoxYPosition.Text);

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
                            triggerClick();
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
                //textBoxXPosition.IsEnabled = isEnable;
                //textBoxYPosition.IsEnabled = isEnable;
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

        private void triggerClick()
        {

            for(int i = 0; i < clickEventList.Count; i++)
            {
                ClickEvent currentEvnet = clickEventList[i];

                Dispatcher.BeginInvoke(new Action(()=> 
                {
                    clickEventDataGrid.Items.MoveCurrentTo(currentEvnet);
                    logOutClickEvent(currentEvnet);
                    DataGridRow row = (DataGridRow)clickEventDataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                    row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }));

                invokeClickEvent(currentEvnet);
            }

            //sim.Mouse.MoveMouseTo(XScaleRate * x, YScaleRate * y);
            //sim.Mouse.LeftButtonClick();
            setButtonContent("Activate");
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(ref Point lpPoint);

        private void invokeClickEvent(ClickEvent clickEvent)
        {
            if (clickEvent.triggerButton == MouseButton.Wait)
            {
                Thread.Sleep(clickEvent.waitTime * 1000);
            }
            else
            {
                double targetX = clickEvent.X * XScaleRate;
                double targetY = clickEvent.Y * YScaleRate;
                InputSimulator sim = new InputSimulator();
                sim.Mouse.MoveMouseTo(targetX, targetY);
                if (clickEvent.triggerButton == MouseButton.Left)
                {
                    if (clickEvent.triggerClick == ClickMode.Single)
                    {
                        sim.Mouse.LeftButtonClick();
                    }
                    else if (clickEvent.triggerClick == ClickMode.Double)
                    {
                        sim.Mouse.LeftButtonDoubleClick();
                    }
                }
                else if (clickEvent.triggerButton == MouseButton.Right)
                {
                    if (clickEvent.triggerClick == ClickMode.Single)
                    {
                        sim.Mouse.RightButtonClick();
                    }
                    else if (clickEvent.triggerClick == ClickMode.Double)
                    {
                        sim.Mouse.RightButtonDoubleClick();
                    }
                }
            }
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            this.Height = 700;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            this.Height = 270;
        }

        private void AddNewClickEventButton_Click(object sender, RoutedEventArgs e)
        {
            clickEventList.Add(new ClickEvent()
            {
                triggerButton = MouseButton.Left,
                triggerClick = ClickMode.Single,
                X = 0,
                Y = 0
            });
            clickEventDataGrid.Items.Refresh();
        }

        private void AddWaitEventButton_Click(object sender, RoutedEventArgs e)
        {
            clickEventList.Add(new ClickEvent()
            {
                triggerButton = MouseButton.Wait,
                triggerClick = ClickMode.Wait,
                X = -1,
                Y = -1
            });
            clickEventDataGrid.Items.Refresh();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClickTimer
{
    public enum MouseButton
    {
        Left,
        Right,
        Wait
    }

    public enum ClickMode
    {
        Single,
        Double,
        None
    }

    public class ClickEvent
    {
        public MouseButton triggerButton { get; set; }
        public ClickMode triggerClick { get; set; }
        public int waitTime { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}

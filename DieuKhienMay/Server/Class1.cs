using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlServer
{
    public class InputEvent
    {
        public int EventType { get; set; }
        public int Button { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Delta { get; set; }
        public int Key { get; set; }
        public int ModifierKeys { get; set; } // Thêm trường để lưu trạng thái các phím tổ hợp
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTimer
{
    /// <summary>
    /// Класс аругмента тика таймера
    /// </summary>
     public class TimerTickEventArgs : EventArgs
    {
        /// <summary>
        /// Оставшееся время до окончания
        /// </summary>
        public TimeSpan Interval { get;private set; }
        internal TimerTickEventArgs(TimeSpan interval)
        {
            this.Interval = interval;
        }
    }
}

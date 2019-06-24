using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTimer
{
    /// <summary>
    /// Ошибка отсудсвия интервала
    /// </summary>
    public class IntervalNullException : Exception
    {
        public IntervalNullException() { }
        public IntervalNullException(string message) : base(message) { }
        public IntervalNullException(string message, Exception inner) : base(message, inner) { }
        protected IntervalNullException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}


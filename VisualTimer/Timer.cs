using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace VisualTimer
{
    /// <summary>
    /// Делагат еденицы времени таймера
    /// </summary>
    /// <param name="sender">объект таймера</param>
    /// <param name="e">Аргумент еденицы времени</param>
    public delegate void TimerTick(object sender, TimerTickEventArgs e);
    /// <summary>
    /// Действие при окончании таймера
    /// </summary>
    public delegate void TickFinaly(object sender, EventArgs e);
    /// <summary>
    /// Класс визуального таймера
    /// </summary>
    public class Timer : DispatcherTimer
    {
        /// <summary>
        /// Вывод разницы времени
        /// </summary>
        public event TimerTick OneTimerTick;

        /// <summary>
        /// Действие при завершении таймера
        /// </summary>
        /// 
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public event TickFinaly Tick;
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово

        private double Res;

        /// <summary>
        /// Время до завершения таймера
        /// </summary>
        public new TimeSpan? Interval { get; set; }

        /// <summary>
        /// Консруктор для иницализации визуального таймера
        /// </summary>
        /// <param name="interval">Время до завершения</param>
        public Timer(TimeSpan interval)
        {
            this.Interval = interval;
            base.Interval = new TimeSpan(0, 0, 0,1);
            base.Tick += this.TickVisual;
        }

        /// <summary>
        /// Консруктор для иницализации визуального таймера
        /// </summary>
        public Timer()
        {
            base.Interval = new TimeSpan(0, 0, 0, 1);
            base.Tick += this.TickVisual;
        }

        /// <summary>
        /// Запуск таймера
        /// </summary>
        public new void Start()
        {
            if (Interval is null)
                throw new IntervalNullException("Для запуска таймера необходимо указать интервал");
            else
                base.Start();
        }

        private void TickVisual(object sender, EventArgs e)
        {
            int Rasn = Convert.ToInt32(Interval.Value.TotalSeconds - this.Res);
            OneTimerTick(this, new TimerTickEventArgs(new TimeSpan(0, 0, 0,Rasn)));
            if (Rasn == 0)
            {
                Tick(this, new EventArgs());
                this.Stop();
            }
            this.Res+=1;
        }
    }
}

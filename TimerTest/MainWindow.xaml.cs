﻿using System;
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
using VisualTimer;

namespace TimerTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer Timers = new Timer(new TimeSpan(0,0,0,20,20));

        public MainWindow()
        {
            InitializeComponent();
            Timers.Tick += this.Timers_Tick;
            Timers.OneTimerTick += this.Timers_OneTimerTick;
           
        }

        private void Timers_OneTimerTick(object sender, TimerTickEventArgs timerTickEventArgs) => this.Timer.Text = $"Осталось {timerTickEventArgs.Interval.TotalSeconds} секунд";
        private void Timers_Tick(object sender, EventArgs eventArgs) => this.Timer.Text = "Все";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Timers.Start();
        }
    }
}

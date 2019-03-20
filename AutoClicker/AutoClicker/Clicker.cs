using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace AutoClicker
{
    public class Clicker
    {
        public bool ClickerActive = false;
        private int Amount { get; set; }
        private bool IsInfinite { get; set; }
        private int Interval { get; set; }
        private static Timer aTimer;

        public void StartClicker()
        {
            ReadConfig();
            if (ClickerActive == true)
            {
                ClickerLogic();
            }
            else
            {
                return;
            }
        }

        public void StopClicker()
        {
            Amount = 0;
            ClickerActive = false;
            aTimer.Enabled = false;
        }

        private void ReadConfig()
        {
            var settings = new Settings();
            string[] config = settings.ReadConfig();
            AssignConfig(config);
        }

        private void AssignConfig(string[] configs)
        {
            Amount = int.Parse(configs[0]);
            IsInfinite = bool.Parse(configs[1]);
            if (IsInfinite)
            {
                Amount = int.MaxValue;
            }
            Interval = int.Parse(configs[2]);
        }

        private void ClickerLogic()
        {
            SetTimer();
            if (ClickerActive)
            {
                aTimer.Enabled = true;
                do
                {
                    Amount--;
                }
                while (Amount > 0);
            }
            if (!ClickerActive)
            {
                aTimer.Enabled = false;
            }
        }

        private void SetTimer()
        {
            aTimer = new Timer(Interval);
            aTimer.Elapsed += TimerTick;
            aTimer.AutoReset = true;
            aTimer.Enabled = false;
        }

        private void TimerTick(object source, ElapsedEventArgs e)
        {
            VirtualMouse.LeftClick();
        }
    }
}

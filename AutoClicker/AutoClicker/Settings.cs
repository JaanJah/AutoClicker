using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    public class Settings
    {
        private string _clickAmount { get; set; }
        private bool? _clickInfinite { get; set; }
        private string _clickInterval { get; set; }

        public Settings(string clickAmount, bool? clickInfinite, string clickInterval)
        {
            _clickAmount = clickAmount;
            _clickInfinite = clickInfinite;
            _clickInterval = clickInterval;
        }

        public void WriteToConfig()
        {
            
        }

        public void ReadConfig()
        {

        }

        public void CreateConfig()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    public class Clicker
    {
        public bool ClickerActive = false;

        public void StartClicker()
        {
            ReadConfig();
            if (ClickerActive == true)
            {
                //TODO: Use config and start clicking
            }
            else
            {
                return;
            }
        }

        public void StopClicker()
        {
            ClickerActive = false;
        }

        private void ReadConfig()
        {
            //TODO: Read config.txt file here
        }
    }
}

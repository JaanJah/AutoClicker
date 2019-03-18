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
            if (ClickerActive == true)
            {
                //Start clicking
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
    }
}

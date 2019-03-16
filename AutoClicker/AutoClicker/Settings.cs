using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClicker
{
    public class Settings
    {
        private string Amount { get; set; }
        private bool? IsInfinite { get; set; }
        private string Interval { get; set; }
        private string Path = "./config.txt";

        public void SaveConfig(string amount, bool? isInfinite, string interval)
        {
            Amount = amount;
            IsInfinite = isInfinite;
            Interval = interval;
            WriteToConfig();
        }

        public string[] ReadConfig()
        {
            string[] settings = new string[3];
            string setting = string.Empty;
            if (File.Exists(Path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(Path))
                    {
                        setting = sr.ReadLine();
                        settings = setting.Split(' ');
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                CreateConfigFile(Path);
            }
            return settings;
        }

        private void WriteToConfig()
        {
            if (File.Exists(Path))
            {
                try
                {
                    using (var sw = new StreamWriter(Path))
                    {
                        sw.WriteLine(Amount + " " + IsInfinite + " " + Interval);
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                CreateConfigFile(Path);
            }
        }

        private void CreateConfigFile(string path)
        {
            File.Create(path).Dispose();
            WriteToConfig();
        }
    }
}

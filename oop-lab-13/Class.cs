using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_13
{
    static class Task6
    {

        public static void ActionAtDay(string logfile, string date)
        {
            string infoFromLogs = "";
            using (StreamReader stream = new StreamReader(logfile))
            {
                while (true)
                {
                    if (stream.EndOfStream)
                    {
                        break;
                    }
                    infoFromLogs = stream.ReadLine();
                    if (infoFromLogs.Contains(date))
                    {
                        Console.WriteLine(infoFromLogs);
                    }
                }
            }
        }

        public static void ActionBetwen(string logfile, DateTime min, DateTime max)
        {
            string infoFromLogs = "";
            DateTime resolt = new DateTime();
            using (StreamReader stream = new StreamReader(logfile))
            {

                while (true)
                {
                    if (stream.EndOfStream)
                    {
                        break;
                    }

                    infoFromLogs = stream.ReadLine();

                    if (infoFromLogs.Contains("Последняя активность:") || infoFromLogs.Contains("Последнее изменение:") && infoFromLogs != "~")
                    {
                        string[] vs = infoFromLogs.Split('/');

                        foreach (var i in vs)
                            if (DateTime.TryParse(i, out resolt))
                            {
                                if (resolt > min && resolt < max)
                                {
                                    Console.WriteLine(infoFromLogs);
                                }
                            }
                    }
                }
            }
        }

        public static void InformationByWord(string logfile, string Word)
        {
            string infoFromLogs = "";
            using (StreamReader stream = new StreamReader(logfile))
            {
                while (true)
                {
                    if (stream.EndOfStream)
                    {
                        break;
                    }
                    infoFromLogs = stream.ReadLine();
                    if (infoFromLogs.Contains(Word))
                    {
                        Console.WriteLine(infoFromLogs);
                    }
                }
            }
        }

        public static void Count(string logfile)
        {
            string infoFromLogs = "";
            int counter = 0;
            using (StreamReader stream = new StreamReader(logfile))
            {
                while (true)
                {
                    if (stream.EndOfStream)
                    {
                        break;
                    }
                    infoFromLogs = stream.ReadLine();
                    if (infoFromLogs.Contains("Последняя активность:") || infoFromLogs.Contains("Последнее изменение:"))
                    {
                        counter++;
                    }

                }
            }
            Console.WriteLine(counter);

        }

        public static void OnlyAtHour(string logfile)
        {
            string infoFromLogs = "";
            DateTime resolt = new DateTime();
            string onlyAtHour = "";
            using (StreamReader stream = new StreamReader(logfile))
            {

                while (true)
                {
                    if (stream.EndOfStream)
                    {
                        break;
                    }

                    infoFromLogs = stream.ReadLine();

                    if (infoFromLogs.Contains("Последняя активность:") || infoFromLogs.Contains("Последнее изменение:") && infoFromLogs != "~")
                    {
                        string[] vs = infoFromLogs.Split('/');

                        foreach (var i in vs)
                            if (DateTime.TryParse(i, out resolt))
                            {
                                if (resolt.Date == DateTime.Now.Date && resolt.Hour > DateTime.Now.Hour - 1)
                                {
                                    onlyAtHour += infoFromLogs+"\n";
                                    Console.WriteLine(infoFromLogs);
                                }
                            }
                    }
                }
            }
            File.Delete(logfile);
            FileStream f=File.Create(logfile);
            f.Close();
            using (StreamWriter stream = new StreamWriter(logfile))
            {
                stream.WriteLine(onlyAtHour);
            }
        }
    }
}

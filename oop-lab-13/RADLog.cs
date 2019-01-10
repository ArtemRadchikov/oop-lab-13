using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_13
{
    static class RADLog
    {
        static readonly string logfile = "RADlogfile.txt";

        public static void GetInfoAndWriteToFile()
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Artem\Desktop");
            FileInfo file = new FileInfo(logfile);

            using (FileStream stream = file.Open(FileMode.Create)) { }

            writeInFile($"\t\tВсе файлы в каталоге {directory.FullName}:");
            writeInFile("");

            foreach (var files in directory.GetFiles().OrderBy(p => p.LastWriteTime))
            {
                writeInFile("\tИмя файла:  " + files.Name + "  Последнее изменение:  " + files.LastWriteTime+'\t' + files.FullName);
            }

            writeInFile("");
            writeInFile("\t\tПодкаталоги:");
            writeInFile("");

            foreach (var dir in directory.GetDirectories())
            {
                writeInFile("");
                writeInFile("Имя директории:  " + dir.Name + "  Последняя активность:  " +"/"+dir.LastAccessTime+"/" + '\t'+ dir.FullName);
                writeInFile("");

                foreach (var files in dir.GetFiles().OrderBy(p=>p.LastWriteTime))
                {
                    writeInFile("\tИмя файла:  "+files.Name+"  Последнее изменение:  "+"/" + files.LastWriteTime + "/"+'\t' + files.FullName);
                }
            }                       
        }

        public static void ReadInfoFromFile()
        {
            StreamReader stream = null;
            try
            {
                stream = new StreamReader(logfile);
                Console.WriteLine(stream.ReadToEnd());
            }
            catch
            {
                Console.WriteLine("Возникла проблема с чтение из файла RADLogs.txt");
            }
            finally
            {
                if(stream!=null)
                {
                    stream.Close();
                }
            }
        }

        //поиск информации
        public static void ActionsOnData()
        {
            Console.ReadKey();
            Console.Clear();
            string dataFromConsole;
            DateTime dateTime;

            do
            {
                dataFromConsole = Console.ReadLine();
            } while (!DateTime.TryParse(dataFromConsole, out dateTime));

            StreamReader stream = null;
            try
            {
                stream = new StreamReader(logfile);
                string info = stream.ReadToEnd();
                if (info.Contains(dataFromConsole))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Была активность данного числа в файлах: ");
                    Console.ResetColor();

                    var ArrayOfInformation = info.Split('~');
                    
                    foreach(string i in ArrayOfInformation.Where(p => p.Contains(dataFromConsole)))
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Не было активности данного числа");
                    Console.ResetColor();
                }
            }
            catch
            {
                Console.WriteLine("Возникла проблема с чтение из файла RADLogs.txt");
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
        

        private static void writeInFile(string Info)
        {
            StreamWriter stream = null;
            try
            {
                stream = new StreamWriter(logfile,true);
                                    
                    stream.WriteLine(Info+'~');
                
            }
            catch
            {
                Console.WriteLine("Возникла ошибка при записи в файл RADlogfile.txt");
            }
            finally
            {
                if(stream!=null)
                    stream.Close();
            }
        }
    }
}

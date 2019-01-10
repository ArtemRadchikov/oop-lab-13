using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            RADLog.GetInfoAndWriteToFile();
            RADLog.ReadInfoFromFile();
            //введите дату
            RADLog.ActionsOnData();
            Console.ReadKey();
            Console.Clear();

            RADDiskInfo.PrintDriveFreeSpace(@"c:\");
            RADDiskInfo.PrintDriveFormat(@"c:\");
            Console.ReadKey();
            Console.Clear();

            RADDiskInfo.PrintDriveFreeSpace(@"f:\");
            RADDiskInfo.PrintDriveFormat(@"f:\");
            RADDiskInfo.PrintCommonInformation();
            Console.ReadKey();
            Console.Clear();

            RADFileInfo.PrintInfo(RADFileInfo.WayToFile("RADlogfile.txt"));
            RADFileInfo.PrintDateOfCreation("RADlogfile.txt");
            Console.ReadKey();
            Console.Clear();

            RADDirInfo.CountOfDir(@"C:\Users\Artem\Desktop");
            RADDirInfo.CountOfFiles(@"C:\Users\Artem\Desktop");
            RADDirInfo.DateOfCreation(@"C:\Users\Artem\Desktop");
            RADDirInfo.PrintListOfParents(@"C:\Users\Artem\Desktop");

            Console.ReadKey();
            Console.Clear();

            RADFileManager.DoTask5a(@"f:\");

            Console.ReadKey();
            Console.Clear();

            RADFileManager.DoTask5b(@"f:\");

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("архивация и деархивация файлов.");
            RADFileManager.DoTask5c(@"f:\");

            Console.ReadKey();
            Console.Clear();

            Task6.ActionAtDay("RADlogfile.txt", "26.11.2018");
            Console.ReadKey();
            Console.Clear();

            Task6.ActionBetwen("RADlogfile.txt",new DateTime(2018,11,25),DateTime.Today);
            Console.ReadKey();
            Console.Clear();

            Task6.InformationByWord("RADlogfile.txt","Вал _ БГТУ");
            Console.ReadKey();
            Console.Clear();

            Task6.Count("RADlogfile.txt");
            Console.ReadKey();
            Console.Clear();

            Task6.OnlyAtHour("RADlogfile.txt");
            Task6.Count("RADlogfile.txt");

        }

    }
}

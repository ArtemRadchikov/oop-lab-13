using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_13
{
    static class RADDiskInfo
    {
        //a. свободном месте на диске 
        public static void PrintDriveFreeSpace(string directory)
        {
            DriveInfo driveInfo = new DriveInfo(directory);
            Console.WriteLine( directory+"свободное место : "+ driveInfo.TotalFreeSpace+"байт");
        }

        //    b.Файловой системе 
        public static void PrintDriveFormat(string directory)
        {
            DriveInfo driveInfo = new DriveInfo(directory);
            Console.WriteLine(directory + "формат : " + driveInfo.DriveFormat);
        }
        //    c.Для каждого существующего диска  - имя, объем, доступный объем, метка тома.

        public static void PrintCommonInformation()
        {
            foreach(var i in DriveInfo.GetDrives())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(i.Name);
                Console.ResetColor();
                Console.WriteLine("Метка тома: "+i.VolumeLabel+"\nТип тома:"+i.DriveType );

                Console.WriteLine("\nОбъем: "+i.TotalSize+"\nДоступно: "+i.AvailableFreeSpace);
            }
        }

        //    d.Продемонстрируйте работу класса

    }
}

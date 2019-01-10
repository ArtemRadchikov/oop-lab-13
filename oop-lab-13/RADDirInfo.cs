using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_13
{
    static class RADDirInfo
    {
        //a.Количестве файлов
        //    b.Время создания 
        //    c.Количестве поддиректориев
        //    d.Список родительских директориев 
        //    e.Продемонстрируйте работу класса
        public static void CountOfDir(string fullname)
        {
            Console.WriteLine("в директории fullname "+Directory.GetDirectories(fullname).Count() +" директорий") ;
        }
        public static void CountOfFiles(string fullname)
        {
            Console.WriteLine("в директории fullname " + Directory.GetFiles(fullname).Count() + " файлов");
        }

        public static void DateOfCreation(string fullname)
        {
            Console.WriteLine("директорий fullname был создан: " + Directory.GetCreationTime(fullname));
        }

        public static void PrintListOfParents(string fullname)
        {
            //Список родительских директориев
            Console.WriteLine("\nподкаталоги родительского директория\n");
            foreach (var i in Directory.GetParent(fullname).GetDirectories())
            {
                Console.WriteLine(i.Name);
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab_13
{
    static class RADFileInfo
    {

        //a.Полный путь  
        //    b.Размер, расширение, имя 
        //    c.Время создания 
        //    d. Продемонстрируйте работу класса

        public static string WayToFile(string name)
        {
            FileInfo fileInfo = new FileInfo(name);

            return fileInfo.FullName;
        }

        public static void PrintInfo(string fullName)
        {
            FileInfo fileInfo = new FileInfo(fullName);
            Console.WriteLine(fileInfo.Name+" Расширение: "+fileInfo.Extension+" Размер: "+ fileInfo.Length);
        }

        public static void PrintDateOfCreation(string fullName)
        {
            FileInfo fileInfo = new FileInfo(fullName);
            Console.WriteLine(fileInfo.Name+" дата cоздания: "+fileInfo.CreationTime);
        }
    }
}

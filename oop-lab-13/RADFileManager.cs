using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
//using System.IO.Compression.FileSystem;
//using Ionic.Zip;

namespace oop_lab_13
{
    static class RADFileManager
    {
        //static string 
        //Создать класс XXXFileManager.
        //    Набор методов определите самостоятельно.С его помощью выполнить следующие действия: 

        //        a.Прочитать список файлов и папок заданного диска.Создать директорий XXXInspect, 
        //        создать текстовый файл xxxdirinfo.txt и сохранить туда  информацию.
        //        Создать копию файла и переименовать его. 
        //    Удалить первоначальный файл
        public static void DoTask5a(string nameOfDriver)
        {
            DriveInfo driveInfo = new DriveInfo(nameOfDriver);
            DirectoryInfo directoryInfo = new DirectoryInfo(nameOfDriver);

            string nameOfFile=CreateDirAndFile(nameOfDriver);

            
            using (StreamWriter stream = new StreamWriter(nameOfFile, true))
            {
                stream.WriteLine(directoryInfo.FullName + "включает: \n");
                stream.WriteLine("\t\tДиректории:");

                foreach (var i in directoryInfo.GetDirectories())
                {
                    stream.WriteLine(i.Name);
                }

                stream.WriteLine("\t\tФайлы:");

                foreach (var i in directoryInfo.GetFiles())
                {
                    stream.WriteLine(i.Name);
                }
            }

            CopeAndDeleteAndRename(nameOfFile, nameOfDriver + @"\RADInspect");
        }

        public static string CreateDirAndFile(string fulnameOfDriver)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(fulnameOfDriver+ @"\RADInspect");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            //dirInfo.CreateSubdirectory(@"RADdir");
            var i=File.Create(dirInfo.FullName + @"\RADdirinfo.txt");
            i.Close();
            return dirInfo.FullName + @"\RADdirinfo.txt";

        }

        public static void CopeAndDeleteAndRename(string fullname,string dir)
        {
            string Copyname = fullname.Insert(fullname.Length - 4, "Copy");
            try
            {
                Console.WriteLine("Копирование");
                File.Copy(fullname, Copyname);
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var i in Directory.GetFiles(dir))
                {
                    Console.WriteLine(i);
                }
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Удаление");

                File.Delete(fullname);
                foreach (var i in Directory.GetFiles(dir))
                {
                    Console.WriteLine(i);
                }
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Переименовать");

                FileInfo fileInfo = new FileInfo(Copyname);
                string newname = fileInfo.FullName.Replace(fileInfo.Name, "renamed.txt");

                File.Move(Copyname, newname);
                foreach (var i in Directory.GetFiles(dir))
                {
                    Console.WriteLine(i);
                }
                Console.ResetColor();
            }
            catch
            {
                Console.WriteLine("Необходимо удалить папку");
            }
        }

        static public void DoTask5b(string nameOfDriver)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(nameOfDriver + @"\RADFiles");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            Console.WriteLine("Введите расширение");
            string input = Console.ReadLine();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Artem\Desktop");
                foreach (var i in dir.GetFiles())
                {
                    Console.WriteLine(i.Extension);
                    if (i.Extension == input)
                    {
                    //File.Create(dirInfo.FullName+i.Name)
                        i.CopyTo(dirInfo.FullName+@"\"+i.Name);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Файл не найден");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Результат копирования файлов:");
            foreach(var i in dirInfo.GetFiles())
            {
                Console.WriteLine(i.Name);
            }
            Console.ResetColor();


            try
            {
                Console.WriteLine("Результат перемещения каталога:");
                
                dirInfo.MoveTo(@"F:\RADInspect\"+dirInfo.Name);
            }
            catch
            {
                Console.WriteLine("ошибка в блоке премещения 5b line 152");
            }


            foreach (var i in Directory.GetFiles(@"F:\RADInspect"))
            {
                Console.WriteLine(i);
            }
            foreach (var i in Directory.GetDirectories(@"F:\RADInspect"))
            {
                Console.WriteLine(i);
            }
            Console.ResetColor();
            Console.ResetColor();
        }

        static public void DoTask5c(string name)
        {
            //try
            //{
            // ZipFile.CreateFromDirectory(@"F:\RADInspect\RADFiles", @"F:\RADInspect\RADFiles\resoult.zip");
            //}
            //catch(IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //ZipFile.ExtractToDirectory(@"F:\RADInspect\RADFiles\resoult.zip", @"F:\ExtractToDirectory");

            FastZip fz = new FastZip();
            fz.CreateEmptyDirectories = true;
            fz.CreateZip(@"F:\RADInspect\zipDriver.zip", @"F:\RADInspect\RADFiles", true, null, null);

            fz.ExtractZip(@"F:\RADInspect\zipDriver.zip", @"F:\ResoultRADZIP", null);
            //F:\ResoultRADZIP
            
            //DirectoryInfo directorySelected = new DirectoryInfo(@"F:\RADInspect\RADFiles");
            //Compress(directorySelected);

            //foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            //{
            //    Decompress(fileToDecompress);
            //}
        }

        public static void Compress(DirectoryInfo directorySelected)
        {
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);

                            }
                        }
                        FileInfo info = new FileInfo(@"F:\RADInspect\RADFiles" + "\\" + fileToCompress.Name + ".gz");
                        Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                        fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString());
                    }

                }
            }
        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }
    }
}

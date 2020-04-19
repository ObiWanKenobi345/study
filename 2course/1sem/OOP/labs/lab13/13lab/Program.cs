using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace lab13
{
    public delegate void Info(string info);
    class KDILog
    {
        private static int count = 0;       
        public void Write(string info)
        {
            count++;
            Console.WriteLine("Запись...");

            StreamWriter sw = File.AppendText(@"E:\folder\KDILog.txt");
            sw.WriteLine(info);
            sw.Close();
            Console.WriteLine("__________");
        }
        public void Count()
        {
            Console.WriteLine("Количество записей в файле: " + count);
        }
        public void Exercise6()
        {
            Console.WriteLine("За прошлый час:" + count);
            string[] readText = File.ReadAllLines(@"E:\folder\KDILog.txt");
            foreach (string str in readText)
            {
                string str2 = str.Substring(str.IndexOf("2017") + 5);
                string[] str3 = str2.Split(':');

                string time = Convert.ToString(DateTime.Now);
                time = time.Substring(time.IndexOf("2017") + 5);
                string[] time2 = time.Split(':');

                if (Convert.ToInt32(str3[0]) - 1 == Convert.ToInt32(time2[0]))
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
    class KDIDiskInfo
    {

        public event Info Write;
        DriveInfo E = new DriveInfo(@"E:\");
        DriveInfo C = new DriveInfo(@"C:\");

        public void PrintAccessMemory()
        {
            Console.WriteLine("Свободного места на диске E: " + E.TotalFreeSpace);
            string str = "PrintAccessMemory is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        public void PrintFileSystem()
        {
            Console.WriteLine("Формат ФС:" + E.DriveFormat);
            Console.WriteLine("Тип диска:" + E.DriveType);
            string str = "PrintFileSystem is called!!! Time: " + DateTime.Now;
            Write(str);
        }
        public void PrintInfoAboutDisks()
        {
            Console.WriteLine("Информация о диске C");
            Console.WriteLine("Имя: " + C.Name);
            Console.WriteLine("Объём: " + C.TotalSize);
            Console.WriteLine("Доступный объём: " + C.TotalFreeSpace);
            Console.WriteLine("Метка тома: " + C.VolumeLabel);
            Console.WriteLine();
            Console.WriteLine("Информация о диске E");
            Console.WriteLine("Имя: " + E.Name);
            Console.WriteLine("Объём: " + E.TotalSize);
            Console.WriteLine("Доступный объём: " + E.TotalFreeSpace);
            Console.WriteLine("Метка тома: " + E.VolumeLabel);
            string str = "PrintInfoAboutDisks is called!!! Time: " + DateTime.Now;
            Write(str);
        }
    }
    class KDIFileInfo
    {
        public event Info Write;
        FileInfo FI = new FileInfo(@"E:\folder\KDILog.txt");

        public void AllPath()
        {
            Console.WriteLine("Полный путь к файлу:" + FI.FullName);
            string str = "AllPath is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        public void PrintInfoAboutFile()
        {
            Console.WriteLine("Размер: " + FI.Length);
            Console.WriteLine("Расширение: " + FI.Extension);
            Console.WriteLine("Имя: " + FI.Name);
            string str = "PrintInfoAboutFile is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        public void DateCreate()
        {
            Console.WriteLine("Время создания: " + FI.CreationTime);
            string str = "DateCreate is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        
    }
    class KDIDirInfo
    {
        public event Info Write;
        DirectoryInfo DI = new DirectoryInfo(@"E:\folder\");
        
        public void CountFiles()
        {
            Console.WriteLine("Количество файлов в директории: " + DI.GetFiles().Length);
            string str = "CountFiles is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        public void DateCreate()
        {
            Console.WriteLine("Дата создания директории: " + DI.CreationTime);
            string str = "HowManyFiles is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        public void CountDirectory()
        {
            Console.WriteLine("Количество поддиректориев: " + DI.GetDirectories().Length);
            string str = "CountDirectory is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        public void ListParentDir()
        {
            Console.WriteLine("Список родительский директориев:");
            var dirs = DI.Parent.GetDirectories();
            foreach(var info in dirs)
            {
                Console.WriteLine(info.Name);
            }
            string str = "ListParentDir is called!!! Time:" + DateTime.Now;
            Write(str);
        }
    }
    class KDIFileManager
    {
        public event Info Write;

        public void Exercise1()
        {
            Console.WriteLine("Список файлов и каталогов диска E:");
            DirectoryInfo DI = new DirectoryInfo(@"E:\");
            var dirs = DI.GetDirectories();
            var files = DI.GetFiles();

            Directory.CreateDirectory(@"E:\folder\KDIInspect");
            if (!File.Exists(@"E:\folder\KDIInspect\KDIdirinfo.txt"))
            {
                File.Create(@"E:\folder\KDIInspect\KDIdirinfo.txt");
            }

            StreamWriter sw = new StreamWriter(@"E:\folder\KDIInspect\KDIdirinfo.txt");
                        
            
            foreach (var info in dirs)
            {
                Console.WriteLine(info.Name);
                sw.WriteLine(info.Name);
            }
            Console.WriteLine();
            foreach (var info in files)
            {
                Console.WriteLine(info.Name);
                sw.WriteLine(info.Name);
            }
            sw.Close();

            try
            {
                File.Copy(@"E:\folder\KDIInspect\KDIdirinfo.txt", @"E:\folder\KDIInspect\KDIdirsinfo.txt");
                File.Delete(@"E:\folder\KDIInspect\KDIdirinfo.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string str = "Exercise1 is called!!! Time:" + DateTime.Now;
            Write(str);
        } 
        public void Exercise2()
        {
            Directory.CreateDirectory(@"E:\folder\KDIFiles");
            DirectoryInfo FI = new DirectoryInfo(@"E:\folder\KDIInspect");
            var files = FI.GetFiles();
            foreach(var info in files)
            {
                if(info.Extension == ".bin")
                {
                    if (!File.Exists($@"E:\folder\KDIFiles\{info.Name}"))
                    {
                        File.Copy($@"E:\folder\KDIInspect\{info.Name}", $@"E:\folder\KDIFiles\{info.Name}");
                    }
                }               
            }

            string sourceDirectory = @"E:\folder\KDIFiles";
            string destinationDirectory = @"E:\folder\KDIInspect";

            try
            {
                Directory.Move(sourceDirectory, destinationDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string str = "Exercise2 is called!!! Time:" + DateTime.Now;
            Write(str);
        }
        public void ArchiveFiles()
        {
            try
            {
                string startPath = @"E:\folder\KDIFiles";
                string zipPath = @"E:\folder\result.zip";
                string extractPath = @"E:\folder\";

                ZipFile.CreateFromDirectory(startPath, zipPath);
                ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string str = "ArchiveFiles is called!!! Time:" + DateTime.Now;
            Write(str);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                KDILog log = new KDILog();

                KDIDiskInfo d = new KDIDiskInfo();
                d.Write += log.Write;
                d.PrintAccessMemory();
                d.PrintFileSystem();
                d.PrintInfoAboutDisks();

                KDIFileInfo f = new KDIFileInfo();
                f.Write += log.Write;
                f.AllPath();
                f.PrintInfoAboutFile();
                f.DateCreate();

                KDIDirInfo i = new KDIDirInfo();
                i.Write += log.Write;
                i.CountFiles();
                i.DateCreate();
                i.CountDirectory();
                i.ListParentDir();

                KDIFileManager m = new KDIFileManager();
                m.Write += log.Write;
                m.Exercise1();
                m.Exercise2();
                m.ArchiveFiles();
                Console.WriteLine();

                log.Count();
                log.Exercise6();
                                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("This file not exist");
            }
            Console.ReadKey();
        }
    }
}

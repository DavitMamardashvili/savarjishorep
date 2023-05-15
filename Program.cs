using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void example1()
        {
            // მეუბნება ფაილი სად არის რომელ ფოლდერში

            string idres = @"C:\Users\User\Desktop\mamarda1998\test1";

            string dirname = Path.GetDirectoryName(idres);

            Console.WriteLine(dirname);

        }

        static void example2()
        {
            //გამოაქ .პდფ გაფართოება მარა დაირექტორში არ ცვლის

            string idres = @"C:\Users\User\Desktop\mamarda1998\test1.txt";

            string getname = Path.ChangeExtension(idres, ".pdf");

            Console.WriteLine(getname);


        }

        static void example3()
        {
            //ქმნის ფოლდერს testdir სახელით

            string idres = @"C:\Users\User\Desktop\mamarda1998\testdir";

            DirectoryInfo dir = Directory.CreateDirectory(idres);

            Console.WriteLine(dir.CreationTime);

            DirectoryInfo d = new DirectoryInfo(dir.FullName);
            Console.WriteLine(d.Exists);

            string stratpath = @"C:\Users\User\Desktop\mamarda1998";
            Directory.Delete(stratpath, true);

            stratpath = @"C:\Users\User\Desktop\mamarda1998";

            string[] names = Directory.GetDirectories(stratpath);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }





            // მაკლია move 



        }


        static void example4()
        {
            string path = @"C:\Users\User\Desktop\mamarda1998\test1998";


            File.WriteAllText(path, string.Empty);
            File.AppendAllText(path, "gamarjoba genacvale");


        }
        public void hmw2()
        {

            DirectoryInfo dir1 = Directory.CreateDirectory(@"C:\Users\User\Desktop\test1dir1");

            File.WriteAllText(dir1.FullName + @"\testfile1.txt", string.Empty);

            File.AppendAllText(dir1.FullName + @"\testfile1.txt", "some apended txt" + Environment.NewLine);

            File.AppendAllText(dir1.FullName + @"\testfile1.txt", "wont thet in new line ...");

            DirectoryInfo dir2 = Directory.CreateDirectory(@"C:\Users\User\Desktop\test1dir2");

            foreach (FileInfo file in dir1.GetFiles())
            {
                string newPath = Path.Combine(dir2.FullName, file.Name);
                File.Move(file.FullName, newPath);
            }
        }

        public static void hmw1(string path)
        {

            string[] dir = Directory.GetDirectories(path);

            for (int i = 0; i < dir.Length; i++)
            {
                Console.WriteLine(dir[i].Split(@"\")[^1].ToString());
                Console.WriteLine();

                if (Directory.GetDirectories(dir[i]).Length > 0)
                {
                    hmw1(dir[i]);
                    

                }


            }
        }

        public static void PrintFilesAndFoldersRecursively(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                Console.WriteLine(directory);
                PrintFilesAndFoldersRecursively(directory);
            }
        }

        static void Main(string[] args)
        {


        
            
            
        }


   
      

        public static FileInfo FindLargestFileRecursively(string path)
        {
            FileInfo largestFile = null;
            long largestFileSize = 0;
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Length > largestFileSize)
                {
                    largestFileSize = fileInfo.Length;
                    largestFile = fileInfo;
                }
            }

            // Check files in subdirectories recursively
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                FileInfo largestInSubdir = FindLargestFileRecursively(directory);
                if (largestInSubdir != null && largestInSubdir.Length > largestFileSize)
                {
                    largestFileSize = largestInSubdir.Length;
                    largestFile = largestInSubdir;
                }
            }

            return largestFile;
        }


    }
}



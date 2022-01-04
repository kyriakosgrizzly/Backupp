using System;
using System.IO;


namespace Backup
{
    class Program
    {
        static void Main(string[] args)
        {

            string DirToCheck = args[0];
            string DesDir = args[1];
            string time = $"{args[2]} {args[3]}";

            DateTime Pasttime;
            if (!DateTime.TryParse(time, out Pasttime))
            {
                Console.WriteLine("wrong input");
                return;
            }


            Backup(DirToCheck, Pasttime, DesDir);
        }

        static void Backup(string path, DateTime PastTime, string destination)
        {
            if (Directory.Exists(path) && Directory.Exists(destination))
            {
                var files = Directory.GetFiles(path);

                foreach (var file in files)
                {
                    var CreationDate = File.GetCreationTime(file);
                    if (CreationDate.CompareTo(PastTime) > 0)
                    {
                        string name = Path.GetFileName(file);
                        string filedest = Path.Combine(destination, name);
                        File.Copy(file, filedest, true);
                    }
                }
            }
            else
            {
                Console.WriteLine("wrong folders");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Task05
{
    class BackupSystem
    {
        public static readonly string BACKUP_DIRECTORY = ".backup";
        public static readonly string CACHE_FILENAME = "cache.file";
        public static readonly int BACKUP_DELAY = 3000;

        public static void Run(string[] args)
        {
            if (app != null)
                return;
            app = new BackupSystem(args);
            app.Run();
            Console.WriteLine("App terminated. Press any key to continue.");
            Console.ReadKey();
        }

        protected static BackupSystem app;

        public enum Mode : byte
        {
            None, Backup, Restore
        }

        protected Mode mode;
        protected DirectoryInfo backupDir;

        protected BackupSystem(string[] args)
        {
            mode = Mode.None;
            var dir = Environment.CurrentDirectory;
            backupDir = new DirectoryInfo(dir + '\\' + BACKUP_DIRECTORY);
            if (args.Length == 0)
                return;
            switch (args[0])
            {
            case "-b":
                mode = Mode.Backup;
                break;
            case "-r":
                mode = Mode.Restore;
                break;
            }
        }
        protected void Run()
        {
            Console.WriteLine("Welcome to BackupMaster5000");
            while (mode == Mode.None)
            {
                Console.WriteLine("Please select mode:");
                Console.WriteLine("[0] Backup | [1] Restore");
                Console.Write("Input number: ");
                int input;
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    switch (input)
                    {
                    case 0:
                        mode = Mode.Backup;
                        break;
                    case 1:
                        mode = Mode.Restore;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number specified");
                }
            }
            Console.WriteLine("Running {0} mode", mode);
            switch (mode)
            {
            case Mode.Backup:
                BackupMode();
                break;
            case Mode.Restore:
                RestoreMode();
                break;
            }
        }

        private void BackupMode()
        {
            var thread = new Thread(() =>
            {
                while (app.mode == Mode.Backup)
                {
                    CheckForBackup();
                    Thread.Sleep(BACKUP_DELAY);
                }
            });
            thread.Start();
            Console.WriteLine("App is running. To terminate it, press any key");
            Console.ReadKey();

            mode = Mode.None;
        }
        private void RestoreMode()
        {
            if (!backupDir.Exists)
            {
                Console.WriteLine("No backup directory!");
                return;
            }

            // Getting the rollback date
            Console.WriteLine("Please input formatted time string");
            Console.WriteLine("Example: {0}", DateTime.Now.ToString());
            DateTime? dateTime = null;
            while (dateTime == null)
            {
                try
                {
                    dateTime = DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Couldn't parse the date. Please try again");
                }
            }

            // Searching for the matching backup folder
            DirectoryInfo foundBackupDir = GetLatestBackup(dateTime.Value);
            if (foundBackupDir == null)
            {
                Console.WriteLine("No backup was made before this date!");
                return;
            }

            // Purging all existing files
            string currentPath = Environment.CurrentDirectory;
            ICollection<string> files = GetAllFiles(currentPath);
            foreach (var file in files)
            {
                File.Delete(currentPath + file);
            }

            CopyContents(foundBackupDir.FullName, currentPath);
        }
        private void CheckForBackup()
        {
            // Initializing
            string dir = Environment.CurrentDirectory;
            if (!backupDir.Exists)
            {
                Console.WriteLine("No backup directory! Creating " + BACKUP_DIRECTORY);
                backupDir.Create();
                backupDir.Attributes = FileAttributes.Hidden;
            }

            // Finding out whether the backup is necessary
            string latestData = GenerateFileInfo(dir);
            DirectoryInfo latestBackup = GetLatestBackup();
            if (latestBackup != null)
            {
                string cacheFilePath = latestBackup.FullName + '\\' + CACHE_FILENAME;
                string latestBackupData = File.ReadAllText(cacheFilePath);
                if (latestData == latestBackupData)
                {
                    return;
                }
            }

            // Backing up files
            string backupSubdirPath = GetFormattedTime(DateTime.Now);
            backupSubdirPath = backupDir.CreateSubdirectory(backupSubdirPath).FullName;
            CopyContents(dir, backupSubdirPath);
            File.WriteAllText(backupSubdirPath + '\\' + CACHE_FILENAME, latestData);
            Console.WriteLine("Backing up at {0}.", backupSubdirPath);
        }
        private void CopyContents(string from, string to)
        {
            ICollection<string> files = GetAllFiles(from);
            ICollection<string> dirs = GetAllDirectories(from);
            foreach (var dir in dirs)
            {
                Directory.CreateDirectory(to + dir);
            }
            foreach (var file in files)
            {
                File.Copy(from + file, to + file);
            }
        }
        private ICollection<string> GetAllFiles(string path)
        {
            var fileList = new List<string>();
            var dirQueue = new Queue<string>();
            dirQueue.Enqueue(path);
            while (dirQueue.Count > 0)
            {
                var dir = dirQueue.Dequeue();
                var files = Directory.GetFiles(dir, "*.txt");
                foreach (var i in files)
                {
                    fileList.Add(i.Remove(0, path.Length));
                }
                var dirs = Directory.GetDirectories(dir);
                foreach (var i in dirs)
                {
                    if (i != path + '\\' + BACKUP_DIRECTORY)
                        dirQueue.Enqueue(i);
                }
            }
            return fileList;
        }
        private ICollection<string> GetAllDirectories(string path)
        {
            var dirList = new List<string>();
            var dirQueue = new Queue<string>();
            dirQueue.Enqueue(path);
            while (dirQueue.Count > 0)
            {
                string dir = dirQueue.Dequeue();
                var dirs = Directory.GetDirectories(dir);
                foreach (var i in dirs)
                {
                    if (i != path + '\\' + BACKUP_DIRECTORY)
                    {
                        dirQueue.Enqueue(i);
                        dirList.Add(i.Remove(0, path.Length));
                    }
                }
            }
            return dirList;
        }
        private DirectoryInfo GetLatestBackup()
        {
            DirectoryInfo latestBackup = null;
            DirectoryInfo[] backupDirArr = backupDir.GetDirectories();
            if (backupDirArr.Length != 0)
            {
                foreach (var subdir in backupDirArr)
                {
                    if (latestBackup == null || subdir.Name.CompareTo(latestBackup.Name) > 0)
                    {
                        latestBackup = subdir;
                    }
                }
            }
            return latestBackup;
        }
        private DirectoryInfo GetLatestBackup(DateTime dateTime)
        {
            string dateTimeFormatted = GetFormattedTime(dateTime);
            DirectoryInfo latestBackup = null;
            DirectoryInfo[] backupDirArr = backupDir.GetDirectories();
            if (backupDirArr.Length != 0)
            {
                foreach (var subdir in backupDirArr)
                {
                    if ((latestBackup == null || subdir.Name.CompareTo(latestBackup.Name) > 0)
                        && subdir.Name.CompareTo(dateTimeFormatted) < 0)
                    {
                        latestBackup = subdir;
                    }
                }
            }
            return latestBackup;
        }
        private string GenerateFileInfo(string path)
        {
            ICollection<string> files = GetAllFiles(path);
            var info = new StringBuilder();
            foreach (var i in files)
            {
                info.AppendLine(i);
                info.AppendLine(File.GetLastWriteTimeUtc(path + i).ToString());
            }
            return info.ToString();
        }
        private string GetFormattedTime(DateTime dateTime)
        {
            return Regex.Replace(dateTime.ToString("s"), ":", "-");
        }
    }
}

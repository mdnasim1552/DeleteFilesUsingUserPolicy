using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class DeleteOldDataBackup
    {
        public static void DeleteOldBackups(string backupFolderPath, DateTime currentDate, int keepLastDays)
        {
            DirectoryInfo backupDirectory = new DirectoryInfo(backupFolderPath);
            FileInfo[] backupFiles = backupDirectory.GetFiles("*.*");

            var groupedBackups = backupFiles.GroupBy(file => new { file.LastWriteTime.Year, file.LastWriteTime.Month });

            foreach (var group in groupedBackups)
            {
                FileInfo lastBackup = group.OrderByDescending(file => file.LastWriteTime).First();

                foreach (FileInfo backupFile in group)
                {
                    if (backupFile != lastBackup)
                    {
                        DateTime backupDate = backupFile.LastWriteTime;

                        if (backupDate.Month == currentDate.Month)
                        {
                            int daysDifference = (currentDate - backupDate).Days;

                            if (daysDifference > keepLastDays)
                            {
                                backupFile.Delete();
                                Console.WriteLine($"Deleted: {backupFile.Name}");
                            }
                        }
                        else if (backupDate < lastBackup.LastWriteTime)
                        {
                            // Delete backups older than the last backup of the month
                            backupFile.Delete();
                            Console.WriteLine($"Deleted: {backupFile.Name}");
                        }
                    }
                }
            }

        }
    }
}

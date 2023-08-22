using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        //string backupFolderPath = @"E:\Session_with_tanvir_vai";
        string backupFolderPath = args[0];
        DateTime currentDate = DateTime.Now;
        int keepLastDays = int.Parse(args[1]);
        //int keepLastDays = 10;

        DeleteOldDataBackup.DeleteOldBackups(backupFolderPath, currentDate, keepLastDays);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }

}
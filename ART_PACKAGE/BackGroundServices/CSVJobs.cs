namespace ART_PACKAGE.BackGroundServices
{
    public class CSVJobs
    {
        public void CleanDirectory()
        {
            string csvFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CSV");
            try
            {
                Console.WriteLine("Delete start");
                // Check if the directory exists
                if (!Directory.Exists(csvFolderPath))
                {
                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(csvFolderPath);
                    Console.WriteLine("Directory created.");
                }
                else
                {
                    Console.WriteLine("Directory already exists.");
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(csvFolderPath);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
                {
                    subDirectory.Delete(true);
                }
                Console.WriteLine("Delete Success");
            }
            catch (Exception)
            {
                Console.WriteLine("Delete error");
                throw;
            }
        }
    }
}

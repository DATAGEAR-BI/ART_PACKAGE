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

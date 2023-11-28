using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace ART_PACKAGE.Controllers
{
    public class FilesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }



        //[HttpGet("[controller]/[action]/{folder}")]
        [HttpGet]
        public async Task<IActionResult> DownloadCsvFiles(/*string folder*/)
        {
            string folderGuid = "7674e730-ab98-43b7-8a65-0dbe97043123"; // or get from the parameter
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "CSV", folderGuid);
            MemoryStream outputStream = new();

            using (ZipArchive archive = new(outputStream, ZipArchiveMode.Create, true))
            {
                // Get all files in the directory
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new(file);
                    ZipArchiveEntry entry = archive.CreateEntry(fileInfo.Name, CompressionLevel.Optimal);

                    using FileStream fileStream = fileInfo.OpenRead();
                    using Stream entryStream = entry.Open();
                    await fileStream.CopyToAsync(entryStream);
                }
            }

            outputStream.Position = 0; // Reset the position to the beginning of the stream
            return File(outputStream, "application/zip", "CSVFiles.zip");
        }



    }
}

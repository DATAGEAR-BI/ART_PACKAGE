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



        [HttpGet("[controller]/[action]/{folder}")]
        //[HttpGet]
        public async Task<IActionResult> DownloadCsvFiles(string folder)
        {
            string folderGuid = folder; // or get from the parameter
            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "CSV", folderGuid);
            MemoryStream outputStream = new();

            using (ZipArchive archive = new(outputStream, ZipArchiveMode.Create, true))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {

                    _ = archive.CreateEntryFromFile(file, Path.GetFileName(file));


                }
            }

            outputStream.Position = 0; // Reset the position to the beginning of the stream
            return File(outputStream, "application/zip", $"{folder}.zip");
        }




    }
}

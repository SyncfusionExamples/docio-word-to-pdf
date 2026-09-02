using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System.Diagnostics;
using WordToPDFConvert.Models;

namespace WordToPDFConvert.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ConvertToPdf(IFormFile uploadFiles)
        {
            if (uploadFiles == null || uploadFiles.Length == 0)
                return BadRequest("Please select a Word document.");

            //Loads file stream into Word document
            using (WordDocument wordDocument = new WordDocument(uploadFiles.OpenReadStream(), FormatType.Docx))
            {
                //Instantiation of DocIORenderer for Word to PDF conversion
                using (DocIORenderer render = new DocIORenderer())
                {
                    //Converts Word document into PDF document
                    PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

                    //Saves the PDF document to MemoryStream.
                    MemoryStream stream = new MemoryStream();
                    pdfDocument.Save(stream);
                    stream.Position = 0;

                    var downloadName = Path.GetFileNameWithoutExtension(uploadFiles.FileName) + ".pdf";

                    //Download PDF document in the browser.
                    return File(stream, "application/pdf", downloadName);
                }
            }
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

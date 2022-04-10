using Microsoft.AspNetCore.Mvc;
using UsersNotepad.Database;
using UsersNotepad.Database.Models;
using System.Data.Entity;
using UsersNotepad.Reports.Documents;

namespace UsersNotepad.Controllers
{
    public class ReportsController : Controller
    {

        private readonly UsersNotepadDbContext dbContext;

        public ReportsController()
        {
            dbContext = new UsersNotepadDbContext();
        }


        [HttpGet]
        public IActionResult GenerateReport()
        {
            return PartialView("GenerateReport");
        }

        [HttpGet]
        public ActionResult DownloadXML()
        {
            List<User> usersList = dbContext.Users.Include(x => x.Attributes).OrderBy(x => x.Id).ToList();
            XML xmlFile = new XML();

            string downloadFileName = $"{DateTime.Now.ToString("dd.MM.yyyy HH_mm_ss")}.xml";

            return File(xmlFile.GenerateDocument(usersList), "application/xml", downloadFileName);
        }
        [HttpGet]
        public ActionResult DownloadTXT()
        {
            List<User> usersList = dbContext.Users.Include(x => x.Attributes).OrderBy(x => x.Id).ToList();
            TXT txtFile = new TXT();

            string downloadFileName = $"{DateTime.Now.ToString("dd.MM.yyyy HH_mm_ss")}.txt";

            return File(txtFile.GenerateDocument(usersList), "text/txt", downloadFileName);
        }
        [HttpGet]
        public ActionResult DownloadCSV()
        {
            List<User> usersList = dbContext.Users.Include(x => x.Attributes).OrderBy(x => x.Id).ToList();
            CSV csvFile = new CSV();

            string downloadFileName = $"{DateTime.Now.ToString("dd.MM.yyyy HH_mm_ss")}.csv";

            return File(csvFile.GenerateDocument(usersList), "text/csv", downloadFileName);
        }
        [HttpGet]
        public ActionResult DownloadPDF()
        {
            List<User> usersList = dbContext.Users.Include(x => x.Attributes).OrderBy(x => x.Id).ToList();
            PDF pdfFile = new PDF();

            string downloadFileName = $"{DateTime.Now.ToString("dd.MM.yyyy HH_mm_ss")}.pdf";

            return File(pdfFile.GenerateDocument(usersList), "application/pdf", downloadFileName);
        }

    }
}

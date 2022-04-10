using iTextSharp.text;
using iTextSharp.text.pdf;
using UsersNotepad.Database.Models;

namespace UsersNotepad.Reports.Documents
{
    public class PDF : ReportGenerator
    {
        public override MemoryStream GenerateDocument(List<User> users)
        {
            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
             
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            writer.CloseStream = false;
            document.Open();
            document.Add(GenerateTable(users));
            document.Close();
            memoryStream.Flush();
            memoryStream.Position = 0;

            return memoryStream;
        }

        private PdfPTable GenerateTable(List<User> users)
        {
            var polishCharacters = FontFactory.GetFont(BaseFont.COURIER, BaseFont.CP1257, 10, Font.NORMAL);
            PdfPTable table = new PdfPTable(6);
            PdfPCell cell = new PdfPCell(new Phrase("Użytkownicy",polishCharacters));
            cell.Colspan = 6;
            cell.HorizontalAlignment = 1;

            table.AddCell(cell);
            table.AddCell(new Phrase("Imię", polishCharacters));
            table.AddCell(new Phrase("Nazwisko", polishCharacters));
            table.AddCell(new Phrase("Data urodzenia", polishCharacters));
            table.AddCell(new Phrase("Płeć", polishCharacters));
            table.AddCell(new Phrase("Wiek", polishCharacters));
            table.AddCell(new Phrase("Tutuł", polishCharacters));

            foreach(User user in users)
            {
                table.AddCell(new Phrase(user.FirstName, polishCharacters));
                table.AddCell(new Phrase(user.LastName, polishCharacters));
                table.AddCell(new Phrase(user.DateOfBirth.ToString("dd-MM-yyyy"), polishCharacters));
                table.AddCell(new Phrase(user.Sex, polishCharacters));
                table.AddCell(new Phrase(CalculateAge(user).ToString(), polishCharacters));
                table.AddCell(new Phrase(((user.Sex=="Kobieta")?"Pani":"Pan"), polishCharacters));
            }

            return table;
        }


    }
}

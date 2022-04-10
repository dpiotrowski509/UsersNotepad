using System.Text;
using UsersNotepad.Database.Models;

namespace UsersNotepad.Reports.Documents
{
    public class TXT : ReportGenerator
    {
        public override MemoryStream GenerateDocument(List<User> users)
        {
            var memoryStream = new MemoryStream();

            var sw = new StreamWriter(memoryStream);
            sw.Write(PrepareDataString(users));
            sw.Flush();

            memoryStream.Position = 0;
            return memoryStream;
        }

        private string PrepareDataString(List<User> users)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Imię;Nazwisko;Data urodzenia;Płeć;Wiek;Tytuł");
            foreach (var user in users)
            {
                sb.AppendLine($"{user.FirstName};{user.LastName};{user.DateOfBirth};{user.Sex};{CalculateAge(user)};{(user.Sex == "Kobieta" ? "Pani" : "Pan")}");
            }

            return sb.ToString();
        }
    }
}

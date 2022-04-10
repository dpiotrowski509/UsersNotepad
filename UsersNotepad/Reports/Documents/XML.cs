using System.Xml;
using UsersNotepad.Database.Models;

namespace UsersNotepad.Reports.Documents
{
    public class XML : ReportGenerator
    {
        public override MemoryStream GenerateDocument(List<User> users)
        {
            var memoryStream = new MemoryStream();
            XmlDocument doc = PrepareDocument(users);
            doc.Save(memoryStream);

            memoryStream.Flush();
            memoryStream.Position = 0;

            return memoryStream; 
        }

        private XmlDocument PrepareDocument(List<User> users)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Użytkownicy");
            doc.AppendChild(root);
            foreach (var user in users)
            {
                XmlNode userElement = doc.CreateElement("Użytkownik");
                root.AppendChild(userElement);

                XmlNode firstNameNode = doc.CreateElement("Imię");
                XmlText firstName = doc.CreateTextNode(user.FirstName);
                firstNameNode.AppendChild(firstName);


                XmlNode lastNameNode = doc.CreateElement("Nazwisko");
                XmlText lastName = doc.CreateTextNode(user.FirstName);
                lastNameNode.AppendChild(lastName);

                XmlNode dateOfBirthNode = doc.CreateElement("DataUrodzenia");
                XmlText dateOfBirth = doc.CreateTextNode(user.DateOfBirth.ToString("dd-MM-yyyy"));
                dateOfBirthNode.AppendChild(dateOfBirth);

                XmlNode sexNode = doc.CreateElement("Płeć");
                XmlText sex = doc.CreateTextNode(user.Sex);
                sexNode.AppendChild(sex);

                XmlNode ageNode = doc.CreateElement("Wiek");
                XmlText age = doc.CreateTextNode(CalculateAge(user).ToString());
                ageNode.AppendChild(age);

                XmlNode titleNode = doc.CreateElement("Tytuł");
                XmlText title = doc.CreateTextNode((user.Sex == "Kobieta") ? "Kobieta" : "Mężczyzna");
                titleNode.AppendChild(title);


                userElement.AppendChild(firstNameNode);
                userElement.AppendChild(lastNameNode);
                userElement.AppendChild(dateOfBirthNode);
                userElement.AppendChild(sexNode);
                userElement.AppendChild(ageNode);
                userElement.AppendChild(titleNode);
            }

            return doc;
        }
    }

}

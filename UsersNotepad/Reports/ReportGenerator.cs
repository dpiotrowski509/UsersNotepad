using UsersNotepad.Database.Models;

namespace UsersNotepad
{
    abstract public class ReportGenerator
    {
        abstract public MemoryStream GenerateDocument(List<User> users);

        protected int CalculateAge(User user)
        {
            int age = 0;
            DateTime Birthday = user.DateOfBirth.Date;
            DateTime Today = DateTime.Now.Date;

            age = Today.Year - Birthday.Year; 
            if(Today.Month < Birthday.Month)
            {
                age--;
            }
            if(Today.Month == Birthday.Month && Today.Day < Birthday.Day)
            {
                age--;
            }

            return age;
        }
    }
}

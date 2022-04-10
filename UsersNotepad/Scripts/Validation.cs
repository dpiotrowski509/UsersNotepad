using UsersNotepad.Database.Models;

namespace UsersNotepad.Scripts
{
    public class Validation
    {
        public bool IsUserDataCorrect(User user)
        {
            if (user == null)
            {
                return false;
            }

            if (IsFirstNameCorrect(user) && IsLastNameCorrect(user) && IsSexNotNull(user) && IsDateOfBirthCorrect(user))
            {
                return true;
            }
            return false;
        }

        private bool IsFirstNameCorrect(User user)
        {
            if (user.FirstName.Length <= 50)
            {
                return true;
            }
            return false;
        }
        private bool IsLastNameCorrect(User user)
        {
            if (user.LastName.Length <= 150)
            {
                return true;
            }
            return false;
        }
        private bool IsDateOfBirthCorrect(User user)
        {
            if (user.DateOfBirth <= DateTime.Now && user.DateOfBirth >= DateTime.Now.AddYears(-100))
            {
                return true;
            }
            return false;
        }
        private bool IsSexNotNull(User user)
        {
            if (user.Sex != null)
            {
                return true;
            }
            return false;
        }
    }
}

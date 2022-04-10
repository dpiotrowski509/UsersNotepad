namespace UsersNotepad.Database.Models
{
    public class UserAttribute
    {
        public int Id { get; set; }
        public string AttributeName { get; set; } 
        public string AttributeValue { get; set; }
        public virtual User User { get; set; }

    }
}

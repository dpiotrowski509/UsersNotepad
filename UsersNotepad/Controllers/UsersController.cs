using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using UsersNotepad.Database;
using UsersNotepad.Database.Models;
using UsersNotepad.Scripts;

namespace UsersNotepad.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersNotepadDbContext dbContext;
        Validation validation = new Validation();
        public UsersController()
        {
            dbContext = new UsersNotepadDbContext();
        }


        public IActionResult UsersList()
        {
            return View(dbContext.Users.Include(x => x.Attributes).OrderBy(x => x.Id).ToList());
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            User user = new User();
            return PartialView("CreateUser", user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (validation.IsUserDataCorrect(user))
            {
                try
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return new JsonResult("Done");
                }
                catch (Exception ex)
                {
                    return PartialView("CreateUser", user);
                }

            }
            return PartialView("CreateUser", user);
        }

        [HttpGet]
        public IActionResult CreateUserError()
        {

            return PartialView("UserError");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            User user = dbContext.Users.Include(x => x.Attributes).FirstOrDefault(x => x.Id == id);
            return PartialView("EditUser", user);
        }
        [HttpPost]
        public IActionResult EditUser([FromBody] User user)
        {
            if (validation.IsUserDataCorrect(user))
            {
                try
                {
                    User userToUpdate = dbContext.Users.Include(x => x.Attributes).FirstOrDefault(x => x.Id == user.Id);
                    userToUpdate = EditUserValues(userToUpdate, user);
                    dbContext.Entry(userToUpdate).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return new JsonResult("Done");
                }
                catch (Exception ex)
                {
                    return PartialView("EditUser", user);
                }
            }

            return PartialView("EditUser", user);
        }
        private User EditUserValues(User userToEdit, User user)
        {
            userToEdit.FirstName = user.FirstName;
            userToEdit.LastName = user.LastName;
            userToEdit.DateOfBirth = user.DateOfBirth;
            userToEdit.Sex = user.Sex;
            userToEdit.Attributes = user.Attributes;
            return userToEdit;
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            User user = dbContext.Users.Include(x => x.Attributes).FirstOrDefault(x => x.Id == id);
            return PartialView("DeleteUser", user);
        }
        [HttpPost]
        public IActionResult DeleteUser([FromBody] User user)
        {
            try
            {
                dbContext.Users.Remove(dbContext.Users.Include(x => x.Attributes).FirstOrDefault(x => x.Id == user.Id));
                dbContext.SaveChanges();
                return new JsonResult("Done");
            }
            catch (Exception ex)
            {
                return new JsonResult("Error");
            }

        }
    }
}

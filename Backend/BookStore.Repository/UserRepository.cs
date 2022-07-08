using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.ViewModels;
using BookStore.Models.Models;
/*namespace BookStore.Repository
{
    public class UserRepository : BaseRepository
    {

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
        public User Login(LoginModel model)
        {
            return context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(model.Password));

        }
        public User Register(RegisterModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Roleid = model.Roleid,

            };
            var entry = context.Users.Add(user);
            context.SaveChanges();
            return entry.Entity;
        }
    }
}*/


namespace BookStore.Repository
{
    public class UserRepository : BaseRepository
    {
        public User Login(LoginModel model)
        {
            return context.Users.FirstOrDefault(c => c.Email.Equals(model.Email.ToLower()) && c.Password.Equals(model.Password));
        }

        public User Register(RegisterModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Password = model.Password,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Roleid = model.Roleid,
            };
            var entry = context.Users.Add(user);
            context.SaveChanges();
            return entry.Entity;
        }

        public List<User> GetUsers(int pageIndex, int pageSize, string? keyword)
        {
            var users = context.Users.AsQueryable();

            if (pageIndex > 0)
            {
                if (string.IsNullOrEmpty(keyword) == false)
                {
                    users = users.Where(w => w.Firstname.ToLower().Contains(keyword) || w.Lastname.ToLower().Contains(keyword));
                }

                var userList = users.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                return userList;
            }

            return null;
        }

        public User GetUser(int id)
        {
            if (id > 0)
            {
                return context.Users.Where(w => w.Id == id).FirstOrDefault();
            }

            return null;
        }

        public bool UpdateUser(User model)
        {
            if (model.Id > 0)
            {
                context.Update(model);
                context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteUser(User model)
        {
            if (model.Id > 0)
            {
                context.Remove(model);
                context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}




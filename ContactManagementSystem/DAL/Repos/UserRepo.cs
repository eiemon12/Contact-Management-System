using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>, IAuth
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Users.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Upadte(User obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
        public bool Authenticate(string username, string password)
        {
            var user = db.Users.SingleOrDefault(
                    u => u.UserName.Equals(username) &&
                    u.Password.Equals(password)
                );
            return user != null;
        }
    }
}

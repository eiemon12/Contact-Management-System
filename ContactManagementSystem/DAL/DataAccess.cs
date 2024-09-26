using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<Contact, int, bool> ContactData()
        {
            return new ContactRepo();
        }
        public static IAuth AuthData()
        {
            return new UserRepo();
        }
    }
}
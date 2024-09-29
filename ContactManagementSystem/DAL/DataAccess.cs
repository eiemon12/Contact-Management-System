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
        public static IRepo<User, string, bool> UserData()
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
        public static ISearchRepo SearchData()
        {
            return new ContactRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
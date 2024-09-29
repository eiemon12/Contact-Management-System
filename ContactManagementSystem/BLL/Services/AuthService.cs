using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        
        public static TokenDTO Authenticate(string UserName, string Password)
        {
            var res = DataAccess.AuthData().Authenticate(UserName, Password);
            if (res)
            {
                var token = new Token
                {
                    UserName = UserName,
                    CreatedAt = DateTime.Now,
                    Key = Guid.NewGuid().ToString()
                };
                var ret = DataAccess.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c => {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;
        }


        public static bool Logout(string key) {
            var extk = DataAccess.TokenData().Get(key);
            extk.ExpiredAt = DateTime.Now;
            if (DataAccess.TokenData().Update(extk) != null) {
                return true;
            }
            return false;
            
            
        }

        public static bool IsTokenValid(string key)
        {
            var extk = DataAccess.TokenData().Get(key);
            if (extk != null && extk.ExpiredAt == null)
            {
                return true;
            }
            return false;
        }
    }
}

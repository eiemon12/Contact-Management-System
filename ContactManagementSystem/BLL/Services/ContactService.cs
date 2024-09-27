using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ContactService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Contact, ContactDTO>();
                cfg.CreateMap<ContactDTO, Contact>();
            });
            return new Mapper(config);
        }
        public static bool Create(ContactDTO obj)
        {
            var data = GetMapper().Map<Contact>(obj);
            return DataAccess.ContactData().Create(data);
        }
        public static List<ContactDTO> GetAll()
        {
            var data = DataAccess.ContactData().GetAll();
            return GetMapper().Map<List<ContactDTO>>(data);
        }
        public static ContactDTO Get(int id)
        {
            var data = DataAccess.ContactData().Get(id);
            return GetMapper().Map<ContactDTO>(data);
        }

        public static bool Update(ContactDTO obj)
        {
            var data = GetMapper().Map<Contact>(obj);
            return DataAccess.ContactData().Upadte(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.ContactData().Delete(id);
        }

        public static ContactDTO GetByName(string name)
        {
            
            var contactRepo = (DataAccess)DataAccess.ContactData();
            var data = contactRepo.Equals(name) ? contactRepo : null;

            if (data == null)
            {
                throw new Exception("Contact not found");
            }

            return GetMapper().Map<ContactDTO>(data);
        }
    }
}

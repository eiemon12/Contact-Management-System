using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            return DataAccess.ContactData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccess.ContactData().Delete(id);
        }

        public static List<ContactDTO> SearchByName(string name)
        {
            var contacts = DataAccess.SearchData().Search(name);
            if (contacts == null || !contacts.Any())
            {
                return new List<ContactDTO>();
            }
            return GetMapper().Map<List<ContactDTO>>(contacts);
        }

        public static List<ContactDTO> GetUpcomingBirthdays(int daysAhead)
        {
            var today = DateTime.Today;
            var upcomingDate = today.AddDays(daysAhead);
            var contacts = DataAccess.ContactData().GetAll();

           
            var upcomingContacts = contacts
                .Where(c => IsBirthdayInRange(c.Birthday, today, upcomingDate)) // Check birthdays within range
                .ToList();

            
            return GetMapper().Map<List<ContactDTO>>(upcomingContacts);
        }

        private static bool IsBirthdayInRange(string birthdayString, DateTime today, DateTime upcomingDate)
        {
            if (DateTime.TryParseExact(birthdayString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthday))
            {
                var thisYearBirthday = new DateTime(today.Year, birthday.Month, birthday.Day);

                // If birthday has passed, move it to next year
                if (thisYearBirthday < today)
                {
                    thisYearBirthday = new DateTime(today.Year + 1, birthday.Month, birthday.Day);
                }

                return thisYearBirthday >= today && thisYearBirthday <= upcomingDate;
            }
            return false;
        }




    }
}

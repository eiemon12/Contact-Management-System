﻿using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ContactRepo : Repo, IRepo<Contact, int, bool> ,ISearch
    {
        public bool Create(Contact obj)
        {
            db.Contacts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Contacts.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Contact Get(int id)
        {
            return db.Contacts.Find(id);
        }

        public List<Contact> GetAll()
        {
            return db.Contacts.ToList();
        }

        public bool Upadte(Contact obj)
        {
            var exobj = Get(obj.CId);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0; 
        }


        
        public Contact GetByName(string name)
        {
            return db.Contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}

using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NoteRepo :Repo, IRepo<Note, int, bool>
    {
        public bool Create(Note obj)
        {
            db.Notes.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Notes.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public Note Get(int id)
        {
            return db.Notes.Find(id);
        }

        public List<Note> GetAll()
        {
            return db.Notes.ToList();
        }

        public bool Upadte(Note obj)
        {
            var exobj = Get(obj.NoteId);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}

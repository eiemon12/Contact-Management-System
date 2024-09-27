using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ContactNoteDTO
    {
        public NoteDTO Note { get; set; }

        public ContactNoteDTO()
        {
            Note = new NoteDTO(); 
        }
    }
}

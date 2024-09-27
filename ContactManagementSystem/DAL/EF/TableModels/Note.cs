using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Note
    {
        [Key]
        [ForeignKey("Contact")] 
        public int NoteId { get; set; }
        public string Notes { get; set; }


        public virtual Contact Contact { get; set; }
    }
}

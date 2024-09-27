using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Contact
    {
        [Key]
        public int CId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Categories { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("User")]
        public int UId { get; set; }

        public virtual Note Note { get; set; }
        public int? NoteId { get; set; }
    }
}

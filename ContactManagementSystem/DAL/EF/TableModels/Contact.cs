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
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Name { get; set; }
        public int Phone {  get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Categories { get; set; }
        public string Notes { get; set; }

    }
}

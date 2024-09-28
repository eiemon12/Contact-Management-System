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
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string Category { get; set; } //  Friend, Family, Work
        public string Notes { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public virtual User User { get; set; }
    }
}

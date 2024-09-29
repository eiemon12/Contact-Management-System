using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class User
    {
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]


        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Password { get; set; } 
        

        public virtual ICollection<Contact> Contacts { get; set; }
        public User()
        {
            Contacts = new List<Contact>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Key { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserName { get; set; }

        public virtual User User { get; set; }
    }
}

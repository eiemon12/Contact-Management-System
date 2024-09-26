using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Categories { get; set; }
        public string Notes { get; set; }
    }
}

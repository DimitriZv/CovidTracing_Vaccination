using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project334.Models
{
    public class Alert
    {
        [Key]
        public int AlertID { get; set; }

        public int DangerousCaseID { get; set; }

        public string Comment { get; set; }

        //public virtual ICollection<DangerousCase> DangerousCases { get; set; }
        public virtual DangerousCase DangerousCase { get; set; }
    }
}

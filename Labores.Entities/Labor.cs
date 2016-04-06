using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Labores.Entities
{
    public class Labor
    {
        [Key]
        public int id { get; set; }
        public virtual List<Material> Materiales
        {
            get;
            set;
        }
        public string Instrucciones { get; set; }
    }
}

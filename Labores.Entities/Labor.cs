using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labores.Entities
{
    public class Labor
    {
        private int id;
        public List<Material> Materiales { get; set; }
        public string Instrucciones { get; set; }
    }
}

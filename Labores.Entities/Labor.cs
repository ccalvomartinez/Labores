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
        public System.Xml.XmlDocument Instrucciones { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Labores.Entities
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Labores.Web.Attributes.Instructions("Rellene el material y la cantidad necesaria")]
        public string Nombre { get; set; }
    }
}

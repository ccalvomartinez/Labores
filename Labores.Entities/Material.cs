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
        public string Nombre;
    }
}

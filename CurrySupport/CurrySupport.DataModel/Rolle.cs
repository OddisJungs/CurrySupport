using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Rolle
    {
        public int Id { get; set; }

        // die Effektive Bezeichnung der Role, z.B. Administrator
        [Required]
        public string Bezeichnung { get; set; }
    }
}

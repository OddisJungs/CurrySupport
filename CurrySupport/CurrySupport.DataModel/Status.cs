using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Bezeichnung { get; set; }

        [Required]
        public string Beschreibung { get; set; }
    }
}
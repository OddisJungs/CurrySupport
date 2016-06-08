using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Vorname { get; set; }

        public string Telefonnummer { get; set; }

        public string Adresse { get; set; }

        public bool Aktiv { get; set; }
    }
}

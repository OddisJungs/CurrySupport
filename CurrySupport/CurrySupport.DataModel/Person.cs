﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class Person
    {
        public Person()
        {
            Tickets = new ObservableCollection<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Telefonnummer { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public bool Aktiv { get; set; }

        [Required]
        public virtual Rolle Rolle { get; set; }

        public virtual ObservableCollection<Ticket> Tickets { get; set; }
    }
}
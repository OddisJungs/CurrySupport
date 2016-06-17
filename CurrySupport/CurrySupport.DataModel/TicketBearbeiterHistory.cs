using System;
using System.ComponentModel.DataAnnotations;

namespace CurrySupport.DataModel
{
    public class TicketBearbeiterHistory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public virtual Person Person { get; set; }

        [Required]
        public virtual DateTime Zuweisungsdatum { get; set; } 
    }
}
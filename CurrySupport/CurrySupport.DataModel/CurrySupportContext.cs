using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.DataModel
{
    public class CurrySupportContext : DbContext
    {
        // List all the Tables that schould be generated
        public DbSet<Kategorie> AlleKategorien { get; set; }
        public DbSet<Person> AllePersonen { get; set; }
        public DbSet<Rolle> AlleRollen { get; set; }
        public DbSet<Status> AlleStatusse { get; set; }
        public DbSet<Ticket> AlleTickets { get; set; }
        public DbSet<Unterkategorie> AlleUnterkategorien { get; set; }
    }
}

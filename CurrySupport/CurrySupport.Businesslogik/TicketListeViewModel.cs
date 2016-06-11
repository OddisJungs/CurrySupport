using CurrySupport.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrySupport.Businesslogik
{
    public class TicketListeViewModel
    {
        public TicketListeViewModel()
        {
            dbContext = new CurrySupportContext();
        }

        ~TicketListeViewModel()
        {
            dbContext.SaveChanges();
        }

        private CurrySupportContext dbContext;

    }
}

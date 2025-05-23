using RentalCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingDeckDL
{
    interface IRentalDataService
    {
        public List<CampingCommon> GetItems();
        public void UpdateItem(CampingCommon item);
    }
}

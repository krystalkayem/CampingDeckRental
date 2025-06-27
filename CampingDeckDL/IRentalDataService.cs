using RentalCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampingDeckDL
{
    public interface IRentalDataService
    {
        List<CampingCommon> GetItems();
        void UpdateItem(CampingCommon item);
    }
}

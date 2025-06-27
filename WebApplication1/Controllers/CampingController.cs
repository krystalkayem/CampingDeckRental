using RentalCommon;
using CampingDeckBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampingController : ControllerBase
    {
        CampingDeckRentalProcess rentalProcess = new CampingDeckRentalProcess();

        [HttpGet]
        public List<CampingCommon> GetAllItems()
        {
            return rentalProcess.GetItems();
        }
         
        [HttpGet("rented")]
        public List<CampingCommon> GetRentedItems()
        {
            return rentalProcess.GetRentedItems();
        }

        [HttpPatch("rent")]
        public bool RentItem(int index, string borrower)
        {
            return rentalProcess.BorrowItem(index, borrower);
        }

        [HttpPatch("return")]
        public bool ReturnItem(int index)
        {
            return rentalProcess.ReturnItem(index);
        }
    }
}

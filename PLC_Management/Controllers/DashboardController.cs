using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ActivityModel;
using PLC_Management.Models.ThongSoMayModel;


namespace PLC_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateThongSoMay([FromBody] ThongSoMay thongSoMoi)
        {
            try
            {
                ThongSoMayBusiness.UpdateThongSoMay(thongSoMoi.Apsuat, thongSoMoi.ThoiGianNapGioiHan);
            }
            catch
            {
                //Lỗi
            }
            return Json(new());
        }



    }

}

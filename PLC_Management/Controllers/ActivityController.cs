using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ActivityModel;
namespace PLC_Management.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index([FromQuery(Name = "tungay")] string? tungay, [FromQuery(Name = "toingay")] string? toingay, [FromQuery(Name = "page")] int? page)
        {
            List<Activity> activities = new List<Activity>();
            ActivityBusiness activityBusiness = new ActivityBusiness();
            if (page == null || page == 0)
            {
                page = 1;
            }
            if (tungay == null && toingay == null)
            {
                ViewBag.host = $"activity?page=";

                try
                {
                    int sumActivity = ActivityBusiness.CountActivity();
                    int countPage = (sumActivity / Common.NUMBER_ELM_ON_PAGE_ACTIVITY);
                    if (sumActivity % Common.NUMBER_ELM_ON_PAGE_ACTIVITY != 0)
                    {
                        countPage = countPage + 1;
                    }
                    ViewBag.countPage = countPage;
                    activities = activityBusiness.GetAllActivities(page);
                }
                catch
                {
                    // Lỗi
                }
            }
            else
            {
                ViewBag.host = $"activity?tungay={tungay}&toingay={toingay}&page=";
                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay).AddDays(1);
                string strDatime1 = dateTime1.Year + "-" + dateTime1.Month + "-" + dateTime1.Day;
                string strDatime2 = dateTime2.Year + "-" + dateTime2.Month + "-" + dateTime2.Day;

                try
                {
                    int sumActivity = ActivityBusiness.CountActivityByDay(strDatime1, strDatime2);
                    int countPage = (sumActivity / Common.NUMBER_ELM_ON_PAGE_ACTIVITY);
                    if (sumActivity % Common.NUMBER_ELM_ON_PAGE_ACTIVITY != 0)
                    {
                        countPage = countPage + 1;
                    }
                    ViewBag.countPage = countPage;
                    activities = activityBusiness.GetActivityByDay(strDatime1, strDatime2, page);
                }
                catch
                {
                    //Lỗi
                }
            }

            ViewBag.listActivities = activities;

            ViewBag.tungay = tungay;
            ViewBag.toingay = toingay;
            ViewBag.pageCurrent = page;

            return View();
        }

    }
}

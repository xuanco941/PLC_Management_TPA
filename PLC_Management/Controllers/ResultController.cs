using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ResultModel;

namespace PLC_Management.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index([FromQuery(Name = "tungay")] string? tungay, [FromQuery(Name = "toingay")] string? toingay, [FromQuery(Name = "page")] int? page, [FromQuery(Name = "Oxy")] string Oxy,
            [FromQuery(Name = "Nitor")] string Nitor, [FromQuery(Name = "numberResult")] int numberResult)
        {

            if (numberResult > 0)
            {
                Common.NUMBER_ELM_ON_PAGE = numberResult;
                if (numberResult > 5000)
                {
                    Common.NUMBER_ELM_ON_PAGE = 5000;
                }
            }

            ResultBusiness resultBusiness = new ResultBusiness();
            List<Result> results = new List<Result>();


            var today = DateTime.Now;
            if (page == null || page == 0)
            {
                page = 1;
            }
            if (tungay == null && toingay == null)
            {
                ViewBag.host = $"result?page=";

                try
                {
                    int sumResult = ResultBusiness.CountResult();

                    int countPage = (sumResult / Common.NUMBER_ELM_ON_PAGE);
                    if (sumResult % Common.NUMBER_ELM_ON_PAGE != 0)
                    {
                        countPage = countPage + 1;
                    }
                    ViewBag.countPage = countPage;
                    results = resultBusiness.GetAllResults(page);
                }
                catch
                {
                    //Lỗi
                }
                ViewBag.listResults = results;

            }
            else if (tungay != null && toingay != null && (Oxy == null && Nitor == null))
            {

                ViewBag.host = $"result?tungay={tungay}&toingay={toingay}&page=";
                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay).AddDays(1);
                string strDatime1 = dateTime1.Year + "-" + dateTime1.Month + "-" + dateTime1.Day;
                string strDatime2 = dateTime2.Year + "-" + dateTime2.Month + "-" + dateTime2.Day;

                try
                {
                    int sumResult = ResultBusiness.CountResultByDay(strDatime1, strDatime2);
                    int countPage = (sumResult / Common.NUMBER_ELM_ON_PAGE);
                    if (sumResult % Common.NUMBER_ELM_ON_PAGE != 0)
                    {
                        countPage = countPage + 1;
                    }
                    ViewBag.countPage = countPage;
                    results = resultBusiness.GetResultByDay(strDatime1, strDatime2, page);
                }
                catch
                {
                    //Lỗi
                }
                ViewBag.listResults = results;



            }
            else
            {
                string idOxy = Oxy != null ? "Oxy" : "null";
                string idNitor = Nitor != null ? "Nitor" : "null";

                DateTime dateTime1 = Convert.ToDateTime(tungay);
                DateTime dateTime2 = Convert.ToDateTime(toingay).AddDays(1);
                string strDatime1 = dateTime1.Year + "-" + dateTime1.Month + "-" + dateTime1.Day;
                string strDatime2 = dateTime2.Year + "-" + dateTime2.Month + "-" + dateTime2.Day;

                try
                {
                    int sumResult = ResultBusiness.CountResultByParameterAndDay(strDatime1, strDatime2, idOxy, idNitor);
                    int countPage = (sumResult / Common.NUMBER_ELM_ON_PAGE);
                    if (sumResult % Common.NUMBER_ELM_ON_PAGE != 0)
                    {
                        countPage = countPage + 1;
                    }
                    ViewBag.countPage = countPage;

                    string? hostOxy = "";
                    string? hostNitor = "";

                    if (Oxy != null)
                    {
                        hostOxy = "Oxy=on&";
                    }
                    if (Nitor != null)
                    {
                        hostNitor = "Nitor=on&";
                    }

                    ViewBag.host = $"result?{hostOxy}{hostNitor}tungay={tungay}&toingay={toingay}&page=";
                    results = resultBusiness.GetResultByDayAndParameter(strDatime1, strDatime2, idOxy, idNitor, page);
                }
                catch
                {
                    //Lỗi
                }
                ViewBag.listResults = results;

            }

            ViewBag.checkOxy = Oxy != null ? "checked" : null;
            ViewBag.checkNitor = Nitor != null ? "checked" : null;


            if (Oxy == null && Nitor == null)
            {
                ViewBag.checkOxy = "checked";
                ViewBag.checkNitor = "checked";
            }
            ViewBag.tungay = tungay;
            ViewBag.toingay = toingay;
            ViewBag.pageCurrent = page;
            ViewBag.NUMBER_ELM_ON_PAGE = Common.NUMBER_ELM_ON_PAGE;

            return View();
        }


        [HttpPost]
        public IActionResult DeleteResult([FromBody] DeleteResultModel deleteResult)
        {
            try
            {
                ResultBusiness.DeleteResultByIDAndParameter(deleteResult.start_id, deleteResult.end_id, deleteResult.Oxy, deleteResult.Nitor);

            }
            catch
            {
                //loi xoa
            }
            return Json(new { deleteResult.start_id, deleteResult.end_id, deleteResult.Oxy, deleteResult.Nitor });
        }

        [HttpPost]
        public IActionResult DeleteAllResults()
        {

            try
            {
                ResultBusiness.DeleteAllResults();
                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound();
            }

        }
    }

}

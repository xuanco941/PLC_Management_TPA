using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.ActivityModel;


namespace PLC_Management.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index([FromQuery(Name = "timeSaveData")] int? timeSaveData)
        {
            //if ((timeSaveData != null) && (timeSaveData > 2) && (timeSaveData * 1000 != InsertResultInterval.timeSaveData))
            //{
            //    InsertResultInterval.timeSaveData = (int)timeSaveData * 1000;
            //    if (InsertResultInterval.TimerInsertResult.Enabled == true)
            //    {
            //        InsertResultInterval.Clear();
            //        InsertResultInterval.Run();
            //    }
            //}
            //ViewBag.timeSaveData = InsertResultInterval.timeSaveData / 1000;
            return View();
        }

        public IActionResult UpdateDataPLC()
        {
            //MainPLC.GetData();
            return Json(new
            {
                message = CurrentValuePLC.Message
            });
        }



        //[HttpPost]
        //public IActionResult ReConnectPLC([FromBody] bool disconnect)
        //{
        //    ActivityBusiness.AddActivity("Mất kết nối tới PLC.");
        //    if (disconnect == true)
        //    {
        //        MainPLC.Start();
        //        if (InsertResultInterval.TimerInsertResult.Enabled == true)
        //        {
        //            InsertResultInterval.Clear();
        //            InsertResultInterval.Run();
        //        }
        //    }

        //    return Json(new {disconnect});
        //}





    }
    
}

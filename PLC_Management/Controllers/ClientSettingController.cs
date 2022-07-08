using Microsoft.AspNetCore.Mvc;
using PLC_Management.Models.EmployeeModel;
using System.Data.SqlClient;

namespace PLC_Management.Controllers
{
    public class ClientSettingController : Controller
    {
        [HttpPost]
        public IActionResult DarkMode(IFormCollection form)
        {
            int darkMenu = Convert.ToInt32(HttpContext.Session.GetInt32(Common.SESSION_DARKMENU));

            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            int employee_id = Int32.Parse(form["employee_id"]);
            command.CommandText = "exec UpdateClientSetting @employee_id";
            command.Parameters.AddWithValue("employee_id", employee_id);

            command.Connection = sqlConnection;

            try
            {
                command.ExecuteNonQuery();
                if (darkMenu == 0)
                {
                    HttpContext.Session.SetInt32(Common.SESSION_DARKMENU, 1);
                }
                else
                {
                    HttpContext.Session.SetInt32(Common.SESSION_DARKMENU, 0);
                }
            }
            catch
            {
                // không thay đổi chế độ màu
            }
            finally
            {
                sqlConnection.Close();
            }


            return RedirectToAction("Index", "Dashboard");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PLC_Management;
using PLC_Management.Models.EmployeeModel;
using System.Data.SqlClient;

namespace WebApplication1.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32(Common.SESSION_USER_LOGIN) != null)
        {
            return RedirectToAction("Index", "Dashboard");
        }
        else
        {
            return View();
        }
    }

    //Dang nhap, luu session vao bien session class common
    [HttpPost]
    public IActionResult Login(IFormCollection form)
    {
        string username = form["username"].ToString().Trim();
        string password = form["password"].ToString().Trim();
        Employee employee = new Employee(username, password);
        EmployeeBusiness employeeBusiness = new EmployeeBusiness();

        if (employeeBusiness.AuthLogin(employee) == true)
        {
            //set session
            HttpContext.Session.SetInt32(Common.SESSION_USER_LOGIN, employee.ID);
            HttpContext.Session.SetString(Common.SESSION_USER_FULLNAME, employee.FullName);

            int isAdmin;
            if (Rules.IsAdmin(employee.ID) == true)
            {
                isAdmin = 1;
            }
            else
            {
                isAdmin = 0;
            }

            //session check admin
            HttpContext.Session.SetInt32(Common.SESSION_ISADMIN, isAdmin);



            //session check DarkMenu
            bool darkMenu = false;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
                sqlConnection.Open();
                string sql = $"select DarkMode from ClientSetting where Employee_ID = {employee.ID}";
                SqlCommand command = new SqlCommand(sql, sqlConnection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    darkMenu = sqlDataReader.GetBoolean(0);
                }
                sqlConnection.Close();
            }
            catch
            {
                // 
            }
            if (darkMenu == true)
            {
                HttpContext.Session.SetInt32(Common.SESSION_DARKMENU, 1);
            }
            else
            {
                HttpContext.Session.SetInt32(Common.SESSION_DARKMENU, 0);
            }




            return RedirectToAction("Index", "Dashboard");
        }
        else
        {
            TempData["messageLogin"] = "Bạn nhập sai tài khoản hoặc mật khẩu.";
            return RedirectToAction("Index");
        }
    }

    //dang xuat
    public IActionResult Logout()
    {
        HttpContext.Session.Remove(Common.SESSION_USER_LOGIN);
        HttpContext.Session.Remove(Common.SESSION_ISADMIN);
        HttpContext.Session.Remove(Common.SESSION_USER_FULLNAME);
        return RedirectToAction("Index");
    }

}

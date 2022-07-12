using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PLC_Management.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RemoveSessionDeadMiddleware
    {
        private readonly RequestDelegate _next;

        public RemoveSessionDeadMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // neu ma session login ton tai va session login la id user da bi delete
            if (httpContext.Session.GetInt32(Common.SESSION_USER_LOGIN) != null && Common.listIdUserHasDeleted.Contains((int)httpContext.Session.GetInt32(Common.SESSION_USER_LOGIN)) == true)
            {

                Common.listIdUserHasDeleted.Remove((int)httpContext.Session.GetInt32(Common.SESSION_USER_LOGIN));
                httpContext.Session.Remove(Common.SESSION_USER_LOGIN);
                httpContext.Session.Remove(Common.SESSION_ISADMIN);
                httpContext.Session.Remove(Common.SESSION_USER_FULLNAME);

                System.Diagnostics.Debug.WriteLine("RemoveSessionDeadMiddleware RemoveSessionDeadMiddleware RemoveSessionDeadMiddleware");
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyAppExtentions
    {
        public static IApplicationBuilder UseRemoveSessionDeadMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RemoveSessionDeadMiddleware>();
        }
    }
}

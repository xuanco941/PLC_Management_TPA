
namespace PLC_Management
{
    public class Common
    {

        public const string ConnectionString = @"Data Source=DESKTOP-P4IC2M8\SQLEXPRESS;Initial Catalog=PLC_MANAGEMENT_TPA;User ID=sa;Password=942001xX";

        public const string SESSION_USER_LOGIN = "SESSION_USER_LOGIN";

        public const string SESSION_USER_FULLNAME = "SESSION_USER_FULLNAME";

        public const string SESSION_USER_ISADMIN = "SESSION_USER_ISADMIN";

        public const string SESSION_ISADMIN = "SESSION_ISADMIN";

        public const string SESSION_DARKMENU = "SESSION_DARKMENU";

        public static int NUMBER_ELM_ON_PAGE = 50;

        public const int NUMBER_ELM_ON_PAGE_ACTIVITY = 50;

        public static List<int> listIdUserHasDeleted = new List<int>();

        public static string? Message;
    }
}

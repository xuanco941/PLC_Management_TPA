using System.Data.SqlClient;

namespace PLC_Management.Models.ThongSoMayModel
{
    public class ThongSoMayBusiness
    {
        public static void UpdateEmployee(float ApSuat, TimeSpan ThoiGianNapGioiHan)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "exec UpdateThongSoMay @ApSuat, @ThoiGianNapGioiHan";

            command.Parameters.AddWithValue("ApSuat", ApSuat);
            command.Parameters.AddWithValue("ThoiGianNapGioiHan", ThoiGianNapGioiHan);
            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}

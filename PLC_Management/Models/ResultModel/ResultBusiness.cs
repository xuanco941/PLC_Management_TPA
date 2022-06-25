using System.Data.SqlClient;

namespace PLC_Management.Models.ResultModel
{
    public class ResultBusiness
    {
        public ResultBusiness()
        {
        }

        public List<Result> GetAllResults(int? page)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql;
            if (page != null && page != 0)
            {
                int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE;
                int? end = page * Common.NUMBER_ELM_ON_PAGE;
                sql = $"exec paginationResult {start},{end}";
            }
            else
            {
                sql = "select * from Result order by Result.Result_ID DESC";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetFloat(1), sqlDataReader.GetFloat(2), sqlDataReader.GetString(3), sqlDataReader.GetTimeSpan(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6), sqlDataReader.GetDateTime(7));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        public List<Result> GetResultByDay(string tungay, string toingay, int? page)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql;
            if (page != null && page != 0)
            {
                int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE;
                int? end = page * Common.NUMBER_ELM_ON_PAGE;
                sql = $"exec paginationResultByDay {start},{end},'{tungay}','{toingay}'";
            }
            else
            {
                sql = $"exec FindResultDayToDay '{tungay}', '{toingay}'";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetFloat(1), sqlDataReader.GetFloat(2), sqlDataReader.GetString(3), sqlDataReader.GetTimeSpan(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6), sqlDataReader.GetDateTime(7));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        public List<Result> GetResultByDayAndParameter(string tungay, string toingay, string Oxi, string Nitor, int? page)
        {
            List<Result> list = new List<Result>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql;
            if (page != null && page != 0)
            {
                int? start = (page - 1) * Common.NUMBER_ELM_ON_PAGE;
                int? end = page * Common.NUMBER_ELM_ON_PAGE;
                sql = $"exec paginationResultByDayAndParameter {start},{end},'{tungay}','{toingay}','{Oxi}','{Nitor}'";
            }
            else
            {
                sql = $"exec FindResultDayToDayByParameter '{tungay}', '{toingay}','{Oxi}','{Nitor}'";
            }
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Result result = new Result(sqlDataReader.GetInt32(0), sqlDataReader.GetFloat(1), sqlDataReader.GetFloat(2), sqlDataReader.GetString(3), sqlDataReader.GetTimeSpan(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6), sqlDataReader.GetDateTime(7));
                list.Add(result);
            }
            sqlConnection.Close();
            return list;
        }

        public static int CountResult()
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select count(*) from Result";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static int CountResultByDay(string tungay, string toingay)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec CountResultDayToDay '{tungay}', '{toingay}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static int CountResultByParameterAndDay(string tungay, string toingay, string idOxi, string idNitor)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = $"exec CountResultByParameterAndDay '{tungay}', '{toingay}', '{idOxi}', '{idNitor}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }




        public static void AddResult(Result result)
        {

            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"exec AddResult @Result_ApSuatNap ,@Result_TheTichNap ,@Result_LoaiKhi ,@Result_ApSuatLayMau, @Result_LuuLuongLayMau, @Result_ThoiGian ";
            command.Parameters.AddWithValue("Result_ApSuatNap", Math.Round(result.ApSuatNap, 4, MidpointRounding.AwayFromZero));
            command.Parameters.AddWithValue("Result_TheTichNap", Math.Round(result.TheTichNap, 4, MidpointRounding.AwayFromZero));
            command.Parameters.AddWithValue("Result_LoaiKhi", result.LoaiKhi);
            command.Parameters.AddWithValue("Result_ApSuatLayMau", result.ApSuatLayMau);
            command.Parameters.AddWithValue("Result_LuuLuongLayMau", result.LuuLuongLayMau);
            command.Parameters.AddWithValue("Result_ThoiGian", result.ThoiGian);


            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteResultByIDAndParameter(int startID, int endID, string Oxi, string Nitor)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = $"exec DeleteResultByIDAndParameter {startID}, {@endID}, '{Oxi}', '{Nitor}'";

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteAllResults()
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "Delete from Result";

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}

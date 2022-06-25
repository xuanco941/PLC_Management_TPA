using PROFINET_STEP_7.Profinet;
using PLC_Management.Models.ActivityModel;

namespace PLC_Management
{
    public class MainPLC
    {
        public static PLC plc;
        public static ExceptionCode errCode;

        public static System.Timers.Timer TimerRefreshData;


        public static void Start()
        {
            string ip = "192.168.0.1";
            CPU_Type cpu = CPU_Type.S71200;
            Int16 rack = 0;
            Int16 slot = 1;

            plc = new PLC(cpu, ip, rack, slot);
            try
            {
                if (string.IsNullOrEmpty(plc.IP))
                {
                    CurrentValuePLC.Message = "*Thiếu địa chỉ IP";
                    throw new Exception("Xin vui lòng nhập địa chỉ IP");
                }
                if (!plc.IsAvailable)
                {
                    CurrentValuePLC.Message = "*Không tìm thấy PLC cần kết nối!";
                    throw new Exception("Không tìm thấy PLC cần kết nối!");
                }
                errCode = plc.Open();
                if (errCode != ExceptionCode.ExceptionNo)
                {
                    CurrentValuePLC.Message = "*Lỗi: " + plc.lastErrorString.ToString();
                    throw new Exception(plc.lastErrorString);
                }

                // success
                CurrentValuePLC.Message = null;
                ActivityBusiness.AddActivity("Kết nối máy PLC thành công.");
            }
            catch
            {
                CurrentValuePLC.Message = "Không thể kết nối máy PLC";
            }
        }


        public static void Stop()
        {
            try
            {
                plc.Close();
            }
            catch (Exception ex)
            {
                CurrentValuePLC.Message = "*Lỗi đóng máy: " + ex.Message;
            }
        }


        public static void GetData()
        {
            
        }
    }
}

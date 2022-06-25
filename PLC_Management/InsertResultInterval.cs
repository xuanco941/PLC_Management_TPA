using PLC_Management.Models.ResultModel;
using System.Timers;

namespace PLC_Management
{
    public class InsertResultInterval
    {
        public static System.Timers.Timer TimerInsertResult;
        //Time Save Result
        // mặc định 10s
        public static int timeSaveData { get; set; } = 10000;        
       

    }
}

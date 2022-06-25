using PLC_Management.Models.ParameterModel;

namespace PLC_Management
{
    public class CurrentValuePLC
    {

        //Parameter 
        public static Parameter P_pH = new Parameter("pH", "pH", "5/9", "");
        public static Parameter P_Temp = new Parameter("Temp", "Temp", "40", "Độ C");
        public static Parameter P_TSS = new Parameter("TSS", "TSS", "100", "mg/L");
        public static Parameter P_COD = new Parameter("COD", "COD", "150", "mg/L");
        public static Parameter P_NH4 = new Parameter("NH4", "NH4", "", "");
        public static List<Parameter> parameters = new List<Parameter>() { P_pH, P_Temp, P_TSS, P_COD, P_NH4 };


        //Message
        public static string Message { get; set; }

    }

}

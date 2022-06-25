namespace PLC_Management.Models.ResultModel
{
    public class Result
    {
        public int ID { get; set; }
        public float ApSuatNap { get; set; }
        public float TheTichNap { get; set; }
        public string LoaiKhi { get; set; }
        public TimeSpan ThoiGian { get; set; }
        public string ApSuatLayMau { get; set; }
        public string LuuLuongLayMau { get; set; }
        public DateTime CreateAt { get; set; }

        public Result(int iD, float apSuatNap, float theTichNap, string loaiKhi, TimeSpan thoiGian, string apSuatLayMau, string luuLuongLayMau, DateTime createAt)
        {
            ID = iD;
            ApSuatNap = apSuatNap;
            TheTichNap = theTichNap;
            LoaiKhi = loaiKhi;
            ThoiGian = thoiGian;
            ApSuatLayMau = apSuatLayMau;
            LuuLuongLayMau = luuLuongLayMau;
            CreateAt = createAt;
        }

        public Result()
        {
        }
    }

}

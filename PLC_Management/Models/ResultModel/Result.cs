namespace PLC_Management.Models.ResultModel
{
    public class Result
    {
        public int ID { get; set; }
        public double ApSuatNap { get; set; }
        public double TheTichNap { get; set; }
        public string? LoaiKhi { get; set; }
        public string? ApSuatLayMau { get; set; }
        public string? LuuLuongLayMau { get; set; }
        public TimeSpan ThoiGian { get; set; }
        public DateTime CreateAt { get; set; }

        public Result(int iD, double apSuatNap, double theTichNap, string? loaiKhi, string? apSuatLayMau, string? luuLuongLayMau, TimeSpan thoiGian, DateTime createAt)
        {
            ID = iD;
            ApSuatNap = apSuatNap;
            TheTichNap = theTichNap;
            LoaiKhi = loaiKhi;
            ApSuatLayMau = apSuatLayMau;
            LuuLuongLayMau = luuLuongLayMau;
            ThoiGian = thoiGian;
            CreateAt = createAt;
        }

        public Result()
        {
        }
    }

}

namespace PLC_Management.Models.ThongSoMayModel
{
    public class ThongSoMay
    {
        public int ID { get; } = 1;
        public double Apsuat { get; set; }
        public TimeSpan ThoiGianNapGioiHan { get; set; }
        public DateTime UpdateAt { get; }

        public ThongSoMay(double apsuat, TimeSpan thoiGianNapGioiHan, DateTime updateAt)
        {
            Apsuat = apsuat;
            ThoiGianNapGioiHan = thoiGianNapGioiHan;
            UpdateAt = updateAt;
        }
    }
}

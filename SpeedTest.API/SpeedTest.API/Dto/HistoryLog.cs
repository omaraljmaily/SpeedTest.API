namespace SpeedTest.API.Dto
{
    public class HistoryLog
    {
        public double Download { get; set; }
        public double Upload { get; set; }
        public double Ping { get; set; }
        public string Id { get; set; }
    }
}
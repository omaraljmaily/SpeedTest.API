using System;

namespace SpeedTest.API.Entities
{
    public class History
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double Download { get; set; }
        public double Upload { get; set; }
        public double Ping { get; set; }
        public DateTime LogTime { get; set; }
    }
}
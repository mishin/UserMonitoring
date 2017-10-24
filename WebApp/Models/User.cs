using System;

namespace WebApp.Models
{
    public class User
    {
        public string Id { get; set; }

        public Geo Geo { get; set; }

        public Demography Demo { get; set; }

        public DateTime EnterTime { get; set; }

        public DateTime ExitTime { get; set; }

        public bool WiFi { get; set; }

        public decimal AvgCheck { get; set; }
    }
}
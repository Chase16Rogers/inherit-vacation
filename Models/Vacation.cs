using System;

namespace Ivacation.Models
{
    public class Vacation
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public float price { get; set; }
        public int days { get; set; }
        public int nights { get; set; }
        public string destination { get; set; }
    }
}
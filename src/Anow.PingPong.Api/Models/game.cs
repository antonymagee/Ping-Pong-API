using System;

namespace Anow.PingPong.Api.Models
{
    public class GameObject
    {
        public long Id { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public DateTime Time { get; set; }
        public int Player1score { get; set; }
        public int Player2score { get; set; }
        public string Winner { get; set; }

    }
}


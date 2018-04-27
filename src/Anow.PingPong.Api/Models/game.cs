using System;
using System.ComponentModel.DataAnnotations;

namespace Anow.PingPong.Api.Models
{
    public class GameObject
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(3)]
        public string Player1 { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(3)]
        public string Player2 { get; set; }
        
        [StringLength(25)]
        [MinLength(3)]
        public string Player3 { get; set; }

        [StringLength(25)]
        [MinLength(3)]
        public string Player4 { get; set; }

        [Required]
        public int Score1 { get; set; }

        [Required]
        public int Score2 { get; set; }

        public DateTime Time { get; set; }

        public string Winner { get; set; }

    }
}


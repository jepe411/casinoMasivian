using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace casinoMasivian.DTO
{
    public class Bet
    {
        public int IdRoulette { get; set; }
        public string color { get; set; }
        public int? number { get; set; }
        public int amount { get; set; }
        public float profits { get; set; }
        public int userId { get; set; }
    }
}

using casinoMasivian.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casinoMasivian.DATA
{
    public class DataBet
    {
        public static List<Bet> _BetList = new List<Bet>();
        public void Create(Bet newBet)
        {
            _BetList.Add(newBet);
        }
        public void closeBet(int idRoullete)
        {            
            Random winner = new Random();
            int number = winner.Next(0, 36);           
            foreach (Bet b in _BetList.Where(p => p.IdRoulette == idRoullete))
            {
                if (b.number != null)
                {
                    if (b.number == number) 
                        b.profits = b.amount * 5; 
                    else  
                        b.profits = 0;                     
                }
                if (b.color!=null)
                {
                    if (b.color.Equals("negro") && number%2!=0)                    
                        b.profits = (float)(b.amount * 1.8);                    
                    else if (b.color.Equals("rojo") && number % 2 == 0)                    
                        b.profits = (float)(b.amount * 1.8);                    
                    else                    
                        b.profits = 0;                    
                }
            }
        }
        public IEnumerable<Bet> getBets()
        {
            return _BetList;
        }


    }




}

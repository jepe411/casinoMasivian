using casinoMasivian.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casinoMasivian.DATA
{
    public class DataRoulette
    {
        public static List<Roulette> _rouletteList = new List<Roulette>()
        {
            new Roulette() { Id = 1 , isOpen=false},
            new Roulette() { Id = 2, isOpen=false},
            new Roulette() { Id = 3, isOpen=false}
        };
        public void Create(Roulette newRoulette)
        {
            _rouletteList.Add(newRoulette);
        }
        public IEnumerable<Roulette> getRoulette()
        {
            return _rouletteList;
        }
        public Roulette getRouletteById(int id)
        {
            var roulette = _rouletteList.Where(p => p.Id == id);
            return roulette.FirstOrDefault();
        }

        public void updateRouletteState(Roulette r)
        {
            foreach (Roulette re in _rouletteList.Where(p=>p.Id==r.Id ))
            {
                re.isOpen = r.isOpen;
            }

            Console.WriteLine(_rouletteList);
        }


    }
}

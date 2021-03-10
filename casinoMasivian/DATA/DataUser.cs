using casinoMasivian.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casinoMasivian.DATA
{
    public class DataUser
    {
        public static List<User> _userList = new List<User>()
        {
            new User() { idUser = 1 , amount=20000},
            new User() { idUser = 2, amount=40000},
            new User() { idUser = 3, amount=60000}
        };

        public User getUserById(int id)
        {
            var user = _userList.Where(p => p.idUser == id);
            return user.FirstOrDefault();
        }
    }
}

using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IClubRepository
    {
        IEnumerable<Player> GetClubs();
        Player GetClubById(int ClubId);

        Player GetClubByName(String email);
        void InsertClub(Player club);
        void UpdateClub(Player Club);
        void DeleteClub(Player Club);
        IEnumerable<Player> Search(String key);
    }
}

using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ClubRepository : IClubRepository
    {
        public void DeleteClub(Player club)
        => ClubDAO.Insance.Remove(club);
        public Player GetClubById(int ClubId)
         => ClubDAO.Insance.GetClubById(ClubId);
        public Player GetClubByName(string name)
          => ClubDAO.Insance.GetClubByName(name);
        public IEnumerable<Player> GetClubs()
       => ClubDAO.Insance.GetClubList();
        public void InsertClub(Player Club)
         => ClubDAO.Insance.AddNew(Club);
        public IEnumerable<Player> Search(string key)
         => ClubDAO.Insance.Search(key);
        public void UpdateClub(Player Club)
         => ClubDAO.Insance.Update(Club);
    }
}

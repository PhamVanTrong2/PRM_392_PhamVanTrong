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
        public void DeleteClub(Club club)
        => ClubDAO.Insance.Remove(club);
        public Club GetClubById(int ClubId)
         => ClubDAO.Insance.GetClubById(ClubId);
        public Club GetClubByName(string name)
          => ClubDAO.Insance.GetClubByName(name);
        public IEnumerable<Club> GetClubs()
       => ClubDAO.Insance.GetClubList();
        public void InsertClub(Club Club)
         => ClubDAO.Insance.AddNew(Club);
        public IEnumerable<Club> Search(string key)
         => ClubDAO.Insance.Search(key);
        public void UpdateClub(Club Club)
         => ClubDAO.Insance.Update(Club);
    }
}

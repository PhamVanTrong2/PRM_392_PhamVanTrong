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
        IEnumerable<Club> GetClubs();
        Club GetClubById(int ClubId);

        Club GetClubByName(String email);
        void InsertClub(Club club);
        void UpdateClub(Club Club);
        void DeleteClub(Club Club);
        IEnumerable<Club> Search(String key);
    }
}

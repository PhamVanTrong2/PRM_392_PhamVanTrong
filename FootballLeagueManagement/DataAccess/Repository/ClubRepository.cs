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
        public IEnumerable<Club> GetClubs() => ClubDAO.Instance.GetClubs();
    }
}

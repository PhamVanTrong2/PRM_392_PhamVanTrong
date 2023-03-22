using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MatchRepository : IMatchRepository
    {
        public IEnumerable<Match> GetMatches() => MatchDAO.Instance.GetMatches();
    }
}

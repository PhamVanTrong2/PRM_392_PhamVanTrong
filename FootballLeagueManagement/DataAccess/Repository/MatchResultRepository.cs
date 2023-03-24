using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MatchResultRepository : IMatchResultRepository
    {
        public IEnumerable<MatchResult> GetMatchResults() => MatchResultDAO.Instance.GetMatchResult();
    }
}

using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MatchResultDAO
    {
        //Using Singleton Pattern
        private static MatchResultDAO instance = null;
        private static readonly object instanceLock = new object();

        private MatchResultDAO() { }
        public static MatchResultDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MatchResultDAO();
                }
                return instance;
            }
        }

        public IEnumerable<MatchResult> GetMatchResult()
        {
            List<MatchResult> matches;
            try
            {
                var FlmDB = new NhaappContext();
                matches = FlmDB.MatchResults.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return matches;
        }
    }
}

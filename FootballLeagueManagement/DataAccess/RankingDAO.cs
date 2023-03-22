using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RankingDAO
    {
        //Using Singleton Pattern
        private static RankingDAO instance = null;
        private static readonly object instanceLock = new object();

        private RankingDAO() { }
        public static RankingDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new RankingDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Ranking> GetRankingList()
        {
            List<Ranking> rankings;

            try
            {
                var FlmDB = new NhaappContext();
                rankings = FlmDB.Rankings.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rankings;
        }


    }
}

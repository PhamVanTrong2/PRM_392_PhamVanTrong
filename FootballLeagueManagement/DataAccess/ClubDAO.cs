using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClubDAO
    {
        //Using Singleton Pattern
        private static ClubDAO instance = null;
        private static readonly object instanceLock = new object();

        private ClubDAO() { }
        public static ClubDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ClubDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Club> GetClubs()
        {
            List<Club> clubs;

            try
            {
                var FlmDB = new NhaappContext();
                clubs = FlmDB.Clubs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clubs;
        }
    }
}

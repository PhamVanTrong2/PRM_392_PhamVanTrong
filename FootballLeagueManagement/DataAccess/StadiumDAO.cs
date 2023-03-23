using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StadiumDAO
    {
        //Using Singleton Pattern
        private static StadiumDAO instance = null;
        private static readonly object instanceLock = new object();

        private StadiumDAO() { }
        public static StadiumDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new StadiumDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Stadium> GetStadiums()
        {
            List<Stadium> stadiums;

            try
            {
                var FlmDB = new NhaappContext();
                stadiums = FlmDB.Stadia.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stadiums;
        }
    }
}

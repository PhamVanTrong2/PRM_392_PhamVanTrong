using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GoalDAO
    {
        //Using Singleton Pattern
        private static GoalDAO instance = null;
        private static readonly object instanceLock = new object();

        private GoalDAO() { }
        public static GoalDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new GoalDAO();
                }
                return instance;
            }
        }
    }
}

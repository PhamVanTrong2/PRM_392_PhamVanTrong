using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MatchDAO
    {
        //Using Singleton Pattern
        private static MatchDAO instance = null;
        private static readonly object instanceLock = new object();

        private MatchDAO() { }
        public static MatchDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MatchDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Match> GetMatches()
        {
            List<Match> matches;
            try
            {
                var FlmDB = new NhaappContext();
                matches = FlmDB.Matches.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return matches;
        }

        public Match GetMatchById(int MatchId)
        {
            Match match = null;
            try
            {
                var FlmDB = new NhaappContext();
                match = FlmDB.Matches.SingleOrDefault(match => match.MatchId == MatchId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return match;
        }

        public void InsertMatch(Match _match)
        {
            try
            {
                Match match = GetMatchById(_match.MatchId);
                if(match == null)
                {
                    var FlmDb = new NhaappContext();
                    FlmDb.Matches.Add(_match);
                    FlmDb.SaveChanges();
                }else
                {
                    throw new Exception("Match is already exists.");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMatch(Match _match)
        {
            try
            {
                Match match = GetMatchById(_match.MatchId);
                if (match != null)
                {
                    var FlmDb = new NhaappContext();
                    FlmDb.Matches.Update(_match);
                    FlmDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Match isn't exists.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMatch(Match _match)
        {
            try
            {
                Match match = GetMatchById(_match.MatchId);
                if (match != null)
                {
                    var FlmDb = new NhaappContext();
                    FlmDb.Matches.Remove(_match);
                    FlmDb.SaveChanges();
                }
                else
                {
                    throw new Exception("Match isn't exists.");
                }

            }
            catch(Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ClubDAO
    {
        private static ClubDAO instance = null;
        private static readonly object instanceLock = new object();
        private ClubDAO() { }
        public static ClubDAO Insance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ClubDAO();
                    }
                }
                return instance;
            }
        }


        public IEnumerable<Club> GetClubList()
        {
            List<Club> Clubs;
            try
            {
                var myStockDB = new NhaappContext();
                Clubs = myStockDB.Clubs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Clubs;
        }

        public Club GetClubById(int ClubId)
        {
            Club Club = null;
            try
            {
                var myStockDB = new NhaappContext();
                Club = myStockDB.Clubs.SingleOrDefault(Club => Club.ClubId == ClubId);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return Club;
        }

        public Club GetClubByName(String name)
        {
            Club Club = null;
            try
            {
                var myStockDB = new NhaappContext();
                Club = myStockDB.Clubs.SingleOrDefault(Club => Club.Name == name);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return Club;
        }

        public void AddNew(Club club)
        {
            try
            {
                Club _Club = GetClubById(club.ClubId);
                if (_Club == null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Clubs.Add(club);
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Club is already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(Club Club)
        {
            try
            {
                Club c = GetClubById(Club.ClubId);
                if (c != null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Entry<Club>(Club).State = EntityState.Modified;
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Club does not already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Club Club)
        {
            try
            {
                Club c = GetClubById(Club.ClubId);
                if (c != null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Clubs.Remove(Club);
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Club does not already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Club> Search(String keyword)
        {
            List<Club> products;
            var myStockDB = new NhaappContext();
            try
            {
                products = myStockDB.Clubs
                                    .Where(p => p.Name.Contains(keyword)
                                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
    }
}

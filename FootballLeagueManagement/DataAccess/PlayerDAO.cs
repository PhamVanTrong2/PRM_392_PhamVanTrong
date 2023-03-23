using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    internal class PlayerDAO
    {
        private static PlayerDAO instance = null;
        private static readonly object instanceLock = new object();
        private PlayerDAO() { }
        public static PlayerDAO Insance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PlayerDAO();
                    }
                }
                return instance;
            }
        }


        public IEnumerable<Player> GetPlayerList()
        {
            List<Player> Players;
            try
            {
                var myStockDB = new NhaappContext();
                Players = myStockDB.Players.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Players;
        }

        public Player GetPlayerById(int PlayerId)
        {
            Player Player = null;
            try
            {
                var myStockDB = new NhaappContext();
                Player = myStockDB.Players.SingleOrDefault(Player => Player.PlayerId == PlayerId);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return Player;
        }

        public Player GetPlayerByName(String name)
        {
            Player Player = null;
            try
            {
                var myStockDB = new NhaappContext();
                Player = myStockDB.Players.SingleOrDefault(Player => Player.Name == name);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return Player;
        }

        public void AddNew(Player Player)
        {
            try
            {
                Player _Player = GetPlayerById(Player.PlayerId);
                if (_Player == null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Players.Add(Player);
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Player is already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(Player Player)
        {
            try
            {
                Player c = GetPlayerById(Player.PlayerId);
                if (c != null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Entry<Player>(Player).State = EntityState.Modified;
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Player does not already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Player Player)
        {
            try
            {
                Player c = GetPlayerById(Player.PlayerId);
                if (c != null)
                {
                    var myStockDb = new NhaappContext();
                    myStockDb.Players.Remove(Player);
                    myStockDb.SaveChanges();
                }
                else
                { throw new Exception("The Player does not already exist"); }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Player> Search(String keyword)
        {
            List<Player> products;
            var myStockDB = new NhaappContext();
            try
            {
                products = myStockDB.Players
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


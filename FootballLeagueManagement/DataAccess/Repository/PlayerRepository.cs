using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        public void DeletePlayer(Player Player) => PlayerDAO.Insance.Remove(Player);

        public Player GetPlayerByName(string name)
        => PlayerDAO.Insance.GetPlayerByName(name);

        public Player GetPlayerById(int PlayerId) => PlayerDAO.Insance.GetPlayerById(PlayerId);

        public IEnumerable<Player> GetPlayers()
        => PlayerDAO.Insance.GetPlayerList();

        public void InsertPlayer(Player Player)
        => PlayerDAO.Insance.AddNew(Player);
        public void UpdatePlayer(Player Player)
        => PlayerDAO.Insance.Update(Player);
        public IEnumerable<Player> Search(String key)
        => PlayerDAO.Insance.Search(key);
    }
}

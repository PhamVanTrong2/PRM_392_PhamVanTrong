using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayerById(int PlayerId);

        Player GetPlayerByName(String email);
        void InsertPlayer(Player Player);
        void UpdatePlayer(Player Player);
        void DeletePlayer(Player Player);
        IEnumerable<Player> Search(String key);
    }
}

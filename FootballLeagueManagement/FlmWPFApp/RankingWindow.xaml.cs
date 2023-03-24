using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlmWPFApp
{
    /// <summary>
    /// Interaction logic for RankingWindow.xaml
    /// </summary>
    public partial class RankingWindow : Window
    {
        public IRankingRepository rankingRepository;
        public IClubRepository clubRepository;
        public IMatchResultRepository matchResultRepository;
        public RankingWindow(IRankingRepository repository, IClubRepository _clubRepository, IMatchResultRepository _matchResultRepository)
        {
            InitializeComponent();
            this.rankingRepository = repository;
            this.clubRepository = _clubRepository;
            this.matchResultRepository = _matchResultRepository;
            LoadRankingList(); 
        }

            public void LoadRankingList()
        {
            var BangXepHang = (from c in clubRepository.GetClubs()
                               select new
                               {
                                   STT = STT(c.ClubId),
                                   c.LogoUrl,
                                   ClubName = c.Name,
                                   MatchPlayed = TotalPlayed(c.ClubId),
                                   Won = CountWin(c.ClubId),
                                   Drawn = CountDraw(c.ClubId),
                                   Lost = CountLose(c.ClubId),
                                   GoalsFor = TotalNumberOfGoal(c.ClubId),
                                   GoalsAgainst = TotalNumberOfGA(c.ClubId),
                                   GoalDifference = TotalNumberOfGoal(c.ClubId) - TotalNumberOfGA(c.ClubId),
                                   Point = CaculatePoint(c.ClubId)
                               }).OrderByDescending(x => x.Point).ToList();
            lvRanking.ItemsSource = BangXepHang;
        }

        public int STT(int clubId)
        {
            int result = 0;
            var stt = clubRepository.GetClubs()
                         .OrderByDescending(c => CaculatePoint(c.ClubId))
                         .ThenByDescending(c => TotalNumberOfGoal(c.ClubId));
            result = stt.ToList().FindIndex(c => c.ClubId == clubId) + 1;  //Sắp xếp list giảm dần, sau đó tìm ClubId trong danh sách ở vị trí bao nhiêu
            return result;
        }

        public int TotalPlayed(int clubId)
        {
            int result = 0;
            var splayed = matchResultRepository.GetMatchResults().Where(x => x.ClubId == clubId);
            result = splayed.Count();
            return result;
        }

        public int CountWin(int? clubID)
        {
            int result = 0;
            var sWin = matchResultRepository.GetMatchResults().Where(x => x.ClubId == clubID).Where(s => s.WinLose == "W");
            result = sWin.Count();
            return result;

        }
        public int CountLose(int? clubID)
        {
            int result = 0;
            var sLose = matchResultRepository.GetMatchResults().Where(x => x.ClubId == clubID).Where(s => s.WinLose == "L");
            result = sLose.Count();
            return result;
        }
        public int CountDraw(int? clubID)
        {
            int result = 0;
            var sDraw = matchResultRepository.GetMatchResults().Where(x => x.ClubId == clubID).Where(s => s.WinLose == "D");
            result = sDraw.Count();
            return result;
        }

        //Tính số điểm mỗi club
        public int CaculatePoint(int? clubID)
        {
            return CountWin(clubID) * 3 + CountDraw(clubID);
        }

        //Tính số bàn thắng
        public int TotalNumberOfGoal(int? clubID)
        {
            var s = matchResultRepository.GetMatchResults().Where(s => s.ClubId == clubID).ToList();
            int result = 0;
            foreach (var item in s)
            {
                result += (int)item.GoalScore;
            }
            return result;
        }

        //Tính số bàn thua
        public int TotalNumberOfGA(int clubId)
        {
            var s = matchResultRepository.GetMatchResults().Where(mr => mr.ClubId == clubId)
                         .GroupBy(mr => mr.MatchId)
                         .Select(g => new {
                             MatchId = g.Key,
                             GoalScore = g.FirstOrDefault(mr => mr.WinLose == "W")?.GoalScore ?? 0
                         }).ToList();
            int result = 0;
            foreach (var item in s)
            {
                result += (int)item.GoalScore;
            }
            return result;
        }

    }
}

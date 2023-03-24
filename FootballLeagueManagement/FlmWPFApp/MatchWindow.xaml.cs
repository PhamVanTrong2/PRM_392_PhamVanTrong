using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    {
        IMatchRepository matchRepository;
        IAccountRepository caccountRepository;
        IClubRepository clubRepository;
        IStadiumRepository stadiumRepository;
        IMatchResultRepository matchResultRepository;

/*        Match match = new();*/
        public MatchWindow(IAccountRepository _accountrepository, IMatchRepository repository, IClubRepository _clubRepository, IStadiumRepository _stadiumRepository, IMatchResultRepository _matchResultRepository)
        {
            InitializeComponent();
            caccountRepository = _accountrepository;
            this.matchRepository = repository;
            this.clubRepository = _clubRepository;
            this.stadiumRepository= _stadiumRepository;
            this.matchResultRepository = _matchResultRepository;

            // Tạo danh sách các ngày
            List<DateTime> matchDates = new List<DateTime>();
            matchDates = matchRepository.GetMatches().Select(m => m.PlayDate.Value.Date).Distinct().ToList();

            // Sắp xếp danh sách ngày theo thứ tự giảm dần
            matchDates.Sort();
            matchDates.Reverse();

            // Gán danh sách các ngày vào ItemsSource của ComboBox
            cbDate.ItemsSource = matchDates;

            // Lấy ngày mới nhất
            DateTime latestDate = matchDates.FirstOrDefault();

            // Tự động chọn ngày mới nhất
            cbDate.SelectedItem = latestDate;

            // Hiển thị danh sách trận đấu theo ngày mới nhất lên ListView
            LoadMatches(latestDate);

            // Xử lý sự kiện SelectionChanged của ComboBox
            cbDate.SelectionChanged += (sender, e) =>
            {
                DateTime selectedDate = (DateTime)cbDate.SelectedItem;
                LoadMatches(selectedDate);
            };
        }
        public void LoadMatches(DateTime selectedDate)
        {
            /*            match.Host = clubRepository.GetClubs().SingleOrDefault(c => c.ClubId == match.HostId);
                        match.Guest = clubRepository.GetClubs().SingleOrDefault(c => c.ClubId == match.GuestId);
                        MatchResult hostResult = matchResultRepository.GetMatchResults().SingleOrDefault(r => r.MatchId == match.MatchId
                                                                                        && r.ClubId == match.HostId);
                        MatchResult guestResult = matchResultRepository.GetMatchResults().SingleOrDefault(r => r.MatchId == match.MatchId
                                                                                        && r.ClubId == match.GuestId);*/

            var matches = from m in matchRepository.GetMatches()
                          join h in clubRepository.GetClubs() on m.HostId equals h.ClubId
                          join g in clubRepository.GetClubs() on m.GuestId equals g.ClubId
                          join s in stadiumRepository.GetStadiums() on h.StadiumId equals s.StadiumId
                          select new
                          {
                              MatchId = m.MatchId,
                              Host = h.Name,
                              Visit = g.Name,
                              PlayDate = m.PlayDate,
                              PlayTime = m.PlayDate?.TimeOfDay.ToString("hh\\:mm"),
                              Stadium = s.Name
                           };

            // Lọc danh sách các trận đấu theo ngày được chọn
            matches = matches.Where(m => m.PlayDate.HasValue && m.PlayDate.Value.Date == selectedDate.Date);

            lvMatches.ItemsSource = matches.ToList();
        }

        private void cbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = (DateTime)cbDate.SelectedItem;
            LoadMatches(selectedDate);
        }


        private void lvMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnInsertMatch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateMatch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteMatch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

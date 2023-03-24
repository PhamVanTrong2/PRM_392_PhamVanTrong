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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        IAccountRepository accountRepository;
        IMatchRepository matchRepository;
        IClubRepository clubRepository;
        IRankingRepository rankingRepository;

        IPlayerRepository playerRepository;

        IStadiumRepository stadiumRepository;
        IMatchResultRepository matchResultRepository;
        public HomeWindow(IAccountRepository _accountRepository,
                     IMatchRepository _matchRepository,
                     IPlayerRepository _playerRepository,
                     IClubRepository _clubRepository,
                     IRankingRepository _ankingRepository,
                     IStadiumRepository _stadiumRepository,
                     IMatchResultRepository _matchResultRepository)
        {
            stadiumRepository = _stadiumRepository;
            matchResultRepository = _matchResultRepository;
            accountRepository = _accountRepository;
            rankingRepository = _ankingRepository;
            matchRepository = _matchRepository;
            clubRepository = _clubRepository;
            playerRepository = _playerRepository;
            InitializeComponent();
        }
        private void button1_Click1(object sender, RoutedEventArgs e)
        {
            MatchWindow mainWindow = new MatchWindow(accountRepository, matchRepository, clubRepository, stadiumRepository, matchResultRepository);
            mainWindow.Show();

        }
        private void button1_Click2(object sender, RoutedEventArgs e)
        {
            RankingWindow dc = new RankingWindow(rankingRepository, clubRepository, matchResultRepository);
            dc.Show();

        }
        private void button1_Click3(object sender, RoutedEventArgs e)
        {
            DetailsMatch dc = new DetailsMatch(clubRepository);
            dc.Show();


        }

        private void button1_Click4(object sender, RoutedEventArgs e)
        {
            PlayerWindow dc = new PlayerWindow(playerRepository);
            dc.Show();
        }
    }
}

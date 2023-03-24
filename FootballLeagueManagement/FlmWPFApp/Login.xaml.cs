using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;

namespace FlmWPFApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        IAccountRepository accountRepository;
        IMatchRepository matchRepository;
        IClubRepository clubRepository;

        IPlayerRepository playerRepository;
        IRankingRepository rankingRepository;
        IStadiumRepository stadiumRepository;
        IMatchResultRepository matchResultRepository;

        public Login(IAccountRepository _accountRepository,
                     IMatchRepository _matchRepository,
                     IRankingRepository _rankingRepository,
                     IPlayerRepository _playerRepository,
                     IClubRepository _clubRepository,
                     IStadiumRepository _stadiumRepository,
                     IMatchResultRepository _matchResultRepository
            )
        {
            stadiumRepository = _stadiumRepository;
            matchResultRepository = _matchResultRepository;
            rankingRepository = _rankingRepository;
            accountRepository = _accountRepository;
            playerRepository = _playerRepository;
            matchRepository = _matchRepository;
            clubRepository = _clubRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String username = txtUser.Text;
            String password = txtPass.Password;
            Account m = accountRepository.Login(username, password);
            Account member = accountRepository.GetAccountByUserName(username);
            if (m != null && member.Username.Contains("admin"))
            {

                HomeWindow mainwindow = new HomeWindow(accountRepository, matchRepository, playerRepository, clubRepository, rankingRepository, stadiumRepository, matchResultRepository);
                Application.Current.Properties["member"] = m;
                mainwindow.Show();
            }
            else if (m != null && !member.Equals("admin"))
            {
                MatchForClub window = new MatchForClub(clubRepository);
                window.Show();
            }
            else if (m == null)
            {
                MessageBox.Show("Email or Password incorrect", "Login");
            }
            Close();

        }
        private void btnMinimize_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();
    }

}




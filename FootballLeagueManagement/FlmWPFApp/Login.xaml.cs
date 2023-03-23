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

        public Login(IAccountRepository _accountRepository, IMatchRepository _matchRepository, IClubRepository _clubRepository)
        {
            accountRepository = _accountRepository;
            matchRepository = _matchRepository;
            clubRepository = _clubRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            /*String username = txtUser.Text;
            String password = txtPass.Password;
            Account m = accountRepository.Login(username, password);
            Account member = accountRepository.GetAccountByUserName(username);
            //if (m != null && member.Equals("admin"))
            //{
            //    MatchWindow mainwindow = new MatchWindow(accountRepository, matchRepository);
            //    Application.Current.Properties["member"] = m;
            //    mainwindow.Show();
            //}
            //else if (m != null && !member.Equals("admin"))
            //{
            MatchForClub window = new MatchForClub(clubRepository);

            window.Show();


            //}
            //else if (m == null)
            //{
            //    MessageBox.Show("Email or Password incorrect", "Login");
            //}
            //Close();

            }
            else if (m == null)
            {
                MessageBox.Show("Email or Password incorrect", "Login");
            }
            Close();*/
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
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


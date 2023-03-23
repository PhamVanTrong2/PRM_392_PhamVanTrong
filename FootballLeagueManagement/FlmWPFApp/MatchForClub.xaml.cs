using BusinessObject;
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

using System.Data;
using System.Drawing;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using DataAccess.Repository;

namespace FlmWPFApp
{
    /// <summary>
    /// Interaction logic for MatchForClub.xaml
    /// </summary>
    public partial class MatchForClub : Window
    {
        NhaappContext context = new NhaappContext();
        readonly Club club = new();
        IClubRepository clubRepository;
        public MatchForClub(IClubRepository _clubRepository)
        {
            InitializeComponent();
            clubRepository = _clubRepository;
            List<Matchs> matches = new List<Matchs>();
            matches.Add(new Matchs { Team1 = "Arsenal", Score1 = "1", Team2 = "Liverpool", Score2 = "0", Minutes = 90, Time = "20/12/2022" });
            matches.Add(new Matchs { Team1 = "Arsenal", Score1 = "1", Team2 = "Everton", Score2 = "1", Minutes = 90, Time = "22/12/2022" });
            matches.Add(new Matchs { Team1 = "Arsenal", Score1 = "5", Team2 = "Brentford", Score2 = "2", Minutes = 90, Time = "24/12/2022" });
            matches.Add(new Matchs { Team1 = "Arsenal", Score1 = "5", Team2 = "Tottenham Hotspur", Score2 = "3", Minutes = 90, Time = "26/12/2022" });
            matches.Add(new Matchs { Team1 = "Arsenal", Score1 = "", Team2 = "Newcastle United", Score2 = "", Minutes = 0, Time = "28/12/2022" });
            matches.Add(new Matchs { Team1 = "Arsenal", Score1 = "", Team2 = "Nottingham Forest", Score2 = "", Minutes = 0, Time = "30/12/2022" });

            lvOrder.ItemsSource = matches;



        }
        public class Matchs
        {
            public String Team1 { get; set; }
            public String Team2 { get; set; }
            public String Score1 { get; set; }
            public String Score2 { get; set; }
            public long Minutes { get; set; }
            public String Time { get; set; }
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DetailsMatch dt = new DetailsMatch(clubRepository);
            dt.Show();
        }

        private void lvOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

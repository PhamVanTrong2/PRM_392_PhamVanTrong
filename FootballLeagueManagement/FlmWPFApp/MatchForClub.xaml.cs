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
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Navigation;

namespace FlmWPFApp
{
    /// <summary>
    /// Interaction logic for MatchForClub.xaml
    /// </summary>
    public partial class MatchForClub : Window
    {
        NhaappContext context = new NhaappContext();
        readonly Club club = new();
        public MatchForClub(Club club)
        {
            InitializeComponent();
            this.club = club;
        }
        private void LoadSchedule()
        {
            club.Name = txtCulb.Text;

            List<Match> matches = new List<Match>();
            foreach (var item in context.Matches.ToList())
            {
                if (item.HostId == club.ClubId || item.GuestId == club.ClubId)
                {
                    item.Host = context.Clubs.SingleOrDefault(s => s.ClubId == item.HostId);
                    item.Guest = context.Clubs.SingleOrDefault(s => s.ClubId == item.GuestId);
                    matches.Add(item);
                }
            }


            foreach (var item in matches)
            {
                
            }
        }


    }

}

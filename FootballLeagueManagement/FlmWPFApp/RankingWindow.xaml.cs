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
        public RankingWindow(IRankingRepository repository)
        {
            InitializeComponent();
            rankingRepository = repository;
        }

        public void LoadRankingList()
        {
            lvRanking.ItemsSource = rankingRepository.GetRankings();
        }

        private void RankingLoad_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

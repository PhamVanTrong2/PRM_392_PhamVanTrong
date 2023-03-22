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
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    {
        IMatchRepository matchRepository;
        public MatchWindow(IMatchRepository repository)
        {
            InitializeComponent();
            this.matchRepository = repository;
            LoadMatches();
        }

        public void LoadMatches()
        {
            lvMatches.ItemsSource = matchRepository.GetMatches();
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

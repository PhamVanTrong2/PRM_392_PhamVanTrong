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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlmWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRankingRepository rankingRepository;
        public MainWindow(IRankingRepository repository)
        {
            InitializeComponent();
            rankingRepository = repository;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnMatchSchedule_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        IPlayerRepository playerRepository;
        public PlayerWindow(IPlayerRepository playerRepositor)
        {
            InitializeComponent();
            playerRepository = playerRepositor;
        }
        private Player GetPlayerObject()
        {
            Player nember = null;

            try
            {
                nember = new Player
                {
                    PlayerId = int.Parse(txtPlayerId.Text),
                    Name = txtName.Text,
                    Dob = txtDob.Text,
                    CountryId = int.Parse(txtCountryId.Text),
                    PositionId = txtPositionId.Text,
                    Height = txtHeight.Text,
                    Weight = txtWeight.Text,
                    Image = txtImage.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get player");
            }
            return nember;
        }// end Getnemberobject
        public void LoadnemberList()
        {
            lvCars.ItemsSource = playerRepository.GetPlayers();
        }


        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadnemberList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Player nember = GetPlayerObject();
                playerRepository.InsertPlayer(nember);
                LoadnemberList();
                MessageBox.Show($"{nember.Name} inserted successfully ", "Insert nember");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert nember");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Player nember = GetPlayerObject();
                playerRepository.UpdatePlayer(nember);
                LoadnemberList();
                MessageBox.Show($"{nember.Name} Update successfully ", "Update nember");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update nember");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Player nember = GetPlayerObject();
                playerRepository.DeletePlayer(nember);
                LoadnemberList();
                MessageBox.Show($"{nember.Name} Delete successfully ", "Delete nember");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete nember");
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lvCars.ItemsSource = playerRepository.Search(txtSearch.Text);
        }
        private void btnBack_Click_Exit(object sender, RoutedEventArgs e)
        {
            //HomeWindow dc = new HomeWindow(PlayerRepository, memberRepository);
            //dc.Show();
            //this.Close();
        }
    }
}

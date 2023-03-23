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
    /// Interaction logic for DetailsMatch.xaml
    /// </summary>
    public partial class DetailsMatch : Window
    {
        IClubRepository clubRepository;
        public DetailsMatch(IClubRepository clubRepositor)
        {
            InitializeComponent();
            clubRepository = clubRepositor;
        }

        private Player GetClubObject()
        {
            Player nember = null;

            try
            {
                nember = new Player
                {
                    ClubId = int.Parse(txtClubId.Text),
                    Name = txtName.Text,
                    YearCreated = txtYearCreated.Text,
                    CountryId = int.Parse(txtCountryId.Text),
                    City = txtCity.Text,
                    Address = txtAddress.Text,
                    StadiumId = int.Parse(txtStadiumId.Text),
                    LogoUrl = txtLogoUrl.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Club");
            }
            return nember;
        }// end Getnemberobject
        public void LoadnemberList()
        {
            lvCars.ItemsSource = clubRepository.GetClubs();
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
                Player nember = GetClubObject();
                clubRepository.InsertClub(nember);
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

            Player member = (Player)lvCars.SelectedItems[0];

            UpdateClub updateMember = new UpdateClub(member, clubRepository);
            updateMember.txtClubName.Text = member.Name;
            updateMember.txtYearCreated.Text = member.YearCreated;
            updateMember.txtCountryId.Text = member.CountryId.ToString();
            updateMember.txtCityId.Text = member.City;
            updateMember.txtAddress.Text = member.Address;
            updateMember.txtStadiumId.Text = member.StadiumId.ToString();
            updateMember.txtLogoUrl.Text = member.Address;
            updateMember.txtId.Text = member.ClubId.ToString();
            updateMember.Show();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Player nember = GetClubObject();
                clubRepository.DeleteClub(nember);
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
            lvCars.ItemsSource = clubRepository.Search(txtSearch.Text);
        }
        private void btnBack_Click_Exit(object sender, RoutedEventArgs e)
        {
            //HomeWindow dc = new HomeWindow(clubRepository, memberRepository);
            //dc.Show();
            //this.Close();
        }
    }
}

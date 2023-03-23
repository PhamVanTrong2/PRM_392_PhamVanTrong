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
    /// Interaction logic for UpdateClub.xaml
    /// </summary>
    public partial class UpdateClub : Window
    {
        Club club;
        IClubRepository clubRepository;
        public UpdateClub(Club c, IClubRepository _clubRepository)
        {
            InitializeComponent();
            club = c;
            clubRepository = _clubRepository;
        }
        private Club GetClubObject()
        {
            Club Club = null;
            try
            {
                Club = new Club
                {
                    ClubId = int.Parse(txtId.Text),
                    Name = (txtClubName.Text),
                    YearCreated = txtYearCreated.Text,
                    CountryId = int.Parse(txtCountryId.Text),
                    City = txtCityId.Text,
                    Address = txtAddress.Text,
                    StadiumId = int.Parse(txtStadiumId.Text),
                    LogoUrl = txtLogoUrl.Text
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "get Club");
            }
            return Club;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Club Club = GetClubObject();
                clubRepository.UpdateClub(Club);

                MessageBox.Show($"update successfully", "update Club");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Club");
            }
        }
    }
}

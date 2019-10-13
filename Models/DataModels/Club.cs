using DAIF2020.Models.SettingModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAIF2020.Models.DataModels
{
    public class Club
    {
        public int Id { get; set; }

        // Club props !
        [Display(Name = "#")]
        public string ClubNumber { get; set; }

        [Display(Name = "Club")]
        public string ClubName { get; set; }

        [Display(Name = "Short name")]
        public string ShortName { get; set; }

        [Display(Name = "Streetaddress")]
        public string StreetAddress { get; set; }

        [Display(Name = "Postalcode")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Address")]
        public string Address { get { return string.Format("{0} {1} {2}", StreetAddress, ZipCode, City); } }

        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        [Display(Name = "District")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }

        [Display(Name = "Home Arena")]
        public int? ArenaId { get; set; }
        [Display(Name = "Home Arena")]
        [ForeignKey("ArenaId")]
        public Arena Arena { get; set; }

        public int? ClubStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ClubStatusId")]
        public ClubStatus ClubStatus { get; set; }
    }
}
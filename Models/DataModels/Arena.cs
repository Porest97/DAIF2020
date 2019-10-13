using DAIF2020.Models.SettingModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAIF2020.Models.DataModels
{
    public class Arena
    {
        public int Id { get; set; }

        [Display(Name = "#")]
        public string ArenaNumber { get; set; }

        [Display(Name = "Arena")]
        public string ArenaName { get; set; }

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

        public int? ArenaStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ArenaStatusId")]
        public ArenaStatus ArenaStatus { get; set; }

    }
}
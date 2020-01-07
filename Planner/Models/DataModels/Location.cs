using System.ComponentModel.DataAnnotations;

namespace DAIF2020.Planner.Models.DataModels
{
    public class Location
    {
        public int Id { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

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
        public string Address { get { return string.Format("{0} {1} {2} {3}", LocationName, StreetAddress, ZipCode, City); } }
    }
}
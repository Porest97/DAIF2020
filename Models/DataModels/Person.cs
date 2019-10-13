using DAIF2020.Models.SettingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAIF2020.Models.DataModels
{
    public class Person
    {
        public int Id { get; set; }

        // Person Setting props!
        public int? PersonRoleId { get; set; }
        [Display(Name = "Role")]
        [ForeignKey("PersonRoleId")]
        public PersonRole PersonRole { get; set; }

        public int? PersonStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("PersonStatusId")]
        public PersonStatus PersonStatus { get; set; }

        public int? PersonTypeId { get; set; }
        [Display(Name = "Person Type")]
        [ForeignKey("PersonTypeId")]
        public PersonType PersonType { get; set; }

        // Person Org props !
        public int? ClubId { get; set; }
        [Display(Name = "Club")]
        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public int? DistrictId { get; set; }
        [Display(Name = "District")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }

        //Person Personalia !
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get { return string.Format("{0} {1} ", FirstName, LastName); } }

        //CName = Contact Name with Phonenumbers attached !
        public string CName { get { return string.Format("{0} {1} ", FullName, Ssn); } }

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

        [Display(Name = "SSN")]
        public string Ssn { get; set; }

        [Display(Name = "Telefonnummer1")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Telefonnummer2")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber2 { get; set; }

        public string PhoneNumbers { get { return string.Format("{0} {1} ", PhoneNumber1, PhoneNumber2); } }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Person Accounts !
        [Display(Name = "Swish #")]
        [DataType(DataType.PhoneNumber)]
        public string SwishNumber { get; set; }

        [Display(Name = "Bank #")]
        public string BankAccount { get; set; }

        [Display(Name = "Bank")]
        public string BankName { get; set; }

        [Display(Name = "Swish# and Bank#")]
        public string PaymentDetails { get { return string.Format("{0} {1}", SwishNumber, BankAccount); } }
    }
}

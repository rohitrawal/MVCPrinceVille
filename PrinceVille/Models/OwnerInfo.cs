using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrinceVille.Models
{
    public class OwnerInfo
    {
        [Key]
        public int ownerId { get; set; }
        public string ownerCode { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string ownerFirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string ownerLastName { get; set; }
        [Required]
        public char Gender { get; set; }
        public string Block { get; set; }
        [Display(Name = "Flat Number")]
        [Required]
        public string FlatNumber { get; set; }
        [Display(Name = "Home Phone Number")]
        public string HomePhone { get; set; }
        [Display(Name = "Mobile Number")]
        [Required]
        public string MobileNumber { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string ownerEmail { get; set; }
        [Display(Name = "Photo")]
        public byte[] ownerPhoto { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace crypto_restapi.Models
{
    public partial class Users
    {
       [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string api_key { get; set; }
        public string Password { get; set; }
        public byte Active { get; set; }
        public byte Deleted { get; set; }
        public int isNewUser { get; set; }
        public int isAdmin { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateExpirationToken { get; set; }
        public string access_token { get; set; }
    }
}

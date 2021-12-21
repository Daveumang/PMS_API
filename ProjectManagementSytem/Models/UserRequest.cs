using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSytem.Models
{
    public class UserRequest
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Old_Password { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email_id { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string Contact_no { get; set; }
        public string Status { get; set; }
        public string Role_id { get; set; }
        public string IsActive { get; set; }
        public string Created_date { get; set; }
        public string Created_by { get; set; }
    }
}

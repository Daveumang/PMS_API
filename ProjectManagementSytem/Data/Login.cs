using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSytem.Data
{
    [Table("Login")]
    public class Login
    {     
        public int Id { get; set; }
        [Key]
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Old_Password { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email_id { get; set; }
        //public object Email_Id { get; internal set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string Contact_no { get; set; }
        public string Status { get; set; }
        public int Role_Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_date { get; set; }
        public string Created_by { get; set; }
    }
}

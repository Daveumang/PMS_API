using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSytem.Data;
using ProjectManagementSytem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DemoDbContext _dbContext;
        public UserController(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var logins = _dbContext.Logins.ToList();
                if (logins.Count == 0)
                {
                    return StatusCode(404, "no user found");
                }
                return Ok(logins);
            }
            catch (Exception ex)
            {
                return StatusCode(500,"An error has occured");
            }
           
        }
        [HttpPost("CreateUser")]
        public IActionResult Create([FromBody] Login request)
        {
            Login user = new Login();
            user.Id = request.Id;
           //user.User_Id = request.User_Id;
            user.Username = request.Username;
            user.Password = request.Password;
            user.Old_Password = request.Old_Password;
            user.Title = request.Title;
            user.Firstname = request.Firstname;
            user.Lastname = request.Lastname;
            user.Email_id = request.Email_id;
            user.DOB = Convert.ToDateTime(request.DOB);
            user.DOJ = Convert.ToDateTime(request.DOJ);
            user.Contact_no = request.Contact_no;
            user.Status = request.Status;
            user.Role_Id = request.Role_Id;
            user.IsActive = Convert.ToBoolean(request.IsActive);
            user.Created_date = Convert.ToDateTime(request.Created_date);
            user.Created_by = request.Created_by;
            try
            {
                _dbContext.Logins.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }
            var logins = _dbContext.Logins.ToList();
            return Ok(logins);
        }
        [HttpPut("UpdateUser")]
        public IActionResult Update([FromBody] Login request)
        {
            try
            {
                var user = _dbContext.Logins.FirstOrDefault(X => X.User_Id == request.User_Id);
                if( user == null)
                {
                    return StatusCode(404, "no user found");
                }
                user.Id = request.Id;
                user.Email_id = request.Email_id;
                user.Title = request.Title;
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }
            var logins = _dbContext.Logins.ToList();
            return Ok(logins);
        }

        [HttpDelete("DeleteUser/{User_Id}")]
        public  IActionResult Delete([FromRoute] int User_Id)
        {
            try
            {
                var user = _dbContext.Logins.FirstOrDefault(X => X.User_Id == User_Id);
                if (user == null)
                {
                    return StatusCode(404, "no user found");
                }
                _dbContext.Entry(user).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occurred");
            }
            var logins = _dbContext.Logins.ToList();
            return Ok(logins);
        }
    }
}

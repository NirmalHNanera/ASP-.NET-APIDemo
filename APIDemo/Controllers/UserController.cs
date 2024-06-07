using APIDemo.BAL;
using APIDemo.DAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace APIDemo1.Controller
{
    [ApiController]
    [Route("API/[controller]")]
    public class UserHomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            UserBALBase bal = new UserBALBase();
            List<UserModel> users = bal.PR_SELECT_ALL_USER();
            Dictionary<string, dynamic> responce = new Dictionary<string, dynamic>();
            if (users.Count > 0 && users != null)
            {
                responce.Add("Status", true);
                responce.Add("Massage", "Data Found");
                responce.Add("data", users);
                return Ok(responce);
            }
            else
            {
                responce.Add("Status", false);
                responce.Add("Massage", "Data Not Found");
                responce.Add("data", null);
                return NotFound(responce);
            }
        }
        [HttpGet("{UserID}")]
        public IActionResult GetBYID(int UserID)
        {
            UserBALBase bal = new UserBALBase();
            UserModel user = bal.PR_SELECT_BY_PK_USER(UserID);
            Dictionary<string, dynamic> responce = new Dictionary<string, dynamic>();
            if (user != null)
            {
                responce.Add("Status", true);
                responce.Add("Massage", "Data Found");
                responce.Add("data", user);
                return Ok(responce);
            }
            else
            {
                responce.Add("Status", false);
                responce.Add("Massage", "Data Not Found");
                responce.Add("data", null);
                return NotFound(responce);
            }
        }

        [HttpPost]
        public IActionResult Post([FromForm] UserModel userModel)
        {
            User_DALBase user_DALBase = new User_DALBase();
            bool IsSuccess = user_DALBase.PR_INSERT_USER(userModel);
            Dictionary<string, dynamic> responce = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                responce.Add("status", true);
                responce.Add("message", "Data inserted");
                return Ok(responce);
            }
            else
            {
                responce.Add("status", false);
                responce.Add("message", "error");
                return Ok(responce);
            }
        }

        [HttpPut]
        public IActionResult Put(int UserID, [FromForm] UserModel userModel)
        {
            User_DALBase user_DALBase = new User_DALBase();
            bool IsSuccess = user_DALBase.PR_UPDATE_USER(userModel,UserID);
            userModel.UserId = UserID;
            Dictionary<string, dynamic> responce = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                responce.Add("status", true);
                responce.Add("message", "Data updated");
                return Ok(responce);
            }
            else
            {
                responce.Add("status", false);
                responce.Add("message", "error");
                return Ok(responce);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int UserID)
        {
            User_DALBase user_DALBase = new User_DALBase();
            bool IsSuccess = user_DALBase.PR_DELETE_USER(UserID);
            Dictionary<string, dynamic> responce = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                responce.Add("status", true);
                responce.Add("message", "Data Deleted");
                return Ok(responce);
            }
            else
            {
                responce.Add("status", false);
                responce.Add("message", "error");
                return Ok(responce);
            }
        }
    }
}
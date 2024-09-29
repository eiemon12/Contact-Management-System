using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagementSystem.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Create(UserDTO obj)
        {
            try
            {
                var result = UserService.Create(obj);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User successfully created");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create user");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(UserDTO obj)
        {
            try
            {
                var result = UserService.Update(obj);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User successfully updated");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update user");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                var result = UserService.Delete(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User successfully deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to delete user");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

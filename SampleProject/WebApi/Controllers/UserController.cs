using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Users;
using Microsoft.Ajax.Utilities;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("users")]
    public class UserController : BaseApiController
    {
        private readonly ICreateUserService _createUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IGetUserService _getUserService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IValidateUserService _validateUserService;

        public UserController(ICreateUserService createUserService, IDeleteUserService deleteUserService, IGetUserService getUserService, IUpdateUserService updateUserService, IValidateUserService validateUserService)
        {
            _createUserService = createUserService;
            _deleteUserService = deleteUserService;
            _getUserService = getUserService;
            _updateUserService = updateUserService;
            _validateUserService = validateUserService;
        }

        [Route("{userId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateUser(Guid userId, [FromBody] UserModel model)
        {
            HttpResponseMessage result = null;

            // Check to see if this user id exists
            if (_getUserService.GetUser(userId) == null)
            {
                // User id does not exist so create the new user
                var user = _createUserService.Create(userId, model.Name, model.Email, model.Type, model.AnnualSalary, model.Age, model.Tags);
                result = Found(new UserData(user));
            }
            else
            {
                // User id does exist, so return an error
                result = DoesNotExist();
            }

            return result;
        }

        [Route("{userId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateUser(Guid userId, [FromBody] UserModel model)
        {
            HttpResponseMessage result = null;

            var user = _getUserService.GetUser(userId);
            if (user == null)
            {
                return DoesNotExist();
            }

            List<string> errors = _validateUserService.Validate(model.Name, model.Email, model.Type, model.AnnualSalary, model.Tags);

            if (errors.Count == 0)
            {
                _updateUserService.Update(user, model.Name, model.Email, model.Type, model.AnnualSalary, model.Age, model.Tags);
                result = Found(new UserData(user));
            }
            else
            {
                result = Request.CreateErrorResponse(HttpStatusCode.OK, string.Join(", ", errors));
            }

            return result;
        }

        [Route("{userId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteUser(Guid userId)
        {
            var user = _getUserService.GetUser(userId);
            if (user == null)
            {
                return DoesNotExist();
            }
            _deleteUserService.Delete(user);
            return Found();
        }

        [Route("{userId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetUser(Guid userId)
        {
            var user = _getUserService.GetUser(userId);
            return Found(new UserData(user));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetUsers(int skip, int take, UserTypes? type = null, string name = null, string email = null)
        {
            var users = _getUserService.GetUsers(type, name, email)
                                       .Skip(skip).Take(take)
                                       .Select(q => new UserData(q))
                                       .ToList();
            return Found(users);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllUsers()
        {
            _deleteUserService.DeleteAll();
            return Found();
        }

        [Route("list/tag")]
        [HttpGet]
        public HttpResponseMessage GetUsersByTag(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
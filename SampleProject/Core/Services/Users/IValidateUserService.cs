using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Users
{
    public interface IValidateUserService
    {
        List<string> Validate(string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags);
    }
}

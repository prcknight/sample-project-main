using Common;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ValidateUserService : IValidateUserService
    {
        public List<string> Validate(string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(name))
            {
                result.Add("Name must have a value.");
            }

            if (string.IsNullOrEmpty(email))
            {
                result.Add("Email must have a value");
            }

            if (!annualSalary.HasValue)
            {
                result.Add("Salary must have a value");
            }

            return result;
        }
    }
}

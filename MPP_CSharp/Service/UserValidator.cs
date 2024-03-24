using System;
using System.Collections.Generic;
using Common.Logging;
using MPP_CSharp.Domain;
using Spring.Validation;

namespace MPP_CSharp.Service
{
    public class UserValidator : IValidator
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserValidator));

        public bool Validate(object validationContext, IValidationErrors errors)
        {
            if (!(validationContext is User user))
            {
                throw new ArgumentException("Object is not of type User.");
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                errors.AddError("Username", new ErrorMessage("Username cannot be empty."));
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                errors.AddError("Password", new ErrorMessage("Password cannot be empty."));
            }

            return errors.IsEmpty;
        }

        public bool Validate(object validationContext, IDictionary<string, object> contextParams, IValidationErrors errors)
        {
            var user = validationContext as User;
            if (user == null)
            {
                throw new ArgumentException("Object is not of type User.");
            }
            
            if (string.IsNullOrEmpty(user.Username))
            {
                errors.AddError("Username", new ErrorMessage("Username cannot be empty."));
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                errors.AddError("Password", new ErrorMessage("Password cannot be empty."));
            }

            return errors.IsEmpty;
        }
    }
}
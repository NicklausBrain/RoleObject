using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleObject
{
    public abstract class Subject
    {
        private readonly Dictionary<Type, Role> _roles;

        protected Subject(params Role[] roles)
        {
            _roles = roles.ToDictionary(r => r.GetType(), r => r);
        }

        public Result<T, string> As<T>() where T : Role
        {
            return _roles.ContainsKey(typeof(T))
                ? new Result<T, string>((T)_roles[typeof(T)])
                : new RoleIsMissingResult<T>(
                    $"{typeof(T)} is not available for subject {this}");
        }
    }
}

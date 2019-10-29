using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RoleObject
{
    public abstract class Subject
    {
        private readonly IReadOnlyDictionary<Type, Role> _roles;

        protected Subject(params Role[] roles)
        {
            _roles = new ReadOnlyDictionary<Type, Role>(
                roles.ToDictionary(r => r.GetType(), r => r));
        }

        public bool Is<T>() where T : Role => _roles.ContainsKey(typeof(T));

        public T As<T>() where T : Role => _roles.ContainsKey(typeof(T))
            ? (T)_roles[typeof(T)]
            : throw new UnauthorizedAccessException($"{this} has no role {typeof(T)} assigned");
    }
}

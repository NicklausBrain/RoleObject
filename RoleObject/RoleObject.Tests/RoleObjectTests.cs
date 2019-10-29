using System;
using Xunit;

namespace RoleObject.Tests
{
    public class RoleObjectTests
    {
        // subjects

        public class ApiSubject : Subject
        {
            public ApiSubject(params Role[] roles) : base(roles)
            {

            }
        }

        // roles

        public class Viewer: Role
        {
            public object GetDevices() => new
            {
                /* Implementation details */ 
            };
        }

        public class Manager: Viewer
        {
            public void RegisterDevice(object device)
            {
                /* Implementation details */
            }
        }

        public class Admin : Manager
        {
            public void DeactivateAccount(Guid id)
            {
                 /* Implementation details */
            }
        }

        [Fact]
        public void Test1()
        {
            Subject subject = new ApiSubject(new Viewer(), new Manager());

            var device = subject.As<Viewer>().GetDevices();

            Assert.NotNull(device);
        }
    }
}

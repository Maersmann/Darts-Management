using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darts.Data.Model.UserEntitys;
using Darts.Logic.Core.UserCore;

namespace Darts.Logic.Core.KonvertierungCore
{
    public class KonvertierungDartUser
    {
        public void Start()
        {
            User User = new User { Username = "dart" };
            IUserService UserService = new UserService();
            _ = UserService.Create(User, "1929");
        }
    }
}

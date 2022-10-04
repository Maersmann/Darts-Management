using Darts.Data.Model.UserEntitys.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core.UserCore
{
    public class UserAPI
    {
        public bool Authenticate( AuthenticateDTO model)
        {
            var user = new UserService().Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

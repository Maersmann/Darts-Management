using Darts.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Data.Repository.Base
{
    public class Database
    {
    
        public void OpenConnection()
        {
            GlobalVariables.CreateRepoBase();
        }
    }
}

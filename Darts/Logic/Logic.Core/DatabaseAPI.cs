using Darts.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core
{
    public class DatabaseAPI
    {
        public void AktualisereDatenbank()
        {
            Database dbAPI = new Database();
            dbAPI.OpenConnection();
        }
    }
}

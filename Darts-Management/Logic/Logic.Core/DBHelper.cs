using Darts.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.Core
{
    public class DBHelper
    {
        public bool TestCheckServerIsOnline(string dB_Password, string dB_User)
        {
            try
            {
                GlobalVariables.DB_User = dB_User;
                GlobalVariables.DB_Password = dB_Password;
                var db = new DatabaseAPI();
                db.AktualisereDatenbank(false);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void CheckServerIsOnline()
        {
            try
            {
                var db = new DatabaseAPI();
                db.AktualisereDatenbank(true);
                GlobalVariables.DBIstErreichbar = true;
            }
            catch (Exception)
            {

                GlobalVariables.DBIstErreichbar = false;
            }

        }
    }
}

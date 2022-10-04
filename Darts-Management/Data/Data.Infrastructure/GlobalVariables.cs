using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Data.Infrastructure
{
    public static class GlobalVariables
    {
        private static Context dbContext = null;

        public static bool DBIstErreichbar { get; set; }
        public static string DB_Password { get; set; }
        public static string DB_User { get; set; }

        public static Context GetContext()
        {
            dbContext = dbContext ?? new Context();
            return dbContext;
        }

        public static void CreateRepoBase()
        {
            dbContext = dbContext ?? new Context();
        }
    }
}


using Darts.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Darts.Data.Repository.Base
{
    public class BaseRepository
    {
        protected readonly RepositoryBase repo;
        public BaseRepository()
        {
            repo = GlobalVariables.GetRepoBase();
        }
    }
}

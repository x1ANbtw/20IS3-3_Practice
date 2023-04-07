
using DataAccess.Interfaces;
using Online_Market_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MarketContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}

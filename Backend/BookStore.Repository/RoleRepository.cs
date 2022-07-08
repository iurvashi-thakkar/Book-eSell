using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.ViewModels;
using BookStore.Models.Models;

namespace BookStore.Repository
{
    public class RoleRepository : BaseRepository
    {
        public ListResponse<Role> GetRoles()
        {
            var query = context.Roles.AsQueryable();
            var totalRecords = query.Count();
            IEnumerable<Role> role = query;
            return new ListResponse<Role>()
            {
                Results = role,
                TotalRecords = totalRecords
            };
        }

    }
}
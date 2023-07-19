using AutoMapper;
using Domain.Interface.User;
using Domain.Model.User;
using Infrastructure.Persistence.Entities.Samina;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.Permission
{
    public class PermissionService : IPermissionService
    {

        protected readonly SaminaDbContext _context;
        private readonly IMapper _mapper;
        public PermissionService(SaminaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HashSet<string>> GetPermissionsAsync(long userId)
        {
            // return new HashSet<string> { "1", "2" };

        
            var userPermissions = _context.BranchUsers
                  .Where(bu => bu.UserId == userId)
                  .Join(_context.Roles, bu => bu.RoleId, r => r.Id, (bu, r) => r)
                  .SelectMany(r => r.AccessControlLists)
                  .Select(acl => acl.Permission.PermissionType)
                  .ToHashSet();

            return userPermissions;
        }
    }
}

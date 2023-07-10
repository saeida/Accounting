using AutoMapper;
using Domain.Interface.User;
using Domain.Model.User;
using Infrastructure.Persistence.Entities.CrudTest;
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

        protected readonly CrudtestContext _context;
        private readonly IMapper _mapper;
        public PermissionService(CrudtestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HashSet<string>> GetPermissionsAsync(long userId)
        {
            // return new HashSet<string> { "1", "2" };
            var userPermissions = _context.AccessControlLists
      .Where(acl => acl.Role.Users.Any(u => u.Id == userId))
      .Select(acl => acl.Permission.Id.ToString())
      .ToHashSet();

            return userPermissions;
        }
    }
}

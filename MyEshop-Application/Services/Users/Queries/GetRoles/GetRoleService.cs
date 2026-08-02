using MyEshop_Application.Interfaces.Contexts;

namespace MyEshop_Application.Services.Users.Queries.GetRoles
{
    public partial class GetRoleService : IGetRoleService
    {
        private readonly IDatabaseContext _databaseContext;

        public GetRoleService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<RolesDto> GetRoles()
        {
            return _databaseContext.Roles.Select(r=>new RolesDto()
            {
                Id=r.Id,
                Name=r.Name,
            }).ToList();


         
        }
    }
}
